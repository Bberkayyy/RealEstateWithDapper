using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.EmployeeViewModels;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class EmployeeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Employees");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultEmployeeViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultEmployeeViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateEmployee")]
    public IActionResult CreateEmployee() { return View(); }
    [HttpPost]
    [Route("CreateEmployee")]
    public async Task<IActionResult> CreateEmployee(AdminPanelCreateEmployeeViewModel adminPanelCreateEmployeeViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateEmployeeViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/Employees", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Employee", new { area = "Admin" });
        return View();
    }
    [Route("DeleteEmployee/{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/Employees?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Employee", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateEmployee/{id}")]
    public async Task<IActionResult> UpdateEmployee(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Employees/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateEmployeeViewModel value = JsonConvert.DeserializeObject<AdminPanelUpdateEmployeeViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateEmployee/{id}")]
    public async Task<IActionResult> UpdateEmployee(AdminPanelUpdateEmployeeViewModel adminPanelUpdateEmployeeViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateEmployeeViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/Employees", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Employee", new { area = "Admin" });
        return View();
    }
}
