using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.BottomGridModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultBottomGridComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultBottomGridComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/BottomGrids");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultBottomGridViewModel> values = JsonConvert.DeserializeObject<List<ResultBottomGridViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
}
