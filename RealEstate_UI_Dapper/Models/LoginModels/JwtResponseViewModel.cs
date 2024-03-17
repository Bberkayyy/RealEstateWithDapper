namespace RealEstate_UI_Dapper.Models.LoginModels;

public class JwtResponseViewModel
{
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
}
