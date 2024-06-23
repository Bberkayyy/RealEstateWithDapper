using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.ProductModels;
using System.Net.Http;

namespace RealEstate_UI_Dapper.ViewComponents.PropertyDetail;

public class _PropertyDetailHeaderComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PropertyDetailHeaderComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Products/GetWithRelationships/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultProductViewModel? value = JsonConvert.DeserializeObject<ResultProductViewModel>(jsonData);
            return View(value);
        }
        return View();
    }
}
