using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.EmployeeViewModels;
using RealEstate_UI_Dapper.Models;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class EmployeeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public EmployeeController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Employees");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultEmployeeViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultEmployeeViewModel>>(jsonData);
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
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "Employees", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Employee", new { area = "Admin" });
        return View();
    }
    [Route("DeleteEmployee/{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"Employees?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Employee", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateEmployee/{id}")]
    public async Task<IActionResult> UpdateEmployee(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Employees/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateEmployeeViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdateEmployeeViewModel>(jsonData);
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
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "Employees", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Employee", new { area = "Admin" });
        return View();
    }
}
