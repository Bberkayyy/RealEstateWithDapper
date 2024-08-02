using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_UI_Dapper.Models;

namespace RealEstate_UI_Dapper.Areas.Admin.ViewComponents.Dashboard;

public class _AdminDashboardStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        #region PropertyCount
        HttpResponseMessage responseMessagePropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/PropertyCount");
        string jsonDataPropertyCount = await responseMessagePropertyCount.Content.ReadAsStringAsync();
        ViewBag.PropertyCount = jsonDataPropertyCount;
        #endregion
        #region ActiveEstateAgentCount
        HttpResponseMessage responseMessageActiveEstateAgentCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ActiveEstateAgentCount");
        string jsonDataActiveEstateAgentCount = await responseMessageActiveEstateAgentCount.Content.ReadAsStringAsync();
        ViewBag.activeEstateAgentCount = jsonDataActiveEstateAgentCount;
        #endregion
        #region AverageRentPrice
        HttpResponseMessage responseMessageAverageRentPrice = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageRentPrice");
        string jsonDataAverageRentPrice = await responseMessageAverageRentPrice.Content.ReadAsStringAsync();
        ViewBag.averageRentPrice = jsonDataAverageRentPrice;
        #endregion
        #region AverageSalePrice
        HttpResponseMessage responseMessageAverageSalePrice = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageSalePrice");
        string jsonDataAverageSalePrice = await responseMessageAverageSalePrice.Content.ReadAsStringAsync();
        ViewBag.averageSalePrice = jsonDataAverageSalePrice;
        #endregion
        return View();
    }
}
