namespace RealEstate_Api_Dapper.Dtos.LoginDtos;

public class SuccessLoginDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string RoleName { get; set; }
}
