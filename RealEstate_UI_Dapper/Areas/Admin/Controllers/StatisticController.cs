using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class StatisticController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StatisticController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        #region ActiveCategoryCount
        HttpResponseMessage responseMessageActiveCategoryCount = await client.GetAsync("https://localhost:7221/api/Statistics/ActiveCategoryCount");
        string jsonDataActiveCategoryCount = await responseMessageActiveCategoryCount.Content.ReadAsStringAsync();
        ViewBag.activeCategoryCount = jsonDataActiveCategoryCount;
        #endregion
        #region ActiveEmployeeCount
        HttpResponseMessage responseMessageActiveEmployeeCount = await client.GetAsync("https://localhost:7221/api/Statistics/ActiveEmployeeCount");
        string jsonDataActiveEmployeeCount = await responseMessageActiveEmployeeCount.Content.ReadAsStringAsync();
        ViewBag.activeEmployeeCount = jsonDataActiveEmployeeCount;
        #endregion
        #region ApartmentCount
        HttpResponseMessage responseMessageApartmentCount = await client.GetAsync("https://localhost:7221/api/Statistics/ApartmentCount");
        string jsonDataApartmentCount = await responseMessageApartmentCount.Content.ReadAsStringAsync();
        ViewBag.apartmentCount = jsonDataApartmentCount;
        #endregion
        #region AverageRentPrice
        HttpResponseMessage responseMessageAverageRentPrice = await client.GetAsync("https://localhost:7221/api/Statistics/AverageRentPrice");
        string jsonDataAverageRentPrice = await responseMessageAverageRentPrice.Content.ReadAsStringAsync();
        ViewBag.averageRentPrice = jsonDataAverageRentPrice;
        #endregion
        #region AverageRoomCount
        HttpResponseMessage responseMessageAverageRoomCount = await client.GetAsync("https://localhost:7221/api/Statistics/AverageRentPrice");
        string jsonDataAverageRoomCount = await responseMessageAverageRoomCount.Content.ReadAsStringAsync();
        ViewBag.averageRoomCount = jsonDataAverageRoomCount;
        #endregion
        #region AverageSalePrice
        HttpResponseMessage responseMessageAverageSalePrice = await client.GetAsync("https://localhost:7221/api/Statistics/AverageSalePrice");
        string jsonDataAverageSalePrice = await responseMessageAverageSalePrice.Content.ReadAsStringAsync();
        ViewBag.averageSalePrice = jsonDataAverageSalePrice;
        #endregion
        #region CategoryCount
        HttpResponseMessage responseMessageCategoryCount = await client.GetAsync("https://localhost:7221/api/Statistics/CategoryCount");
        string jsonDataCategoryCount = await responseMessageCategoryCount.Content.ReadAsStringAsync();
        ViewBag.categoryCount = jsonDataCategoryCount;
        #endregion
        #region CategoryNameWithMostProductCount
        HttpResponseMessage responseMessageCategoryNameWithMostProductCount = await client.GetAsync("https://localhost:7221/api/Statistics/CategoryNameWithMostProductCount");
        string jsonDataCategoryNameWithMostProductCount = await responseMessageCategoryNameWithMostProductCount.Content.ReadAsStringAsync();
        ViewBag.categoryNameWithMostProductCount = jsonDataCategoryNameWithMostProductCount;
        #endregion
        #region CityNameWithMostProductCount
        HttpResponseMessage responseMessageCityNameWithMostProductCount = await client.GetAsync("https://localhost:7221/api/Statistics/CityNameWithMostProductCount");
        string jsonDataCityNameWithMostProductCount = await responseMessageCityNameWithMostProductCount.Content.ReadAsStringAsync();
        ViewBag.cityNameWithMostProductCount = jsonDataCityNameWithMostProductCount;
        #endregion
        #region DifferentCityCount
        HttpResponseMessage responseMessageDifferentCityCount = await client.GetAsync("https://localhost:7221/api/Statistics/DifferentCityCount");
        string jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
        ViewBag.differentCityCount = jsonDataDifferentCityCount;
        #endregion
        #region EmployeeNameWithMostProductCount
        HttpResponseMessage responseMessageEmployeeNameWithMostProductCount = await client.GetAsync("https://localhost:7221/api/Statistics/EmployeeNameWithMostProductCount");
        string jsonDataEmployeeNameWithMostProductCount = await responseMessageEmployeeNameWithMostProductCount.Content.ReadAsStringAsync();
        ViewBag.employeeNameWithMostProductCount = jsonDataEmployeeNameWithMostProductCount;
        #endregion
        #region LastAddedProductPrice
        HttpResponseMessage responseMessageLastAddedProductPrice = await client.GetAsync("https://localhost:7221/api/Statistics/LastAddedProductPrice");
        string jsonDataLastAddedProductPrice = await responseMessageLastAddedProductPrice.Content.ReadAsStringAsync();
        ViewBag.lastAddedProductPrice = jsonDataLastAddedProductPrice;
        #endregion
        #region NewestBuildingYear
        HttpResponseMessage responseMessageNewestBuildingYear = await client.GetAsync("https://localhost:7221/api/Statistics/NewestBuildingYear");
        string jsonDataNewestBuildingYear = await responseMessageNewestBuildingYear.Content.ReadAsStringAsync();
        ViewBag.newestBuildingYear = jsonDataNewestBuildingYear;
        #endregion
        #region OldestBuildingYear
        HttpResponseMessage responseMessageOldestBuildingYear = await client.GetAsync("https://localhost:7221/api/Statistics/OldestBuildingYear");
        string jsonDataOldestBuildingYear = await responseMessageOldestBuildingYear.Content.ReadAsStringAsync();
        ViewBag.oldestBuildingYear = jsonDataOldestBuildingYear;
        #endregion
        #region PassiveCategoryCount
        HttpResponseMessage responseMessagePassiveCategoryCount = await client.GetAsync("https://localhost:7221/api/Statistics/PassiveCategoryCount");
        string jsonDataPassiveCategoryCount = await responseMessagePassiveCategoryCount.Content.ReadAsStringAsync();
        ViewBag.passiveCategoryCount = jsonDataPassiveCategoryCount;
        #endregion
        #region ProductCount
        HttpResponseMessage responseMessageProductCount = await client.GetAsync("https://localhost:7221/api/Statistics/ProductCount");
        string jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonDataProductCount;
        #endregion

        return View();
    }
}
