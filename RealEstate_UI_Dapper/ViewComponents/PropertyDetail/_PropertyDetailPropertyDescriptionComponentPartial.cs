using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.PropertyModels;
using System.Net.Http;
using RealEstate_UI_Dapper.Models.PropertyDetailsModels;

namespace RealEstate_UI_Dapper.ViewComponents.PropertyDetail;

public class _PropertyDetailPropertyDescriptionComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PropertyDetailPropertyDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Properties/GetWithRelationships/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultPropertyWithRelationshipsViewModel? value = JsonConvert.DeserializeObject<ResultPropertyWithRelationshipsViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
}
