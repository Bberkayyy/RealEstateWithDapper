using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.DashboardViewModels;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentDashboardChartComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _EstateAgentDashboardChartComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/EstateAgents/fivecityforchart");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<EstateAgentPanelResultChartViewModel>? values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultChartViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
