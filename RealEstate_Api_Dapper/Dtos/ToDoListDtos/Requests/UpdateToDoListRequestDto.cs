namespace RealEstate_Api_Dapper.Dtos.ToDoListDtos.Requests;

public class UpdateToDoListRequestDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}
