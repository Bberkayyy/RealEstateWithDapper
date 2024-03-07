namespace RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;

public class GetAllProductResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string CoverImage { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string CategoryId { get; set; }
    public string EmployeeId { get; set; }
}
