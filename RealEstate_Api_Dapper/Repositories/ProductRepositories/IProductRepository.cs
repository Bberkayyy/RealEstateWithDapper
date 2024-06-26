using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ProductRepositories;

public interface IProductRepository
{
    Task<List<GetAllProductResponseDto>> GetAllProductAsync();
    Task<List<GetAllProductWithRelationshipsResponseDto>> GetAllProductWithRelationshipsAsync();
    Task CreateProduct(CreateProductRequestDto createProductRequestDto);
    Task UpdateProduct(UpdateProductRequestDto updateProductRequestDto);
    Task DeleteProduct(int id);
    Task<GetProductByIdResponseDto> GetProductByIdAsync(int id);
    Task<GetProductByIdWithRelationshipsResponseDto> GetProductByIdWithRelationshipsAsync(int id);
    Task ProductDealOfTheDayStatusChangeToTrue(int id);
    Task ProductDealOfTheDayStatusChangeToFalse(int id);
    Task<List<GetLast5ProductResponseDto>> GetLast5ProductAsync();
    Task<List<GetLast5ProductWithRelationshipsResponseDto>> GetLast5ProductWithRelationshipsAsync();
    Task<List<GetProductListByEmployeeIdResponseDto>> GetProductListByEmployeeIdAndIsActiveTrueAsync(int id);
    Task<List<GetProductListByEmployeeIdResponseDto>> GetProductListByEmployeeIdAndIsActiveFalseAsync(int id);
    Task<List<GetProductListByEmployeeIdWithRelationshipsResponseDto>> GetProductListByEmployeeIdAndIsActiveTrueWithRelationshipsAsync(int id);
    Task<List<GetProductListByEmployeeIdWithRelationshipsResponseDto>> GetProductListByEmployeeIdAndIsActiveFalseWithRelationshipsAsync(int id);
    Task ProductIsActiveChangeToTrue(int id);
    Task ProductIsActiveChangeToFalse(int id);
    Task<List<GetProductListBySearchFilterWithRelationshipsResponseDto>> GetProductListBySearchFilterWithRelationshipsAsync(string containsWord, int categoryId, string city);
}
