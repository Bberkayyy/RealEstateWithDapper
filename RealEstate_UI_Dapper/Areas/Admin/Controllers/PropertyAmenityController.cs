using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Areas.Admin.Models.PropertyAmenityViewModels;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class PropertyAmenityController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public PropertyAmenityController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [HttpGet]
    [Route("SelectPropertyAmenities/{propertyId}")]
    public async Task<IActionResult> SelectPropertyAmenities(int propertyId)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "PropertyAmenities/GetListByPropertyId?propertyId=" + propertyId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultPropertyAmenityViewModel>? value = JsonConvert.DeserializeObject<List<AdminPanelResultPropertyAmenityViewModel>>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("SelectPropertyAmenities/{propertyId}")]
    public async Task<IActionResult> SelectPropertyAmenities(List<AdminPanelResultPropertyAmenityViewModel> adminPanelResultPropertyAmenityViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        foreach (var item in adminPanelResultPropertyAmenityViewModel)
        {
            if (item.DoesHave)
            {
                await client.GetAsync(_apiSettings.BaseUrl + "PropertyAmenities/DoesHaveToTrue?id=" + item.Id);
            }
            else
            {
                await client.GetAsync(_apiSettings.BaseUrl + "PropertyAmenities/DoesHaveToFalse?id=" + item.Id);
            }
        }
        return RedirectToAction("Index", "Property");
    }
}
