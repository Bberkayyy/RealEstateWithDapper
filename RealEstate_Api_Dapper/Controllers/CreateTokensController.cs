using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Tools;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreateTokensController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateToken(GetCheckAppUserDto getCheckAppUserDto)
    {
        TokenResponseDto value = JwtTokenGenerator.GenerateToken(getCheckAppUserDto);
        return Ok(value);
    }
}
