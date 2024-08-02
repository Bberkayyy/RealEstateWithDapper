using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.ProductViewModels;
using RealEstate_UI_Dapper.Areas.Admin.Models.EstateAgentViewModels;
using System.Text;
using RealEstate_UI_Dapper.Areas.Admin.Models.CategoryViewModels;
using System.Linq;
using RealEstate_UI_Dapper.Models;
using Microsoft.Extensions.Options;
namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public ProductController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Products/ProductListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultProductViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultProductViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.Categories = await GetCategoriesList();
        ViewBag.EstateAgents = await GetEstateAgentsList();
        return View();
    }
    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(AdminPanelCreateProductViewModel adminPanelCreateProductViewModel)
    {
        adminPanelCreateProductViewModel.DealOfTheDay = false;
        adminPanelCreateProductViewModel.IsActive = true;
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateProductViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"Products?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateProductViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdateProductViewModel>(jsonData);
            ViewBag.CategoriesForUpdate = await GetCategoriesList();
            ViewBag.EstateAgentsForUpdate = await GetEstateAgentsList();
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(AdminPanelUpdateProductViewModel adminPanelUpdateProductViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateProductViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("ProductDealOfTheDayStatusChangeToTrue/{id}")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/ProductDealOfTheDayStatusChangeToTrue?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("ProductDealOfTheDayStatusChangeToFalse/{id}")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/ProductDealOfTheDayStatusChangeToFalse?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("ProductIsActiveChangeToTrue/{id}")]
    public async Task<IActionResult> ProductIsActiveChangeToTrue(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/ProductIsActiveChangeToTrue?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("ProductIsActiveChangeToFalse/{id}")]
    public async Task<IActionResult> ProductIsActiveChangeToFalse(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Products/ProductIsActiveChangeToFalse?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
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
