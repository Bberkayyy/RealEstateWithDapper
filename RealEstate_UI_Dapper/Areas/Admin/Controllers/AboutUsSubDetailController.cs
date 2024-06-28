using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.AboutUsSubDetailViewModels;
using RealEstate_UI_Dapper.Models;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class AboutUsSubDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public AboutUsSubDetailController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "AboutUsSubDetails");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultAboutUsSubDetailViewModel>? values = JsonConvert.DeserializeObject<List<AdminPanelResultAboutUsSubDetailViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateAboutUsSubDetail")]
    public IActionResult CreateAboutUsSubDetail() { return View(); }
    [HttpPost]
    [Route("CreateAboutUsSubDetail")]
    public async Task<IActionResult> CreateAboutUsSubDetail(AdminPanelCreateAboutUsSubDetailViewModel adminPanelCreateAboutUsSubDetailViewModel)
    {
        adminPanelCreateAboutUsSubDetailViewModel.Status = true;
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateAboutUsSubDetailViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "AboutUsSubDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsSubDetail", new { area = "Admin" });
        return View();
    }
    [Route("DeleteAboutUsSubDetail/{id}")]
    public async Task<IActionResult> DeleteAboutUsSubDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"AboutUsSubDetails?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsSubDetail", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateAboutUsSubDetail/{id}")]
    public async Task<IActionResult> UpdateAboutUsSubDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"AboutUsSubDetails/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateAboutUsSubDetailViewModel? value = JsonConvert.DeserializeObject<AdminPanelUpdateAboutUsSubDetailViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateAboutUsSubDetail/{id}")]
    public async Task<IActionResult> UpdateAboutUsSubDetail(AdminPanelUpdateAboutUsSubDetailViewModel adminPanelUpdateAboutUsSubDetailViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateAboutUsSubDetailViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "AboutUsSubDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsSubDetail", new { area = "Admin" });
        return View();
    }
}
