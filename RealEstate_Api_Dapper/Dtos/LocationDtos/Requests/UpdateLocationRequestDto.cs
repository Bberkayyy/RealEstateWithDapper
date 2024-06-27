namespace RealEstate_Api_Dapper.Dtos.LocationDtos.Requests;

public class UpdateLocationRequestDto
{
    public int Id { get; set; }
    public string City { get; set; }
    public string ImageUrl { get; set; }
    public int PropertyCount { get; set; }
}
