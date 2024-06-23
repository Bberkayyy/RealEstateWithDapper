using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Responses;
using RealEstate_Api_Dapper.Repositories.AmenityRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AmenitiesController : ControllerBase
{
    private readonly IAmenityRepository _amenityRepository;

    public AmenitiesController(IAmenityRepository amenityRepository)
    {
        _amenityRepository = amenityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> AmenityList()
    {
        List<GetAllAmenityResponseDto> values = await _amenityRepository.GetAllAmenityAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAmenity(CreateAmenityRequestDto createAmenityRequestDto)
    {
        await _amenityRepository.CreateAmenity(createAmenityRequestDto);
        return Ok("Kolaylık Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAmenity(int id)
    {
        await _amenityRepository.DeleteAmenity(id);
        return Ok("Kolaylık Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAmenity(UpdateAmenityRequestDto updateAmenityRequestDto)
    {
        await _amenityRepository.UpdateAmenity(updateAmenityRequestDto);
        return Ok("Kolaylık Başarılı Bir Şekilde Güncellendi.");
    }
}
