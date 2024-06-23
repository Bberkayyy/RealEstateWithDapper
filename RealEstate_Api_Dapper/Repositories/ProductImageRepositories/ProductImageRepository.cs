using Dapper;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
using RealEstate_Api_Dapper.Dtos.ProductImageDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductImageDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.ProductImageRepositories;

public class ProductImageRepository : IProductImageRepository
{
    private readonly Context _context;

    public ProductImageRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateProductImage(CreateProductImageRequestDto createProductRequestDto)
    {
        string query = "insert into TblProductImage (ProductId,ImageUrl) values (@productId,@imageUrl)";
        DynamicParameters parameters = new();
        parameters.Add("@productId", createProductRequestDto.ProductId);
        parameters.Add("@imageUrl", createProductRequestDto.ImageUrl);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteProductImage(int id)
    {
        string query = "Delete from TblProductImage where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllProductImagesResponseDto>> GetAllProductImageAsync()
    {
        string query = "Select * From TblProductImage";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllProductImagesResponseDto> values = await connection.QueryAsync<GetAllProductImagesResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetProductImageByIdResponseDto> GetProductImageByIdAsync(int id)
    {
        string query = "Select * from TblProductImage where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetProductImageByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetProductImageByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetProductImagesByProductIdResponseDto>> GetProductImagesByProductId(int id)
    {
        string query = "Select * from TblProductImage where ProductId=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductImagesByProductIdResponseDto> values = await connection.QueryAsync<GetProductImagesByProductIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task UpdateProductImage(UpdateProductImageRequestDto updateProductRequestDto)
    {
        string query = "Update TblProductImage set ProductId=@productId,ImageUrl=@imageUrl where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@productId", updateProductRequestDto.ProductId);
        parameters.Add("@imageUrl", updateProductRequestDto.ImageUrl);
        parameters.Add("@id", updateProductRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
