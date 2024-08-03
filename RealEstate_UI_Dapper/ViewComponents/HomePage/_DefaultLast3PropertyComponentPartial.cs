using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Models.PropertyModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultLast3PropertyComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public _DefaultLast3PropertyComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Properties/Last3PropertyListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultPropertyWithRelationshipsViewModel>? values = JsonConvert.DeserializeObject<List<ResultPropertyWithRelationshipsViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
