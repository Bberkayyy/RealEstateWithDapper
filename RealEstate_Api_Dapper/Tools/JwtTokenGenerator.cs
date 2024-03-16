using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate_Api_Dapper.Tools;

public class JwtTokenGenerator
{
    public static TokenResponseDto GenerateToken(GetCheckAppUserDto getCheckAppUserDto)
    {
        List<Claim> claims = new List<Claim>();
        if (!string.IsNullOrWhiteSpace(getCheckAppUserDto.Role))
            claims.Add(new Claim(ClaimTypes.Role, getCheckAppUserDto.Role));

        claims.Add(new Claim(ClaimTypes.NameIdentifier, getCheckAppUserDto.Id.ToString()));

        if (!string.IsNullOrWhiteSpace(getCheckAppUserDto.Username))
            claims.Add(new Claim("Username", getCheckAppUserDto.Username));

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
        SigningCredentials signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);
        JwtSecurityToken token = new(issuer: JwtTokenDefaults.ValidIssuer,
            audience: JwtTokenDefaults.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: expireDate,
            signingCredentials: signinCredentials);

        JwtSecurityTokenHandler tokenHandler = new();
        return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
    }
}
