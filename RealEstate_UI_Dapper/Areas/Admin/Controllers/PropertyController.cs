using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.PropertyViewModels;
using RealEstate_UI_Dapper.Areas.Admin.Models.EstateAgentViewModels;
using System.Text;
using RealEstate_UI_Dapper.Areas.Admin.Models.CategoryViewModels;
using System.Linq;
using RealEstate_UI_Dapper.Models;
using Microsoft.Extensions.Options;
namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class PropertyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Properties/PropertyListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultPropertyViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultPropertyViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateProperty")]
    public async Task<IActionResult> CreateProperty()
    {
        ViewBag.Categories = await GetCategoriesList();
        ViewBag.EstateAgents = await GetEstateAgentsList();
        return View();
    }
    [HttpPost]
    [Route("CreateProperty")]
    public async Task<IActionResult> CreateProperty(AdminPanelCreatePropertyViewModel adminPanelCreatePropertyViewModel)
    {
        adminPanelCreatePropertyViewModel.DealOfTheDay = false;
        adminPanelCreatePropertyViewModel.IsActive = true;
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreatePropertyViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "Properties", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelResultPropertyViewModel? createdProperty = JsonConvert.DeserializeObject<AdminPanelResultPropertyViewModel>(jsonData);
            return RedirectToAction("CreatePropertyDetail", "PropertyDetail", new { area = "Admin", propertyId = createdProperty.id });
        }
        return View();
    }    
    [Route("DeleteProperty/{id}")]
    public async Task<IActionResult> DeleteProperty(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"Properties?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateProperty/{id}")]
    public async Task<IActionResult> UpdateProperty(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Properties/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdatePropertyViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdatePropertyViewModel>(jsonData);
            ViewBag.CategoriesForUpdate = await GetCategoriesList();
            ViewBag.EstateAgentsForUpdate = await GetEstateAgentsList();
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateProperty/{id}")]
    public async Task<IActionResult> UpdateProperty(AdminPanelUpdatePropertyViewModel adminPanelUpdatePropertyViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdatePropertyViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "Properties", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin" });
        return View();
    }
    [Route("PropertyDealOfTheDayStatusChangeToTrue/{id}")]
    public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToTrue(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Properties/PropertyDealOfTheDayStatusChangeToTrue?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin" });
        return View();
    }
    [Route("PropertyDealOfTheDayStatusChangeToFalse/{id}")]
    public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToFalse(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Properties/PropertyDealOfTheDayStatusChangeToFalse?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin" });
        return View();
    }
    [Route("PropertyIsActiveChangeToTrue/{id}")]
    public async Task<IActionResult> PropertyIsActiveChangeToTrue(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Properties/PropertyIsActiveChangeToTrue?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin" });
        return View();
    }
    [Route("PropertyIsActiveChangeToFalse/{id}")]
    public async Task<IActionResult> PropertyIsActiveChangeToFalse(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Properties/PropertyIsActiveChangeToFalse?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Property", new { area = "Admin" });
        return View();
    }

    private async Task<List<SelectListItem>> GetCategoriesList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Categories");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<AdminPanelResultCategoryViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultCategoryViewModel>>(jsonData);
        List<SelectListItem> categories = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.name,
                                               Value = x.id.ToString()
                                           }).ToList();
        return categories;
    }

    private async Task<List<SelectListItem>> GetEstateAgentsList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<AdminPanelResultEstateAgentViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultEstateAgentViewModel>>(jsonData);
        List<SelectListItem> EstateAgents = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.fullName,
                                                 Value = x.id.ToString()
                                             }).ToList();
        return EstateAgents;
    }
}
