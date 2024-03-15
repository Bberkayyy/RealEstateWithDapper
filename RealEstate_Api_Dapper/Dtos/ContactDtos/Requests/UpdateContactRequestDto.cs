namespace RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;

public class UpdateContactRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
