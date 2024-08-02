namespace RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Requests;

public class UpdatePropertyImageRequestDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string ImageUrl { get; set; }
}
