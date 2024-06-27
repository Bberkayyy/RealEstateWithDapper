using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Requests;
using RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Responses;
using RealEstate_Api_Dapper.Repositories.SubFeatureRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubFeaturesController : ControllerBase
{
    private readonly ISubFeatureRepository _subFeatureRepository;

    public SubFeaturesController(ISubFeatureRepository SubFeatureRepository)
    {
        _subFeatureRepository = SubFeatureRepository;
    }
    [HttpGet]
    public async Task<IActionResult> SubFeatureList()
    {
        List<GetAllSubFeatureResponseDto> values = await _subFeatureRepository.GetAllSubFeatureAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateSubFeature(CreateSubFeatureRequestDto createSubFeatureRequestDto)
    {
        await _subFeatureRepository.CreateSubFeatureAsync(createSubFeatureRequestDto);
        return Ok("Alt Özellik Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteSubFeature(int id)
    {
        await _subFeatureRepository.DeleteSubFeatureAsync(id);
        return Ok("Alt Özellik Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateSubFeature(UpdateSubFeatureRequestDto updateSubFeatureRequestDto)
    {
        await _subFeatureRepository.UpdateSubFeatureAsync(updateSubFeatureRequestDto);
        return Ok("Alt Özellik Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubFeatureById(int id)
    {
        GetSubFeatureByIdResponseDto value = await _subFeatureRepository.GetSubFeatureByIdAsync(id);
        return Ok(value);
    }
}
