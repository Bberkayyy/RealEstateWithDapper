namespace RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Responses;

public class GetPropertyImagesByPropertyIdResponseDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string ImageUrl { get; set; }
}
