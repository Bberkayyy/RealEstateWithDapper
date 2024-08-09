using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.PropertyDetailViewModels;
using RealEstate_UI_Dapper.Areas.Admin.Models.PropertyViewModels;
using RealEstate_UI_Dapper.Models;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class PropertyDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public PropertyDetailController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [HttpGet]
    [Route("CreatePropertyDetail/{propertyId}")]
    public IActionResult CreatePropertyDetail(int propertyId)
    {
        ViewBag.propertyId = propertyId;
        return View();
    }
    [HttpPost]
    [Route("CreatePropertyDetail/{propertyId}")]
    public async Task<IActionResult> CreatePropertyDetail(AdminPanelCreatePropertyDetailViewModel adminPanelCreatePropertyDetailViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreatePropertyDetailViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "PropertyDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("SelectPropertyAmenities", "PropertyAmenity", new { area = "Admin", propertyId = adminPanelCreatePropertyDetailViewModel.PropertyId });
        return View();
    }
    [HttpGet]
    [Route("UpdatePropertyDetail/{propertyId}")]
    public async Task< IActionResult> UpdatePropertyDetail(int propertyId)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"PropertyDetails/GetByPropertyId?id={propertyId}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdatePropertyDetailViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdatePropertyDetailViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdatePropertyDetail/{propertyId}")]
    public async Task<IActionResult> UpdatePropertyDetail(AdminPanelUpdatePropertyDetailViewModel adminPanelUpdatePropertyDetailViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdatePropertyDetailViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "PropertyDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin"});
        return View();
    }
}
