using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.LocationViewModels;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class LocationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LocationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Locations");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultLocationViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultLocationViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateLocation")]
    public IActionResult CreateLocation() { return View(); }
    [HttpPost]
    [Route("CreateLocation")]
    public async Task<IActionResult> CreateLocation(AdminPanelCreateLocationViewModel adminPanelCreateLocationViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateLocationViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/Locations", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Location", new { area = "Admin" });
        return View();
    }
    [Route("DeleteLocation/{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/Locations?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Location", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Locations/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateLocationViewModel value = JsonConvert.DeserializeObject<AdminPanelUpdateLocationViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateLocation/{id}")]
    public async Task<IActionResult> UpdateLocation(AdminPanelUpdateLocationViewModel adminPanelUpdateLocationViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateLocationViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/Locations", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Location", new { area = "Admin" });
        return View();
    }
}
