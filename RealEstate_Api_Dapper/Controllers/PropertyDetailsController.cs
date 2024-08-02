using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;
using RealEstate_Api_Dapper.Repositories.PropertyDetailRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyDetailsController : ControllerBase
{
    private readonly IPropertyDetailRepository _propertyDetailRepository;

    public PropertyDetailsController(IPropertyDetailRepository propertyDetailRepository)
    {
        _propertyDetailRepository = propertyDetailRepository;
    }

    [HttpGet("GetByPropertyId")]
    public async Task<IActionResult> GetPropertyDetailsByPropertyId(int id)
    {
        GetPropertyDetailByPropertyIdResponseDto value = await _propertyDetailRepository.GetPropertyDetailByPropertyIdAsync(id);
        return Ok(value);
    }
}
