using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.Admin.ViewComponents.Dashboard;

public class _AdminDashboardStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        #region ProductCount
        HttpResponseMessage responseMessageProductCount = await client.GetAsync("https://localhost:7221/api/Statistics/ProductCount");
        string jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonDataProductCount;
        #endregion
        #region ActiveEmployeeCount
        HttpResponseMessage responseMessageActiveEmployeeCount = await client.GetAsync("https://localhost:7221/api/Statistics/ActiveEmployeeCount");
        string jsonDataActiveEmployeeCount = await responseMessageActiveEmployeeCount.Content.ReadAsStringAsync();
        ViewBag.activeEmployeeCount = jsonDataActiveEmployeeCount;
        #endregion
        #region AverageRentPrice
        HttpResponseMessage responseMessageAverageRentPrice = await client.GetAsync("https://localhost:7221/api/Statistics/AverageRentPrice");
        string jsonDataAverageRentPrice = await responseMessageAverageRentPrice.Content.ReadAsStringAsync();
        ViewBag.averageRentPrice = jsonDataAverageRentPrice;
        #endregion
        #region AverageSalePrice
        HttpResponseMessage responseMessageAverageSalePrice = await client.GetAsync("https://localhost:7221/api/Statistics/AverageSalePrice");
        string jsonDataAverageSalePrice = await responseMessageAverageSalePrice.Content.ReadAsStringAsync();
        ViewBag.averageSalePrice = jsonDataAverageSalePrice;
        #endregion
        return View();
    }
}
