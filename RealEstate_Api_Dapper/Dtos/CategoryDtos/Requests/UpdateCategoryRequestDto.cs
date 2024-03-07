namespace RealEstate_Api_Dapper.Dtos.CategoryDtos.Requests;

public class UpdateCategoryRequestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
}
