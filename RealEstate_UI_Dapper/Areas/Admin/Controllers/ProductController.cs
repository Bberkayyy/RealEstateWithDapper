using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.ProductViewModels;
using RealEstate_UI_Dapper.Areas.Admin.Models.EmployeeViewModels;
using System.Text;
using RealEstate_UI_Dapper.Areas.Admin.Models.CategoryViewModels;
using System.Linq;
namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Products/ProductListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultProductViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultProductViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.Categories = await GetCategoriesList();
        ViewBag.Employees = await GetEmployeesList();
        return View();
    }
    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(AdminPanelCreateProductViewModel adminPanelCreateProductViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateProductViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/Products?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateProductViewModel value = JsonConvert.DeserializeObject<AdminPanelUpdateProductViewModel>(jsonData);
            ViewBag.CategoriesForUpdate = await GetCategoriesList();
            ViewBag.EmployeesForUpdate = await GetEmployeesList();
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
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }

    private async Task<List<SelectListItem>> GetCategoriesList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Categories");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<AdminPanelResultCategoryViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultCategoryViewModel>>(jsonData);
        List<SelectListItem> categories = (from x in values
                                           select new SelectListItem
                                           {
                                               Text = x.name,
                                               Value = x.id.ToString()
                                           }).ToList();
        return categories;
    }
    private async Task<List<SelectListItem>> GetEmployeesList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Employees");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<AdminPanelResultEmployeeViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultEmployeeViewModel>>(jsonData);
        List<SelectListItem> employees = (from x in values
                                          select new SelectListItem
                                          {
                                              Text = x.fullName,
                                              Value = x.id.ToString()
                                          }).ToList();
        return employees;
    }
}
