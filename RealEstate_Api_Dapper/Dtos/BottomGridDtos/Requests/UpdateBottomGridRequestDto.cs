namespace RealEstate_Api_Dapper.Dtos.BottomGridDtos.Requests;

public class UpdateBottomGridRequestDto
{
    public int Id { get; set; }
    public string? Icon { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
