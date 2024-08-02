using Dapper;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;
using RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.PropertyImageRepositories;

public class PropertyImageRepository : IPropertyImageRepository
{
    private readonly Context _context;

    public PropertyImageRepository(Context context)
    {
        _context = context;
    }

    public async Task CreatePropertyImageAsync(CreatePropertyImageRequestDto createPropertyRequestDto)
    {
        string query = "insert into TblPropertyImage (PropertyId,ImageUrl) values (@propertyId,@imageUrl)";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", createPropertyRequestDto.PropertyId);
        parameters.Add("@imageUrl", createPropertyRequestDto.ImageUrl);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeletePropertyImageAsync(int id)
    {
        string query = "Delete from TblPropertyImage where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllPropertyImagesResponseDto>> GetAllPropertyImageAsync()
    {
        string query = "Select * From TblPropertyImage";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllPropertyImagesResponseDto> values = await connection.QueryAsync<GetAllPropertyImagesResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetPropertyImageByIdResponseDto> GetPropertyImageByIdAsync(int id)
    {
        string query = "Select * from TblPropertyImage where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetPropertyImageByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetPropertyImageByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetPropertyImagesByPropertyIdResponseDto>> GetPropertyImagesByPropertyIdAsync(int id)
    {
        string query = "Select * from TblPropertyImage where PropertyId=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyImagesByPropertyIdResponseDto> values = await connection.QueryAsync<GetPropertyImagesByPropertyIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task UpdatePropertyImageAsync(UpdatePropertyImageRequestDto updatePropertyRequestDto)
    {
        string query = "Update TblPropertyImage set PropertyId=@propertyId,ImageUrl=@imageUrl where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", updatePropertyRequestDto.PropertyId);
        parameters.Add("@imageUrl", updatePropertyRequestDto.ImageUrl);
        parameters.Add("@id", updatePropertyRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
