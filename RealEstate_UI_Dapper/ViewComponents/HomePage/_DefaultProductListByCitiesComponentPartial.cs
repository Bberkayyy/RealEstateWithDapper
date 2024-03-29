﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.LocationModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultProductListByCitiesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultProductListByCitiesComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Locations");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultLocationViewModels> values = JsonConvert.DeserializeObject<List<ResultLocationViewModels>>(jsonData);
            return View(values);
        }
        return View();
    }
}
