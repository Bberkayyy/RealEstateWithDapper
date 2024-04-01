using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.DashboardViewModels;
using RealEstate_UI_Dapper.Services;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentDashboardLast5ProductComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public _EstateAgentDashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        string id = _loginService.Id;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/EstateAgents/last5product?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<EstateAgentPanelResultLast5ProductViewModel>? values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultLast5ProductViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
