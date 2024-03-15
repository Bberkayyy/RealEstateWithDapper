﻿namespace RealEstate_Api_Dapper.Dtos.ContactDtos.Responses;

public class GetLast4ContactResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Subject { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    public DateTime SendDate { get; set; }
}
