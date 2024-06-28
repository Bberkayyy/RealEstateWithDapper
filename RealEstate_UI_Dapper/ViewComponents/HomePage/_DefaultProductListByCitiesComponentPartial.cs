﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Models.LocationModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultProductListByCitiesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public _DefaultProductListByCitiesComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Locations");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultLocationViewModels> values = JsonConvert.DeserializeObject<List<ResultLocationViewModels>>(jsonData);
            return View(values);
        }
        return View();
    }
}
