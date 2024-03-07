using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Responses;
using RealEstate_Api_Dapper.Repositories.AboutUsDetailRepository;

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
        _aboutUsDetailRepository.CreateAboutUsDetail(createAboutUsDetailRequestDto);
        return Ok("Hakkımızda Detayı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAboutUsDetail(int id)
    {
        _aboutUsDetailRepository.DeleteAboutUsDetail(id);
        return Ok("Hakkımızda Detayı Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAboutUsDetail(UpdateAboutUsDetailRequestDto updateAboutUsDetailRequestDto)
    {
        _aboutUsDetailRepository.UpdateAboutUsDetail(updateAboutUsDetailRequestDto);
        return Ok("Hakkımızda Detayı Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutUsDetailById(int id)
    {
        GetAboutUsDetailByIdResponseDto value = await _aboutUsDetailRepository.GetAboutUsDetailByIdAsync(id);
        return Ok(value);
    }
}
