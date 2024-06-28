using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Services;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentDashboardStatisticComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;
    private readonly ILoginService _loginService;

    public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
        _apiSettings = apiSettings.Value;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string id = _loginService.Id;
        HttpClient client = _httpClientFactory.CreateClient();
        #region AllProductCount
        HttpResponseMessage responseMessageProductCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/allproductcount");
        string jsonDataProductCount = await responseMessageProductCount.Content.ReadAsStringAsync();
        ViewBag.productCount = jsonDataProductCount;
        #endregion
        #region  EstateAgentProductCount
        HttpResponseMessage responseMessageEstateAgentProductCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/estateagentproductcount?id=" + id);
        string jsonDataEstateAgentProductCount = await responseMessageEstateAgentProductCount.Content.ReadAsStringAsync();
        ViewBag.estateAgentProductCount = jsonDataEstateAgentProductCount;
        #endregion
        #region  EstateAgentActiveProductCount
        HttpResponseMessage responseMessageEstateAgentActiveProductCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/estateagentproductcountbystatustrue?id=" + id);
        string jsonDataEstateAgentActiveProductCount = await responseMessageEstateAgentActiveProductCount.Content.ReadAsStringAsync();
        ViewBag.estateAgentActiveProductCount = jsonDataEstateAgentActiveProductCount;
        #endregion
        #region  EstateAgentActiveProductCount
        HttpResponseMessage responseMessageEstateAgentPassiveProductCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/estateagentproductcountbystatusfalse?id=" + id);
        string jsonDataEstateAgentPassiveProductCount = await responseMessageEstateAgentPassiveProductCount.Content.ReadAsStringAsync();
        ViewBag.estateAgentPassiveProductCount = jsonDataEstateAgentPassiveProductCount;
        #endregion
        return View();
    }
}
