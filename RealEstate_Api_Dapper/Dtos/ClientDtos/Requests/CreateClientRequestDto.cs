namespace RealEstate_Api_Dapper.Dtos.ClientDtos.Requests;

public class CreateClientRequestDto
{
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Comment { get; set; }
    public bool Status { get; set; }
}
