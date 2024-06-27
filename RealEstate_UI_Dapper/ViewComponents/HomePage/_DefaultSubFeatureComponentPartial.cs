using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.ProductModels;
using RealEstate_UI_Dapper.Models.SubFeatureModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultSubFeatureComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/SubFeatures");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultSubFeatureViewModel>? values = JsonConvert.DeserializeObject<List<ResultSubFeatureViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
