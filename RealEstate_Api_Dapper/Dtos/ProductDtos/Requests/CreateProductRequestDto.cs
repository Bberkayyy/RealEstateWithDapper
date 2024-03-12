﻿namespace RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;

public class CreateProductRequestDto
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string CoverImage { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string? Description { get; set; }
    public string Type { get; set; }
    public int CategoryId { get; set; }
    public int EmployeeId { get; set; }
}