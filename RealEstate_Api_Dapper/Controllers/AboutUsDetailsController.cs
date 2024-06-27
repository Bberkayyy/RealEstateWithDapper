using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Responses;
using RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutUsDetailsController : ControllerBase
{
    private readonly IAboutUsDetailRepository _aboutUsDetailRepository;

    public AboutUsDetailsController(IAboutUsDetailRepository aboutUsDetailRepository)
    {
        _aboutUsDetailRepository = aboutUsDetailRepository;
    }
    [HttpGet]
    public async Task<IActionResult> AboutUsDetailList()
    {
        List<GetAllAboutUsDetailResponseDto> values = await _aboutUsDetailRepository.GetAllAboutUsDetailAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAboutUsDetail(CreateAboutUsDetailRequestDto createAboutUsDetailRequestDto)
    {
        await _aboutUsDetailRepository.CreateAboutUsDetailAsync(createAboutUsDetailRequestDto);
        return Ok("Hakkımızda Detayı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAboutUsDetail(int id)
    {
        await _aboutUsDetailRepository.DeleteAboutUsDetailAsync(id);
        return Ok("Hakkımızda Detayı Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAboutUsDetail(UpdateAboutUsDetailRequestDto updateAboutUsDetailRequestDto)
    {
        await _aboutUsDetailRepository.UpdateAboutUsDetailAsync(updateAboutUsDetailRequestDto);
        return Ok("Hakkımızda Detayı Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutUsDetailById(int id)
    {
        GetAboutUsDetailByIdResponseDto value = await _aboutUsDetailRepository.GetAboutUsDetailByIdAsync(id);
        return Ok(value);
    }
}
