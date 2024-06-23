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
    public async Task<IActionResult> GetPropertyAmenityListByPropertyIdAndDoesHaveTrue(int productId)
    {
        List<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto> values = await _propertyAmenityRepository.GetPropertyAmenityListByPropertyIdAndDoesHaveTrueAsync(productId);
        return Ok(values);
    }
}
