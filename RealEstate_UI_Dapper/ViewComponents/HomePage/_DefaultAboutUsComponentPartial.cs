using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.AboutUsDetailModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultAboutUsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultAboutUsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/AboutUsDetails");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultAboutUsDetailViewModel> value = JsonConvert.DeserializeObject<List<ResultAboutUsDetailViewModel>>(jsonData);
            ViewBag.Title = value.Select(x => x.title).FirstOrDefault();
            ViewBag.Subtitle = value.Select(x => x.subtitle).FirstOrDefault();
            ViewBag.Description1 = value.Select(x => x.description1).FirstOrDefault();
            ViewBag.Description2 = value.Select(x => x.description2).FirstOrDefault();
            return View();
        }
        return View();
    }
}
