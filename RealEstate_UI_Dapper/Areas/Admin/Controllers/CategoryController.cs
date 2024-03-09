using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.CategoryViewModels;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultCategoryViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultCategoryViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateCategory")]
    public IActionResult CreateCategory() { return View(); }
    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(AdminPanelCreateCategoryViewModel adminPanelCreateCategoryViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateCategoryViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/Categories", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        return View();
    }
    [Route("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/Categories?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Categories/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateCategoryViewModel value = JsonConvert.DeserializeObject<AdminPanelUpdateCategoryViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(AdminPanelUpdateCategoryViewModel adminPanelUpdateCategoryViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateCategoryViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/Categories", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        return View();
    }
}
