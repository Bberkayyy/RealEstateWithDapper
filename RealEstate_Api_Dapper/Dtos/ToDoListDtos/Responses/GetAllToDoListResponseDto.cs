﻿namespace RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;

public class GetAllToDoListResponseDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
}
