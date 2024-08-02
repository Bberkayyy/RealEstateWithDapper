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
        #region AllPropertyCount
        HttpResponseMessage responseMessagePropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/allpropertycount");
        string jsonDataPropertyCount = await responseMessagePropertyCount.Content.ReadAsStringAsync();
        ViewBag.propertyCount = jsonDataPropertyCount;
        #endregion
        #region  EstateAgentPropertyCount
        HttpResponseMessage responseMessageEstateAgentPropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/estateagentpropertycount?id=" + id);
        string jsonDataEstateAgentPropertyCount = await responseMessageEstateAgentPropertyCount.Content.ReadAsStringAsync();
        ViewBag.estateAgentPropertyCount = jsonDataEstateAgentPropertyCount;
        #endregion
        #region  EstateAgentActivePropertyCount
        HttpResponseMessage responseMessageEstateAgentActivePropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/estateagentpropertycountbystatustrue?id=" + id);
        string jsonDataEstateAgentActivePropertyCount = await responseMessageEstateAgentActivePropertyCount.Content.ReadAsStringAsync();
        ViewBag.estateAgentActivePropertyCount = jsonDataEstateAgentActivePropertyCount;
        #endregion
        #region  EstateAgentActivePropertyCount
        HttpResponseMessage responseMessageEstateAgentPassivePropertyCount = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgents/estateagentpropertycountbystatusfalse?id=" + id);
        string jsonDataEstateAgentPassivePropertyCount = await responseMessageEstateAgentPassivePropertyCount.Content.ReadAsStringAsync();
        ViewBag.estateAgentPassivePropertyCount = jsonDataEstateAgentPassivePropertyCount;
        #endregion
        return View();
    }
}
