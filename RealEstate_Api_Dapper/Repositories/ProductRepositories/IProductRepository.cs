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
    void ProductDealOfTheDayStatusChangeToTrue(int id);
    void ProductDealOfTheDayStatusChangeToFalse(int id);
    Task<List<GetLast5ProductResponseDto>> GetLast5ProductAsync();
    Task<List<GetLast5ProductWithRelationshipsResponseDto>> GetLast5ProductWithRelationshipsAsync();
    Task<List<GetProductListByEmployeeIdResponseDto>> GetProductListByEmployeeIdAndIsActiveTrueAsync(int id);
    Task<List<GetProductListByEmployeeIdResponseDto>> GetProductListByEmployeeIdAndIsActiveFalseAsync(int id);
    Task<List<GetProductListByEmployeeIdWithRelationshipsResponseDto>> GetProductListByEmployeeIdAndIsActiveTrueWithRelationshipsAsync(int id);
    Task<List<GetProductListByEmployeeIdWithRelationshipsResponseDto>> GetProductListByEmployeeIdAndIsActiveFalseWithRelationshipsAsync(int id);
    void ProductIsActiveChangeToTrue(int id);
    void ProductIsActiveChangeToFalse(int id);
}
