using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;
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
        _ToDoListRepository.CreateToDoList(createToDoListRequestDto);
        return Ok("Yapılacak Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteToDoList(int id)
    {
        _ToDoListRepository.DeleteToDoList(id);
        return Ok("Yapılacak Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateToDoList(UpdateToDoListRequestDto updateToDoListRequestDto)
    {
        _ToDoListRepository.UpdateToDoList(updateToDoListRequestDto);
        return Ok("Yapılacak Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetToDoListById(int id)
    {
        GetToDoListByIdResponseDto value = await _ToDoListRepository.GetToDoListByIdAsync(id);
        return Ok(value);
    }
}
