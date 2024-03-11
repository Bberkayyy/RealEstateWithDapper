using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Responses;
using RealEstate_Api_Dapper.Repositories.EmployeeRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    [HttpGet]
    public async Task<IActionResult> EmployeeList()
    {
        List<GetAllEmployeeResponseDto> values = await _employeeRepository.GetAllEmployeeAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeRequestDto createEmployeeRequestDto)
    {
        _employeeRepository.CreateEmployee(createEmployeeRequestDto);
        return Ok("Çalışan Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        _employeeRepository.DeleteEmployee(id);
        return Ok("Çalışan Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequestDto updateEmployeeRequestDto)
    {
        _employeeRepository.UpdateEmployee(updateEmployeeRequestDto);
        return Ok("Çalışan Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        GetEmployeeByIdResponseDto value = await _employeeRepository.GetEmployeeByIdAsync(id);
        return Ok(value);
    }
}
