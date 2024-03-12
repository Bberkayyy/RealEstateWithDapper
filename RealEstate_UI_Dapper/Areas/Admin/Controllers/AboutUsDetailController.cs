using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.AboutUsDetailViewModels;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class AboutUsDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutUsDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/AboutUsDetails");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultAboutUsDetailViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultAboutUsDetailViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateAboutUsDetail")]
    public IActionResult CreateAboutUsDetail() { return View(); }
    [HttpPost]
    [Route("CreateAboutUsDetail")]
    public async Task<IActionResult> CreateAboutUsDetail(AdminPanelCreateAboutUsDetailViewModel adminPanelCreateAboutUsDetailViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelCreateAboutUsDetailViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/AboutUsDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsDetail", new { area = "Admin" });
        return View();
    }
    [Route("DeleteAboutUsDetail/{id}")]
    public async Task<IActionResult> DeleteAboutUsDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/AboutUsDetails?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsDetail", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateAboutUsDetail/{id}")]
    public async Task<IActionResult> UpdateAboutUsDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/AboutUsDetails/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateAboutUsDetailViewModel value = JsonConvert.DeserializeObject<AdminPanelUpdateAboutUsDetailViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateAboutUsDetail/{id}")]
    public async Task<IActionResult> UpdateAboutUsDetail(AdminPanelUpdateAboutUsDetailViewModel adminPanelUpdateAboutUsDetailViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(adminPanelUpdateAboutUsDetailViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/AboutUsDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsDetail", new { area = "Admin" });
        return View();
    }
}
