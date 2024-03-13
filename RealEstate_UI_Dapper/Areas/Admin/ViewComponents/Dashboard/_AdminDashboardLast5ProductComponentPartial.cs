using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.DashboardViewModels;

namespace RealEstate_UI_Dapper.Areas.Admin.ViewComponents.Dashboard;

public class _AdminDashboardLast5ProductComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AdminDashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Products/Last5ProductListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultLast5ProductWithRelationshipsViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultLast5ProductWithRelationshipsViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
