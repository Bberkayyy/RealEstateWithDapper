namespace RealEstate_Api_Dapper.Dtos.ProductImageDtos.Requests;

public class UpdateProductImageRequestDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
}
