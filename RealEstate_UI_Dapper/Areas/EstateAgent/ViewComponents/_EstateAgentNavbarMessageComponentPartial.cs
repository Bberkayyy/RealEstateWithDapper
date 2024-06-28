using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.NavbarViewModels;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.ProductViewModels;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Services;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentNavbarMessageComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;
    private readonly ApiSettings _apiSettings;

    public _EstateAgentNavbarMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _apiSettings = apiSettings.Value;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        int id = Int32.Parse(_loginService.Id);
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Messages/Last5MessageByReceiverIdWithRelationships?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<EstateAgentPanelResultLast5MessageViewModel>? values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultLast5MessageViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
