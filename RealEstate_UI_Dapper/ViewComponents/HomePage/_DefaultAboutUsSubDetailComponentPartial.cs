using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.AboutUsDetailModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultAboutUsSubDetailComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultAboutUsSubDetailComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/AboutUsSubDetails");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultAboutUsSubDetailViewModel> values = JsonConvert.DeserializeObject<List<ResultAboutUsSubDetailViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
