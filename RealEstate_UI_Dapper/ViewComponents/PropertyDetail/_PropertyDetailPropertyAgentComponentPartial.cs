using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.EstateAgentModels;
using RealEstate_UI_Dapper.Models.PropertyAmenityModels;
using RealEstate_UI_Dapper.Models.PropertyModels;

namespace RealEstate_UI_Dapper.ViewComponents.PropertyDetail;

public class _PropertyDetailPropertyAgentComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PropertyDetailPropertyAgentComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        int estateAgentId = await GetEstateAgentIdFromProperty(id);
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/EstateAgents/" + estateAgentId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultEstateAgentViewModel? value = JsonConvert.DeserializeObject<ResultEstateAgentViewModel>(jsonData);
            return View(value);
        }
        return View();
    }

    private async Task<int> GetEstateAgentIdFromProperty(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Properties/" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultPropertyViewModel? property = JsonConvert.DeserializeObject<ResultPropertyViewModel>(jsonData);
            return property.estateAgentId;
        }
        return 0;
    }
}
