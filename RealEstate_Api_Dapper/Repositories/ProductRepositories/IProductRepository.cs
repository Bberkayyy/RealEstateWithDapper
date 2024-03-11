using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ProductRepositories;

public interface IProductRepository
{
    Task<List<GetAllProductResponseDto>> GetAllProductAsync();
    Task<List<GetAllProductWithRelationshipsResponseDto>> GetAllProductWithRelationshipsAsync();
    void CreateProduct(CreateProductRequestDto createProductRequestDto);
    void UpdateProduct(UpdateProductRequestDto updateProductRequestDto);
    void DeleteProduct(int id);
    Task<GetProductByIdResponseDto> GetProductByIdAsync(int id);
    Task<GetProductByIdWithRelationshipsResponseDto> GetProductByIdWithRelationshipsAsync(int id);
}
