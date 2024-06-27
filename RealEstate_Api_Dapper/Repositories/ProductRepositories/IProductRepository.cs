using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ProductRepositories;

public interface IProductRepository
{
    Task<List<GetAllProductResponseDto>> GetAllProductAsync();
    Task<List<GetAllProductWithRelationshipsResponseDto>> GetAllProductWithRelationshipsAsync();
    Task CreateProductAsync(CreateProductRequestDto createProductRequestDto);
    Task UpdateProductAsync(UpdateProductRequestDto updateProductRequestDto);
    Task DeleteProductAsync(int id);
    Task<GetProductByIdResponseDto> GetProductByIdAsync(int id);
    Task<GetProductByIdWithRelationshipsResponseDto> GetProductByIdWithRelationshipsAsync(int id);
    Task ProductDealOfTheDayStatusChangeToTrueAsync(int id);
    Task ProductDealOfTheDayStatusChangeToFalseAsync(int id);
    Task<List<GetLast5ProductResponseDto>> GetLast5ProductAsync();
    Task<List<GetLast5ProductWithRelationshipsResponseDto>> GetLast5ProductWithRelationshipsAsync();
    Task<List<GetLast3ProductResponseDto>> GetLast3ProductAsync();
    Task<List<GetLast3ProductWithRelationshipsResponseDto>> GetLast3ProductWithRelationshipsAsync();
    Task<List<GetProductListByEmployeeIdResponseDto>> GetProductListByEmployeeIdAndIsActiveTrueAsync(int id);
    Task<List<GetProductListByEmployeeIdResponseDto>> GetProductListByEmployeeIdAndIsActiveFalseAsync(int id);
    Task<List<GetProductListByEmployeeIdWithRelationshipsResponseDto>> GetProductListByEmployeeIdAndIsActiveTrueWithRelationshipsAsync(int id);
    Task<List<GetProductListByEmployeeIdWithRelationshipsResponseDto>> GetProductListByEmployeeIdAndIsActiveFalseWithRelationshipsAsync(int id);
    Task ProductIsActiveChangeToTrueAsync(int id);
    Task ProductIsActiveChangeToFalseAsync(int id);
    Task<List<GetProductListBySearchFilterWithRelationshipsResponseDto>> GetProductListBySearchFilterWithRelationshipsAsync(string containsWord, int categoryId, string city);
    Task<List<GetProductListByDealOfTheDayTrueWithRelationshipsResponseDto>> GetProductListByDealOfTheDayTrueWithRelationshipsAsync();
}
