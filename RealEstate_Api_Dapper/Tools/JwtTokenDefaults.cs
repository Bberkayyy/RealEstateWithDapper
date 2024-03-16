namespace RealEstate_Api_Dapper.Tools;

public class JwtTokenDefaults
{
    public const string ValidAudience = "https://localhost";
    public const string ValidIssuer = "https://localhost";
    public const string Key = "realEstateWithDapperAsp.NetCore8.0";
    public const int Expire = 60;
}
