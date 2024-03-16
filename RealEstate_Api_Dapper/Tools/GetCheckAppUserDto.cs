namespace RealEstate_Api_Dapper.Tools;

public class GetCheckAppUserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public bool IsExist { get; set; }
}
