using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;
using RealEstate_Api_Dapper.Repositories.PropertyRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertiesController(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }
    [HttpGet]
    public async Task<IActionResult> PropertyList()
    {
        List<GetAllPropertyResponseDto> values = await _propertyRepository.GetAllPropertyAsync();
        return Ok(values);
    }
    [HttpGet("PropertyListWithRelationships")]
    public async Task<IActionResult> PropertyListWithRelationships()
    {
        List<GetAllPropertyWithRelationshipsResponseDto> values = await _propertyRepository.GetAllPropertyWithRelationshipsAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProperty(CreatePropertyRequestDto createPropertyRequestDto)
    {
        var createdProperty = await _propertyRepository.CreatePropertyAsync(createPropertyRequestDto);
        return Ok(createdProperty);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProperty(int id)
    {
        await _propertyRepository.DeletePropertyAsync(id);
        return Ok("İlan Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProperty(UpdatePropertyRequestDto updatePropertyRequestDto)
    {
        await _propertyRepository.UpdatePropertyAsync(updatePropertyRequestDto);
        return Ok("İlan Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPropertyById(int id)
    {
        GetPropertyByIdResponseDto value = await _propertyRepository.GetPropertyByIdAsync(id);
        return Ok(value);
    }
    [HttpGet("GetWithRelationships/{id}")]
    public async Task<IActionResult> GetPropertyByIdWithRelationships(int id)
    {
        GetPropertyByIdWithRelationshipsResponseDto value = await _propertyRepository.GetPropertyByIdWithRelationshipsAsync(id);
        return Ok(value);
    }
    [HttpGet("PropertyDealOfTheDayStatusChangeToTrue")]
    public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToTrue(int id)
    {
        await _propertyRepository.PropertyDealOfTheDayStatusChangeToTrueAsync(id);
        return Ok("İlan Günün Fırsatı Olarak Belirlendi.");
    }
    [HttpGet("PropertyDealOfTheDayStatusChangeToFalse")]
    public async Task<IActionResult> PropertyDealOfTheDayStatusChangeToFalse(int id)
    {
        await _propertyRepository.PropertyDealOfTheDayStatusChangeToFalseAsync(id);
        return Ok("İlan Günün Fırsatlarından Çıkarıldı.");
    }
    [HttpGet("Last5PropertyList")]
    public async Task<IActionResult> Last5PropertyList()
    {
        List<GetLast5PropertyResponseDto> value = await _propertyRepository.GetLast5PropertyAsync();
        return Ok(value);
    }
    [HttpGet("Last5PropertyListWithRelationships")]
    public async Task<IActionResult> Last5PropertyListWithRelationships()
    {
        List<GetLast5PropertyWithRelationshipsResponseDto> value = await _propertyRepository.GetLast5PropertyWithRelationshipsAsync();
        return Ok(value);
    }
    [HttpGet("Last3PropertyList")]
    public async Task<IActionResult> Last3PropertyList()
    {
        List<GetLast3PropertyResponseDto> value = await _propertyRepository.GetLast3PropertyAsync();
        return Ok(value);
    }
    [HttpGet("Last3PropertyListWithRelationships")]
    public async Task<IActionResult> Last3PropertyListWithRelationships()
    {
        List<GetLast3PropertyWithRelationshipsResponseDto> value = await _propertyRepository.GetLast3PropertyWithRelationshipsAsync();
        return Ok(value);
    }
    [HttpGet("GetPropertyListByEstateAgentIdAndIsActiveTrue")]
    public async Task<IActionResult> GetPropertyListByEstateAgentIdAndIsActiveTrue(int id)
    {
        List<GetPropertyListByEstateAgentIdResponseDto> values = await _propertyRepository.GetPropertyListByEstateAgentIdAndIsActiveTrueAsync(id);
        return Ok(values);
    }
    [HttpGet("GetPropertyListByEstateAgentIdAndIsActiveTrueWithRelationships")]
    public async Task<IActionResult> GetPropertyListByEstateAgentIdAndIsActiveTrueWithRelationships(int id)
    {
        List<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto> values = await _propertyRepository.GetPropertyListByEstateAgentIdAndIsActiveTrueWithRelationshipsAsync(id);
        return Ok(values);
    }
    [HttpGet("GetPropertyListByEstateAgentIdAndIsActiveFalse")]
    public async Task<IActionResult> GetPropertyListByEstateAgentIdAndIsActiveFalse(int id)
    {
        List<GetPropertyListByEstateAgentIdResponseDto> values = await _propertyRepository.GetPropertyListByEstateAgentIdAndIsActiveFalseAsync(id);
        return Ok(values);
    }
    [HttpGet("GetPropertyListByEstateAgentIdAndIsActiveFalseWithRelationships")]
    public async Task<IActionResult> GetPropertyListByEstateAgentIdAndIsActiveFalseWithRelationships(int id)
    {
        List<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto> values = await _propertyRepository.GetPropertyListByEstateAgentIdAndIsActiveFalseWithRelationshipsAsync(id);
        return Ok(values);
    }
    [HttpGet("PropertyIsActiveChangeToTrue")]
    public async Task<IActionResult> PropertyIsActiveChangeToTrue(int id)
    {
        await _propertyRepository.PropertyIsActiveChangeToTrueAsync(id);
        return Ok("İlan durumu aktif olarak değiştirildi.");
    }
    [HttpGet("PropertyIsActiveChangeToFalse")]
    public async Task<IActionResult> PropertyIsActiveChangeToFalse(int id)
    {
        await _propertyRepository.PropertyIsActiveChangeToFalseAsync(id);
        return Ok("İlan durumu pasif olarak değiştirildi.");
    }
    [HttpGet("PropertyListBySearchFilterWithRelationships")]
    public async Task<IActionResult> PropertyListBySearchFilterWithRelationships(string containsWord, int categoryId, string city)
    {
        List<GetPropertyListBySearchFilterWithRelationshipsResponseDto> values = await _propertyRepository.GetPropertyListBySearchFilterWithRelationshipsAsync(containsWord, categoryId, city);
        return Ok(values);
    }
    [HttpGet("PropertyListByDealOfTheDayTrueWithRelationships")]
    public async Task<IActionResult> GetPropertyListByDealOfTheDayTrueWithRelationshipsAsync()
    {
        List<GetPropertyListByDealOfTheDayTrueWithRelationshipsResponseDto> values = await _propertyRepository.GetPropertyListByDealOfTheDayTrueWithRelationshipsAsync();
        return Ok(values);
    }
}
