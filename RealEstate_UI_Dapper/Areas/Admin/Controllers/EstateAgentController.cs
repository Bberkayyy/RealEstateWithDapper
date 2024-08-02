using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.EstateAgentViewModels;
using RealEstate_UI_Dapper.Models;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class EstateAgentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public EstateAgentController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultEstateAgentViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultEstateAgentViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateEstateAgent")]
    public IActionResult CreateEstateAgent() { return View(); }
    [HttpPost]
    [Route("CreateEstateAgent")]
    public async Task<IActionResult> CreateEstateAgent(AdminPanelCreateEstateAgentViewModel adminPanelCreateEstateAgentViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateEstateAgentViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "EstateAgents", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "EstateAgent", new { area = "Admin" });
        return View();
    }
    [Route("DeleteEstateAgent/{id}")]
    public async Task<IActionResult> DeleteEstateAgent(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"EstateAgents?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "EstateAgent", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateEstateAgent/{id}")]
    public async Task<IActionResult> UpdateEstateAgent(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"EstateAgents/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateEstateAgentViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdateEstateAgentViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateEstateAgent/{id}")]
    public async Task<IActionResult> UpdateEstateAgent(AdminPanelUpdateEstateAgentViewModel adminPanelUpdateEstateAgentViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateEstateAgentViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "EstateAgents", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "EstateAgent", new { area = "Admin" });
        return View();
    }
}
