namespace RealEstate_Api_Dapper.Dtos.ProductImageDtos.Requests;

public class CreateProductImageRequestDto
{
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
}
