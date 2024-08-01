using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Requests;
using RealEstate_Api_Dapper.Dtos.RegisterDtos;
using RealEstate_Api_Dapper.Models.DapperContext;
using RealEstate_Api_Dapper.Repositories.EmployeeRepositories;
using System.Data;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegistersController : ControllerBase
{
    private readonly Context _context;
    private readonly IEmployeeRepository _employeeRepository;

    public RegistersController(Context context, IEmployeeRepository employeeRepository)
    {
        _context = context;
        _employeeRepository = employeeRepository;
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
    {
        CreateEmployeeRequestDto employee = new()
        {
            FullName = registerUserDto.FullName,
            Title = registerUserDto.Title,
            Mail = registerUserDto.Mail,
            PhoneNumber = registerUserDto.PhoneNumber,
            ImageUrl = registerUserDto.ImageUrl,
            Status = true
        };
        await _employeeRepository.CreateEmployeeAsync(employee);
        string query = "insert into TblAppUser (Username,Password,Name,Email,RoleId) values (@username,@password,@name,@email,@roleId)";
        DynamicParameters parameters = new();
        parameters.Add("@username", registerUserDto.Username);
        parameters.Add("@password", registerUserDto.Password);
        parameters.Add("@name", registerUserDto.FullName);
        parameters.Add("@email", registerUserDto.Mail);
        parameters.Add("@roleId", 2);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
        return Ok("Kullanıcı başarıyla kaydedildi.");
    }
}
