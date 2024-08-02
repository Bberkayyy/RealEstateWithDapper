namespace RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;

public class GetPropertyDetailByPropertyIdResponseDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public int PropertySize { get; set; }
    public int BedroomCount { get; set; }
    public int BathCount { get; set; }
    public int RoomCount { get; set; }
    public int GarageSize { get; set; }
    public string BuildYear { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }
    public string VideoUrl { get; set; }
}
