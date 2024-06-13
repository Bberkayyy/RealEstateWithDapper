using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.NavbarViewModels;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.ProductViewModels;
using RealEstate_UI_Dapper.Services;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentNavbarMessageComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public _EstateAgentNavbarMessageComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        int id = Int32.Parse(_loginService.Id);
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Messages/Last5MessageByReceiverIdWithRelationships?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<EstateAgentPanelResultLast5MessageViewModel>? values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultLast5MessageViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
