namespace RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;

public class CreateContactRequestDto
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public DateTime SendDate { get; set; }
}
