using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos;
using RealEstate_Api_Dapper.Repositories.EstateAgentRepositories.DashboardRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstateAgentsController : ControllerBase
{
    private readonly IEstateAgentDashboardRepository _estateAgentDashboardStatisticRepository;

    public EstateAgentsController(IEstateAgentDashboardRepository estateAgentDashboardStatisticRepository)
    {
        _estateAgentDashboardStatisticRepository = estateAgentDashboardStatisticRepository;
    }
    [HttpGet("estateagentproductcount")]
    public IActionResult GetEstateAgentProduct(int id)
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetEstateAgentProductCount(id));
    }
    [HttpGet("estateagentproductcountbystatusfalse")]
    public IActionResult GetEstateAgentProductByStatusFalse(int id)
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetEstateAgentProductCountByStatusFalse(id));
    }
    [HttpGet("estateagentproductcountbystatustrue")]
    public IActionResult GetEstateAgentProductByStatusTrue(int id)
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetEstateAgentProductCountByStatusTrue(id));
    }
    [HttpGet("allproductcount")]
    public IActionResult GetAllProductCount()
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetProductCount());
    }
    [HttpGet("fivecityforchart")]
    public async Task<IActionResult> Get5CityForChart()
    {
        return Ok(await _estateAgentDashboardStatisticRepository.Get5CityForChart());
    }
    [HttpGet("last5product")]
    public async Task<IActionResult> GetEstateAgentLast5Product(int id)
    {
        return Ok(await _estateAgentDashboardStatisticRepository.GetEstateAgentLast5Product(id));
    }
}
