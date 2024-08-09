using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Responses;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;
using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Requests;
using RealEstate_Api_Dapper.Repositories.AmenityRepositories;
using RealEstate_Api_Dapper.Repositories.PropertyAmenityRepositoryies;
using RealEstate_Api_Dapper.Repositories.PropertyDetailRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyDetailsController : ControllerBase
{
    private readonly IPropertyDetailRepository _propertyDetailRepository;
    private readonly IAmenityRepository _amenityRepository;
    private readonly IPropertyAmenityRepository _propertyAmenityRepository;

    public PropertyDetailsController(IPropertyDetailRepository propertyDetailRepository, IAmenityRepository amenityRepository, IPropertyAmenityRepository propertyAmenityRepository)
    {
        _propertyDetailRepository = propertyDetailRepository;
        _amenityRepository = amenityRepository;
        _propertyAmenityRepository = propertyAmenityRepository;
    }
    [HttpPost]
    public async Task<IActionResult> CreatePropertyDetail(CreatePropertyDetailRequestDto createPropertyDetailRequestDto)
    {
        await _propertyDetailRepository.CreatePropertyDetailAsync(createPropertyDetailRequestDto);
        List<GetAllAmenityResponseDto> amenities = await _amenityRepository.GetAllAmenityAsync();
        foreach (var item in amenities)
        {
            await _propertyAmenityRepository.CreatePropertyAmenityAsync(new CreatePropertyAmenityRequestDto()
            {
                AmenityId = item.Id,
                PropertyId = createPropertyDetailRequestDto.PropertyId,
                DoesHave = false
            });
        }
        return Ok("İlan Detayı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeletePropertyDetail(int id)
    {
        await _propertyDetailRepository.DeletePropertyDetailAsync(id);
        return Ok("İlan Detayı Başarılı Bir Şekilde Silindi.");
    }
    [HttpGet("GetByPropertyId")]
    public async Task<IActionResult> GetPropertyDetailsByPropertyId(int id)
    {
        GetPropertyDetailByPropertyIdResponseDto value = await _propertyDetailRepository.GetPropertyDetailByPropertyIdAsync(id);
        return Ok(value);
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePropertyDetail(UpdatePropertyDetailRequestDto updatePropertyDetailRequestDto)
    {
        await _propertyDetailRepository.UpdatePropertyDetailAsync(updatePropertyDetailRequestDto);
        return Ok("İlan Detayı Başarılı Bir Şekilde Güncellendi.");

    }
}
