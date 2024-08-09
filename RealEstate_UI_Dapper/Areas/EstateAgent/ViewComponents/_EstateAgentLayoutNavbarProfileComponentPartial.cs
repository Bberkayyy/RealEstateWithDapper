using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.UserViewModels;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Services;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentLayoutNavbarProfileComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    private readonly ILoginService _loginService;

    public _EstateAgentLayoutNavbarProfileComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
        _loginService = loginService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        string id = _loginService.Id;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            EstateAgentPanelResultUserViewModel? user = JsonConvert.DeserializeObject<EstateAgentPanelResultUserViewModel>(jsonData);
            return View(user);
        }
        return View();
    }
}
