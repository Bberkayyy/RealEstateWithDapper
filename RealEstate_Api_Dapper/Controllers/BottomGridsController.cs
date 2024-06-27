using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Requests;
using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Responses;
using RealEstate_Api_Dapper.Repositories.BottomGridRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BottomGridsController : ControllerBase
{
    private readonly IBottomGridRepository _BottomGridRepository;

    public BottomGridsController(IBottomGridRepository BottomGridRepository)
    {
        _BottomGridRepository = BottomGridRepository;
    }
    [HttpGet]
    public async Task<IActionResult> BottomGridList()
    {
        List<GetAllBottomGridResponseDto> values = await _BottomGridRepository.GetAllBottomGridAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid(CreateBottomGridRequestDto createBottomGridRequestDto)
    {
      await  _BottomGridRepository.CreateBottomGridAsync(createBottomGridRequestDto);
        return Ok("Alt Bilgi Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteBottomGrid(int id)
    {
       await _BottomGridRepository.DeleteBottomGridAsync(id);
        return Ok("Alt Bilgi Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridRequestDto updateBottomGridRequestDto)
    {
        await _BottomGridRepository.UpdateBottomGridAsync(updateBottomGridRequestDto);
        return Ok("Alt Bilgi Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBottomGridById(int id)
    {
        GetBottomGridByIdResponseDto value = await _BottomGridRepository.GetBottomGridByIdAsync(id);
        return Ok(value);
    }
}
