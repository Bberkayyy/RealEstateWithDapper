using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.AboutUsSubDetailViewModels;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class AboutUsSubDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutUsSubDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/AboutUsSubDetails");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<AdminPanelResultAboutUsSubDetailViewModel> values = JsonConvert.DeserializeObject<List<AdminPanelResultAboutUsSubDetailViewModel>>(jsonData);
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
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/AboutUsSubDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsSubDetail", new { area = "Admin" });
        return View();
    }
    [Route("DeleteAboutUsSubDetail/{id}")]
    public async Task<IActionResult> DeleteAboutUsSubDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/AboutUsSubDetails?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsSubDetail", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateAboutUsSubDetail/{id}")]
    public async Task<IActionResult> UpdateAboutUsSubDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/AboutUsSubDetails/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            AdminPanelUpdateAboutUsSubDetailViewModel value = JsonConvert.DeserializeObject<AdminPanelUpdateAboutUsSubDetailViewModel>(jsonData);
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
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/AboutUsSubDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "AboutUsSubDetail", new { area = "Admin" });
        return View();
    }
}
