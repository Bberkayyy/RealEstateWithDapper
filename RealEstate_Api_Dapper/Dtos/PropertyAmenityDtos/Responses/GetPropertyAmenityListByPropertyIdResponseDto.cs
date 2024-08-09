namespace RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Responses;

public class GetPropertyAmenityListByPropertyIdResponseDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string AmenityTitle { get; set; }
    public bool DoesHave { get; set; }
}
