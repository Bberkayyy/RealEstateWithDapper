using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Areas.EstateAgent.Models.ProductViewModels;
using RealEstate_UI_Dapper.Services;

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

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        //var user = User.Claims;
        int id = Int32.Parse(_loginService.Id);
        string? token = User.Claims.FirstOrDefault(x => x.Type == "realEstateToken")?.Value;
        if (token is not null)
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/GetProductListByEmployeeIdWithRelationships?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                List<EstateAgentPanelResultProductViewModel> values = JsonConvert.DeserializeObject<List<EstateAgentPanelResultProductViewModel>>(jsonData);
                return View(values);
            }
        }
        return View();
    }
}
