using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Responses;
using RealEstate_Api_Dapper.Repositories.EstateAgentRepositories;
using RealEstate_Api_Dapper.Repositories.EstateAgentRepositories.DashboardRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstateAgentsController : ControllerBase
{
    private readonly IEstateAgentDashboardRepository _estateAgentDashboardStatisticRepository;
    private readonly IEstateAgentRepository _estateAgentRepository;

    public EstateAgentsController(IEstateAgentDashboardRepository estateAgentDashboardStatisticRepository, IEstateAgentRepository estateAgentRepository)
    {
        _estateAgentDashboardStatisticRepository = estateAgentDashboardStatisticRepository;
        _estateAgentRepository = estateAgentRepository;
    }
    [HttpGet]
    public async Task<IActionResult> EstateAgentList()
    {
        List<GetAllEstateAgentResponseDto> values = await _estateAgentRepository.GetAllEstateAgentAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateEstateAgent(CreateEstateAgentRequestDto createEstateAgentRequestDto)
    {
        await _estateAgentRepository.CreateEstateAgentAsync(createEstateAgentRequestDto);
        return Ok("Emlakçı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteEstateAgent(int id)
    {
        await _estateAgentRepository.DeleteEstateAgentAsync(id);
        return Ok("Emlakçı Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateEstateAgent(UpdateEstateAgentRequestDto updateEstateAgentRequestDto)
    {
        await _estateAgentRepository.UpdateEstateAgentAsync(updateEstateAgentRequestDto);
        return Ok("Emlakçı Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEstateAgentById(int id)
    {
        GetEstateAgentByIdResponseDto value = await _estateAgentRepository.GetEstateAgentByIdAsync(id);
        return Ok(value);
    }
    [HttpGet("estateagentpropertycount")]
    public IActionResult GetEstateAgentProperty(int id)
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetEstateAgentPropertyCount(id));
    }
    [HttpGet("estateagentpropertycountbystatusfalse")]
    public IActionResult GetEstateAgentPropertyByStatusFalse(int id)
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetEstateAgentPropertyCountByStatusFalse(id));
    }
    [HttpGet("estateagentpropertycountbystatustrue")]
    public IActionResult GetEstateAgentPropertyByStatusTrue(int id)
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetEstateAgentPropertyCountByStatusTrue(id));
    }
    [HttpGet("allpropertycount")]
    public IActionResult GetAllPropertyCount()
    {
        return Ok(_estateAgentDashboardStatisticRepository.GetPropertyCount());
    }
    [HttpGet("fivecityforchart")]
    public async Task<IActionResult> Get5CityForChart()
    {
        return Ok(await _estateAgentDashboardStatisticRepository.Get5CityForChart());
    }
    [HttpGet("last5property")]
    public async Task<IActionResult> GetEstateAgentLast5Property(int id)
    {
        return Ok(await _estateAgentDashboardStatisticRepository.GetEstateAgentLast5Property(id));
    } 
    [HttpGet("last3property")]
    public async Task<IActionResult> GetEstateAgentLast3Property(int id)
    {
        return Ok(await _estateAgentDashboardStatisticRepository.GetEstateAgentLast3ActiveProperty(id));
    }
}
