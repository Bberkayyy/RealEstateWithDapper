using Dapper;
using RealEstate_Api_Dapper.Dtos.ProductDetailDtos.Responses;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.ProductDetailRepositories;

public class ProductDetailRepository : IProductDetailRepository
{
    private readonly Context _context;

    public ProductDetailRepository(Context context)
    {
        _context = context;
    }
    public async Task<GetProductDetailByProductIdResponseDto> GetProductDetailByProductIdAsync(int id)
    {
        string query = "Select * from TblProductDetails where ProductId=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetProductDetailByProductIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetProductDetailByProductIdResponseDto>(query, parameters);
            return value;
        }
    }
}
