using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.BottomGridViewModels;
using RealEstate_UI_Dapper.Models;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class BottomGridController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public BottomGridController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "BottomGrids");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultBottomGridViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultBottomGridViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateBottomGrid")]
    public IActionResult CreateBottomGrid() { return View(); }
    [HttpPost]
    [Route("CreateBottomGrid")]
    public async Task<IActionResult> CreateBottomGrid(AdminPanelCreateBottomGridViewModel adminPanelCreateBottomGridViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateBottomGridViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "BottomGrids", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "BottomGrid", new { area = "Admin" });
        return View();
    }
    [Route("DeleteBottomGrid/{id}")]
    public async Task<IActionResult> DeleteBottomGrid(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"BottomGrids?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "BottomGrid", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateBottomGrid/{id}")]
    public async Task<IActionResult> UpdateBottomGrid(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"BottomGrids/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateBottomGridViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdateBottomGridViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateBottomGrid/{id}")]
    public async Task<IActionResult> UpdateBottomGrid(AdminPanelUpdateBottomGridViewModel adminPanelUpdateBottomGridViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateBottomGridViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "BottomGrids", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "BottomGrid", new { area = "Admin" });
        return View();
    }
}
