using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Responses;
using RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutUsSubDetailsController : ControllerBase
{
    private readonly IAboutUsSubDetailRepository _aboutUsSubDetailRepository;

    public AboutUsSubDetailsController(IAboutUsSubDetailRepository aboutUsSubDetailRepository)
    {
        _aboutUsSubDetailRepository = aboutUsSubDetailRepository;
    }
    [HttpGet]
    public async Task<IActionResult> AboutUsSubDetailList()
    {
        List<GetAllAboutUsSubDetailResponseDto> values = await _aboutUsSubDetailRepository.GetAllAboutUsSubDetailAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAboutUsSubDetail(CreateAboutUsSubDetailRequestDto createAboutUsSubDetailRequestDto)
    {
        await _aboutUsSubDetailRepository.CreateAboutUsSubDetailAsync(createAboutUsSubDetailRequestDto);
        return Ok("Hakkımızda Alt Detayı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAboutUsSubDetail(int id)
    {
        await _aboutUsSubDetailRepository.DeleteAboutUsSubDetailAsync(id);
        return Ok("Hakkımızda Alt Detayı Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAboutUsSubDetail(UpdateAboutUsSubDetailRequestDto updateAboutUsSubDetailRequestDto)
    {
        await _aboutUsSubDetailRepository.UpdateAboutUsSubDetailAsync(updateAboutUsSubDetailRequestDto);
        return Ok("Hakkımızda Alt Detayı Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAboutUsSubDetailById(int id)
    {
        GetAboutUsSubDetailByIdResponseDto value = await _aboutUsSubDetailRepository.GetAboutUsSubDetailByIdAsync(id);
        return Ok(value);
    }
}
