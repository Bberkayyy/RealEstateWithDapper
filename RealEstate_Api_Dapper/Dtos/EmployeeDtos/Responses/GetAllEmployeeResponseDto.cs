namespace RealEstate_Api_Dapper.Dtos.EmployeeDtos.Responses;

public class GetAllEmployeeResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Title { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}
