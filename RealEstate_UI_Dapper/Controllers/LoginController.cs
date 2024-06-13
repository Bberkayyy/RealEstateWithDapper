using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealEstate_UI_Dapper.Models.LoginModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate_UI_Dapper.Controllers;

public class LoginController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LoginController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(CreateLoginViewModel createLoginViewModel)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        StringContent content = new(JsonSerializer.Serialize(createLoginViewModel), Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("https://localhost:7221/api/Logins", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            JwtResponseViewModel? tokenModel = JsonSerializer.Deserialize<JwtResponseViewModel>(jsonData, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            if (tokenModel is not null)
            {
                JwtSecurityTokenHandler handler = new();
                JwtSecurityToken token = handler.ReadJwtToken(tokenModel.Token);
                List<Claim> claims = token.Claims.ToList();

                if (tokenModel.Token is not null)
                {
                    claims.Add(new Claim("realEstateToken", tokenModel.Token));
                    ClaimsIdentity claimsIdentity = new(claims, JwtBearerDefaults.AuthenticationScheme);
                    AuthenticationProperties authProps = new()
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };
                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                    return RedirectToAction("Index", "Dashboard", new { area = "EstateAgent" });
                }
            }
        }
        return View();
    }
}
