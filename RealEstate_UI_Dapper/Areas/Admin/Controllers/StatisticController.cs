using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_UI_Dapper.Models;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class StatisticController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public StatisticController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        #region ActiveCategoryCount
        HttpResponseMessage responseMessageActiveCategoryCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ActiveCategoryCount");
        string jsonDataActiveCategoryCount = await responseMessageActiveCategoryCount.Content.ReadAsStringAsync();
        ViewBag.activeCategoryCount = jsonDataActiveCategoryCount;
        #endregion
        #region ActiveEstateAgentCount
        HttpResponseMessage responseMessageActiveEstateAgentCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ActiveEstateAgentCount");
        string jsonDataActiveEstateAgentCount = await responseMessageActiveEstateAgentCount.Content.ReadAsStringAsync();
        ViewBag.activeEstateAgentCount = jsonDataActiveEstateAgentCount;
        #endregion
        #region ApartmentCount
        HttpResponseMessage responseMessageApartmentCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ApartmentCount");
        string jsonDataApartmentCount = await responseMessageApartmentCount.Content.ReadAsStringAsync();
        ViewBag.apartmentCount = jsonDataApartmentCount;
        #endregion
        #region AverageRentPrice
        HttpResponseMessage responseMessageAverageRentPrice = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageRentPrice");
        string jsonDataAverageRentPrice = await responseMessageAverageRentPrice.Content.ReadAsStringAsync();
        ViewBag.averageRentPrice = jsonDataAverageRentPrice;
        #endregion
        #region AverageRoomCount
        HttpResponseMessage responseMessageAverageRoomCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageRentPrice");
        string jsonDataAverageRoomCount = await responseMessageAverageRoomCount.Content.ReadAsStringAsync();
        ViewBag.averageRoomCount = jsonDataAverageRoomCount;
        #endregion
        #region AverageSalePrice
        HttpResponseMessage responseMessageAverageSalePrice = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageSalePrice");
        string jsonDataAverageSalePrice = await responseMessageAverageSalePrice.Content.ReadAsStringAsync();
        ViewBag.averageSalePrice = jsonDataAverageSalePrice;
        #endregion
        #region CategoryCount
        HttpResponseMessage responseMessageCategoryCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/CategoryCount");
        string jsonDataCategoryCount = await responseMessageCategoryCount.Content.ReadAsStringAsync();
        ViewBag.categoryCount = jsonDataCategoryCount;
        #endregion
        #region CategoryNameWithMostPropertyCount
        HttpResponseMessage responseMessageCategoryNameWithMostPropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/CategoryNameWithMostPropertyCount");
        string jsonDataCategoryNameWithMostPropertyCount = await responseMessageCategoryNameWithMostPropertyCount.Content.ReadAsStringAsync();
        ViewBag.categoryNameWithMostPropertyCount = jsonDataCategoryNameWithMostPropertyCount;
        #endregion
        #region CityNameWithMostPropertyCount
        HttpResponseMessage responseMessageCityNameWithMostPropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/CityNameWithMostPropertyCount");
        string jsonDataCityNameWithMostPropertyCount = await responseMessageCityNameWithMostPropertyCount.Content.ReadAsStringAsync();
        ViewBag.cityNameWithMostPropertyCount = jsonDataCityNameWithMostPropertyCount;
        #endregion
        #region DifferentCityCount
        HttpResponseMessage responseMessageDifferentCityCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/DifferentCityCount");
        string jsonDataDifferentCityCount = await responseMessageDifferentCityCount.Content.ReadAsStringAsync();
        ViewBag.differentCityCount = jsonDataDifferentCityCount;
        #endregion
        #region EstateAgentNameWithMostPropertyCount
        HttpResponseMessage responseMessageEstateAgentNameWithMostPropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/EstateAgentNameWithMostPropertyCount");
        string jsonDataEstateAgentNameWithMostPropertyCount = await responseMessageEstateAgentNameWithMostPropertyCount.Content.ReadAsStringAsync();
        ViewBag.EstateAgentNameWithMostPropertyCount = jsonDataEstateAgentNameWithMostPropertyCount;
        #endregion
        #region LastAddedPropertyPrice
        HttpResponseMessage responseMessageLastAddedPropertyPrice = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/LastAddedPropertyPrice");
        string jsonDataLastAddedPropertyPrice = await responseMessageLastAddedPropertyPrice.Content.ReadAsStringAsync();
        ViewBag.lastAddedPropertyPrice = jsonDataLastAddedPropertyPrice;
        #endregion
        #region NewestBuildingYear
        HttpResponseMessage responseMessageNewestBuildingYear = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/NewestBuildingYear");
        string jsonDataNewestBuildingYear = await responseMessageNewestBuildingYear.Content.ReadAsStringAsync();
        ViewBag.newestBuildingYear = jsonDataNewestBuildingYear;
        #endregion
        #region OldestBuildingYear
        HttpResponseMessage responseMessageOldestBuildingYear = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/OldestBuildingYear");
        string jsonDataOldestBuildingYear = await responseMessageOldestBuildingYear.Content.ReadAsStringAsync();
        ViewBag.oldestBuildingYear = jsonDataOldestBuildingYear;
        #endregion
        #region PassiveCategoryCount
        HttpResponseMessage responseMessagePassiveCategoryCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/PassiveCategoryCount");
        string jsonDataPassiveCategoryCount = await responseMessagePassiveCategoryCount.Content.ReadAsStringAsync();
        ViewBag.passiveCategoryCount = jsonDataPassiveCategoryCount;
        #endregion
        #region PropertyCount
        HttpResponseMessage responseMessagePropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/PropertyCount");
        string jsonDataPropertyCount = await responseMessagePropertyCount.Content.ReadAsStringAsync();
        ViewBag.PropertyCount = jsonDataPropertyCount;
        #endregion

        return View();
    }
}
