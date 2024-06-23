using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.ProductDetailsModels;
using RealEstate_UI_Dapper.Models.PropertyAmenityModels;

namespace RealEstate_UI_Dapper.ViewComponents.PropertyDetail;

public class _PropertyDetailPropertyAmenitiesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _PropertyDetailPropertyAmenitiesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/PropertyAmenities/GetPropertyAmenityListByPropertyIdAndDoesHaveTrue?productId=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultPropertyAmenityViewModel>? value = JsonConvert.DeserializeObject<List<ResultPropertyAmenityViewModel>>(jsonData);
            return View(value);
        }
        return View();
    }
}