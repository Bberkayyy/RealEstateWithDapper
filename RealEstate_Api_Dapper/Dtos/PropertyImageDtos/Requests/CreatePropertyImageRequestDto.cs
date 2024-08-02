namespace RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Requests;

public class CreatePropertyImageRequestDto
{
    public int PropertyId { get; set; }
    public string ImageUrl { get; set; }
}
