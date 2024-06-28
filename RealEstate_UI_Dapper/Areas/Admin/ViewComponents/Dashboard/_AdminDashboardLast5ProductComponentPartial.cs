using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.DashboardViewModels;
using RealEstate_UI_Dapper.Models;

namespace RealEstate_UI_Dapper.Areas.Admin.ViewComponents.Dashboard;

public class _AdminDashboardLast5ProductComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public _AdminDashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Products/Last5ProductListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultLast5ProductWithRelationshipsViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultLast5ProductWithRelationshipsViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
