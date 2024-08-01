using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.Admin.Models.CategoryViewModels;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Models.LoginModels;
using RealEstate_UI_Dapper.Models.RegisterModels;
using System.Text;

namespace RealEstate_UI_Dapper.Controllers;

public class RegisterController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public RegisterController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(RegisterUserViewModel registerUserViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsondata = JsonConvert.SerializeObject(registerUserViewModel);
        StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "Registers", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Login");
        return View(registerUserViewModel);
    }
}
