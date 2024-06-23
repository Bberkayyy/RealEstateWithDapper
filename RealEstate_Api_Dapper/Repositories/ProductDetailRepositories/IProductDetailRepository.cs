using RealEstate_Api_Dapper.Dtos.ProductDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ProductDetailRepositories;

public interface IProductDetailRepository
{
    Task<GetProductDetailByProductIdResponseDto> GetProductDetailByProductIdAsync(int id);
}
