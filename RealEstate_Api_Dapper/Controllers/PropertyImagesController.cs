using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Responses;
using RealEstate_Api_Dapper.Repositories.PropertyImageRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PropertyImagesController : ControllerBase
{
    private readonly IPropertyImageRepository _propertyImageRepository;

    public PropertyImagesController(IPropertyImageRepository propertyImageRepository)
    {
        _propertyImageRepository = propertyImageRepository;
    }
    [HttpGet]
    public async Task<IActionResult> PropertyImageList()
    {
        List<GetAllPropertyImagesResponseDto> values = await _propertyImageRepository.GetAllPropertyImageAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreatePropertyImage(CreatePropertyImageRequestDto createPropertyImageRequestDto)
    {
        await _propertyImageRepository.CreatePropertyImageAsync(createPropertyImageRequestDto);
        return Ok("İlan Fotoğrafı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeletePropertyImage(int id)
    {
        await _propertyImageRepository.DeletePropertyImageAsync(id);
        return Ok("İlan Fotoğrafı Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdatePropertyImage(UpdatePropertyImageRequestDto updatePropertyImageRequestDto)
    {
        await _propertyImageRepository.UpdatePropertyImageAsync(updatePropertyImageRequestDto);
        return Ok("İlan Fotoğrafı Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("GetPropertyImagesByPropertyId")]
    public async Task<IActionResult> GetPropertyImagesByPropertyId(int id)
    {
        List<GetPropertyImagesByPropertyIdResponseDto> value = await _propertyImageRepository.GetPropertyImagesByPropertyIdAsync(id);
        return Ok(value);
    }
}
