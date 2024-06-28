using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.DashboardViewModels;
using RealEstate_UI_Dapper.Models;

namespace RealEstate_UI_Dapper.Areas.Admin.ViewComponents.Dashboard;

public class _AdminDashboardToDoListComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public _AdminDashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "ToDoLists");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultToDoListForDashboardViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultToDoListForDashboardViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
