namespace RealEstate_Api_Dapper.Dtos.ProductImageDtos.Responses;

public class GetProductImageByIdResponseDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string ImageUrl { get; set; }
}
