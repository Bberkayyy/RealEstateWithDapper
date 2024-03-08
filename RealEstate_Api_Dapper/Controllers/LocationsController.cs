using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.LocationDtos.Requests;
using RealEstate_Api_Dapper.Dtos.LocationDtos.Responses;
using RealEstate_Api_Dapper.Repositories.LocationRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController : ControllerBase
{
    private readonly ILocationRepository _locationRepository;

    public LocationsController(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    [HttpGet]
    public async Task<IActionResult> LocationList()
    {
        List<GetAllLocationResponseDto> values = await _locationRepository.GetAllLocationAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateLocation(CreateLocationRequestDto createLocationRequestDto)
    {
        _locationRepository.CreateLocation(createLocationRequestDto);
        return Ok("Lokasyon Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        _locationRepository.DeleteLocation(id);
        return Ok("Lokasyon Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateLocation(UpdateLocationRequestDto updateLocationRequestDto)
    {
        _locationRepository.UpdateLocation(updateLocationRequestDto);
        return Ok("Lokasyon Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLocationById(int id)
    {
        GetLocationByIdResponseDto value = await _locationRepository.GetLocationByIdAsync(id);
        return Ok(value);
    }
}
