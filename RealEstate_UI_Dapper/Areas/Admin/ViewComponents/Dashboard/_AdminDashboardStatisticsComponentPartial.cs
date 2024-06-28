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
        #region ProductCount
        HttpResponseMessage responseMessageProductCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ProductCount");
        string jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonDataProductCount;
        #endregion
        #region ActiveEmployeeCount
        HttpResponseMessage responseMessageActiveEmployeeCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ActiveEmployeeCount");
        string jsonDataActiveEmployeeCount = await responseMessageActiveEmployeeCount.Content.ReadAsStringAsync();
        ViewBag.activeEmployeeCount = jsonDataActiveEmployeeCount;
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
