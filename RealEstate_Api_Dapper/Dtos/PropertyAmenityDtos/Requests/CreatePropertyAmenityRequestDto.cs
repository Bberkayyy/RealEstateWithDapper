namespace RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Requests;

public class CreatePropertyAmenityRequestDto
{
    public int PropertyId { get; set; }
    public int AmenityId { get; set; }
    public bool DoesHave { get; set; }
}
