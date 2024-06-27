using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;
using RealEstate_Api_Dapper.Hubs;
using RealEstate_Api_Dapper.Repositories.ToDoListRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ToDoListsController : ControllerBase
{
    private readonly IToDoListRepository _ToDoListRepository;

    public ToDoListsController(IToDoListRepository ToDoListRepository)
    {
        _ToDoListRepository = ToDoListRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ToDoListList()
    {
        List<GetAllToDoListResponseDto> values = await _ToDoListRepository.GetAllToDoListAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateToDoList(CreateToDoListRequestDto createToDoListRequestDto)
    {
        await _ToDoListRepository.CreateToDoListAsync(createToDoListRequestDto);
        return Ok("Yapılacak Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteToDoList(int id)
    {
        await _ToDoListRepository.DeleteToDoListAsync(id);
        return Ok("Yapılacak Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateToDoList(UpdateToDoListRequestDto updateToDoListRequestDto)
    {
        await _ToDoListRepository.UpdateToDoListAsync(updateToDoListRequestDto);
        return Ok("Yapılacak Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetToDoListById(int id)
    {
        GetToDoListByIdResponseDto value = await _ToDoListRepository.GetToDoListByIdAsync(id);
        return Ok(value);
    }
    [HttpGet("ToDoStatusChangeToFalse")]
    public async Task<IActionResult> ToDoStatusChangeToFalse(int id)
    {
        await _ToDoListRepository.ToDoStatusChangeToFalseAsync(id);
        return Ok("Yapılacak durumu tamamlanmadı olarak değiştirildi.");
    }
    [HttpGet("ToDoStatusChangeToTrue")]
    public async Task<IActionResult> ToDoStatusChangeToTrue(int id)
    {
        await _ToDoListRepository.ToDoStatusChangeToTrueAsync(id);
        return Ok("Yapılacak durumu tamamlandı olarak değiştirildi.");
    }
}
