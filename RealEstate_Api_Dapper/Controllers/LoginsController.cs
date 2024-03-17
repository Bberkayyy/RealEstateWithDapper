using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.LoginDtos;
using RealEstate_Api_Dapper.Models.DapperContext;
using RealEstate_Api_Dapper.Tools;
using System.Data;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginsController : ControllerBase
{
    private readonly Context _context;

    public LoginsController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Login(CreateLoginDto createLoginDto)
    {
        string query = "Select TblAppUser.Id,TblAppUser.Username,TblAppUser.Password,TblAppUser.Email,TblAppRole.Name as RoleName from TblAppUser inner join TblAppRole on TblAppUser.RoleId = TblAppRole.Id where Username = @username and Password = @password";
        DynamicParameters parameters = new();
        parameters.Add("@username", createLoginDto.Username);
        parameters.Add("@password", createLoginDto.Password);
        using (IDbConnection connection = _context.CreateConnection())
        {
            SuccessLoginDto value = await connection.QueryFirstOrDefaultAsync<SuccessLoginDto>(query, parameters);
            if (value is not null)
            {
                GetCheckAppUserDto model = new();
                model.Username = value.Username;
                model.Id = value.Id;
                model.Role = value.RoleName;
                TokenResponseDto token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            return Ok("Kullanıcı adı veya şifre yanlış!");
        }
    }
}
