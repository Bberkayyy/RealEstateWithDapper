using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Responses;
using RealEstate_Api_Dapper.Repositories.PropertyAmenityRepositoryies;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyAmenitiesController : ControllerBase
{
    private readonly IPropertyAmenityRepository _propertyAmenityRepository;

    public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
    {
        _propertyAmenityRepository = propertyAmenityRepository;
    }
    [HttpGet("GetPropertyAmenityListByPropertyIdAndDoesHaveTrue")]
    public async Task<IActionResult> GetPropertyAmenityListByPropertyIdAndDoesHaveTrue(int propertyId)
    {
        List<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto> values = await _propertyAmenityRepository.GetPropertyAmenityListByPropertyIdAndDoesHaveTrueAsync(propertyId);
        return Ok(values);
    }
    [HttpGet("GetListByPropertyId")]
    public async Task<IActionResult> GetPropertyAmenityListByPropertyId(int propertyId)
    {
        List<GetPropertyAmenityListByPropertyIdResponseDto> values = await _propertyAmenityRepository.GetPropertyAmenityListByPropertyIdAsync(propertyId);
        return Ok(values);
    }
    [HttpGet("DoesHaveToTrue")]
    public async Task<IActionResult> PropertyAmenityChangeDoesHaveToTrue(int id)
    {
        await _propertyAmenityRepository.PropertyAmenityChangeDoesHaveToTrueAsync(id);
        return Ok("Özellik mevcut olarak değiştirildi.");
    }
    [HttpGet("DoesHaveToFalse")]
    public async Task<IActionResult> PropertyAmenityChangeDoesHaveToFalse(int id)
    {
        await _propertyAmenityRepository.PropertyAmenityChangeDoesHaveToFalseAsync(id);
        return Ok("Özellik mevcut değil olarak değiştirildi.");
    }
}
