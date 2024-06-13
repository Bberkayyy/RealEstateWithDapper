using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.CategoryViewModels;
using RealEstate_UI_Dapper.Areas.Admin.Models.ProductViewModels;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.ProductViewModels;
using RealEstate_UI_Dapper.Services;
using System.Text;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.Controllers;

[Area("EstateAgent")]
[Route("EstateAgent/[controller]")]
public class AdvertController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public AdvertController(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    [Route("ActiveAdverts")]
    public async Task<IActionResult> ActiveAdverts()
    {
        //var user = User.Claims;
        int id = Int32.Parse(_loginService.Id);
        string? token = User.Claims.FirstOrDefault(x => x.Type == "realEstateToken")?.Value;
        if (token is not null)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/GetProductListByEmployeeIdAndIsActiveTrueWithRelationships?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<EstateAgentPanelResultAdvertViewModel> values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultAdvertViewModel>>(jsonData);
                return View(values);
            }
        }
        return View();
    }
    [Route("PassiveAdverts")]
    public async Task<IActionResult> PassiveAdverts()
    {
        //var user = User.Claims;
        int id = Int32.Parse(_loginService.Id);
        string? token = User.Claims.FirstOrDefault(x => x.Type == "realEstateToken")?.Value;
        if (token is not null)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/GetProductListByEmployeeIdAndIsActiveFalseWithRelationships?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<EstateAgentPanelResultAdvertViewModel> values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultAdvertViewModel>>(jsonData);
                return View(values);
            }
        }
        return View();
    }
    [HttpGet]
    [Route("CreateAdvert")]
    public async Task<IActionResult> CreateAdvert()
    {
        ViewBag.Categories = await GetCategoriesList();
        return View();
    }
    [HttpPost]
    [Route("CreateAdvert")]
    public async Task<IActionResult> CreateAdvert(EstateAgentPanelCreateAdvertViewModel estateAgentPanelCreateAdvertViewModel)
    {
        estateAgentPanelCreateAdvertViewModel.DealOfTheDay = false;
        estateAgentPanelCreateAdvertViewModel.EmployeeId = Int32.Parse(_loginService.Id);
        estateAgentPanelCreateAdvertViewModel.IsActive = true;
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(estateAgentPanelCreateAdvertViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("ActiveAdverts", "Advert", new { area = "EstateAgent" });
        return View();
    }
    [Route("DeleteAdvert/{id}")]
    public async Task<IActionResult> DeleteAdvert(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:7221/api/Products?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("ActiveAdverts", "Advert", new { area = "EstateAgent" });
        return View();
    }
    [HttpGet]
    [Route("UpdateAdvert/{id}")]
    public async Task<IActionResult> UpdateAdvert(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            EstateAgentPanelUpdateAdvertViewModel value = JsonConvert.DeserializeObject<EstateAgentPanelUpdateAdvertViewModel>(jsonData);
            ViewBag.CategoriesForUpdate = await GetCategoriesList();
            value.EmployeeId = Int32.Parse(_loginService.Id);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateAdvert/{id}")]
    public async Task<IActionResult> UpdateAdvert(EstateAgentPanelUpdateAdvertViewModel estateAgentPanelUpdateAdvertViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(estateAgentPanelUpdateAdvertViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("https://localhost:7221/api/Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("ActiveAdverts", "Advert", new { area = "EstateAgent" });
        return View();
    }
    [Route("AdvertIsActiveChangeToTrue/{id}")]
    public async Task<IActionResult> AdvertIsActiveChangeToTrue(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/ProductIsActiveChangeToTrue?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("ActiveAdverts", "Advert", new { area = "EstateAgent" });
        return View();
    }
    [Route("AdvertIsActiveChangeToFalse/{id}")]
    public async Task<IActionResult> AdvertIsActiveChangeToFalse(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/ProductIsActiveChangeToFalse?id={id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("ActiveAdverts", "Advert", new { area = "EstateAgent" });
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
}
