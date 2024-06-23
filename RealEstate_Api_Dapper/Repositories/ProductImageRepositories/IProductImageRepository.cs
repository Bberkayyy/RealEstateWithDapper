using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
using RealEstate_Api_Dapper.Dtos.ProductImageDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductImageDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ProductImageRepositories;

public interface IProductImageRepository
{
    Task<List<GetAllProductImagesResponseDto>> GetAllProductImageAsync();
    Task CreateProductImage(CreateProductImageRequestDto createProductRequestDto);
    Task UpdateProductImage(UpdateProductImageRequestDto updateProductRequestDto);
    Task DeleteProductImage(int id);
    Task<GetProductImageByIdResponseDto> GetProductImageByIdAsync(int id);
    Task<List<GetProductImagesByProductIdResponseDto>> GetProductImagesByProductId(int id);
}
