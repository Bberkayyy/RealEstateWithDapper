using Dapper;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.PropertyDetailRepositories;

public class PropertyDetailRepository : IPropertyDetailRepository
{
    private readonly Context _context;

    public PropertyDetailRepository(Context context)
    {
        _context = context;
    }

    public async Task CreatePropertyDetailAsync(CreatePropertyDetailRequestDto createPropertyDetailDto)
    {
        string query = "insert into TblPropertyDetails (PropertyId,PropertySize,BedroomCount,BathCount,RoomCount,GarageSize,BuildYear,Price,Location,VideoUrl) values (@propertyId,@propertySize,@bedroomCount,@bathCount,@roomCount,@garageSize,@buildYear,@price,@location,@videoUrl)";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", createPropertyDetailDto.PropertyId);
        parameters.Add("@propertySize", createPropertyDetailDto.PropertySize);
        parameters.Add("@bedroomCount", createPropertyDetailDto.BedroomCount);
        parameters.Add("@bathCount", createPropertyDetailDto.BathCount);
        parameters.Add("@roomCount", createPropertyDetailDto.RoomCount);
        parameters.Add("@garageSize", createPropertyDetailDto.GarageSize);
        parameters.Add("@buildYear", createPropertyDetailDto.BuildYear);
        parameters.Add("@price", createPropertyDetailDto.Price);
        parameters.Add("@location", createPropertyDetailDto.Location);
        parameters.Add("@videoUrl", createPropertyDetailDto.VideoUrl);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeletePropertyDetailAsync(int id)
    {
        string query = "Delete from TblPropertyDetails where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetPropertyDetailByPropertyIdResponseDto> GetPropertyDetailByPropertyIdAsync(int id)
    {
        string query = "Select * from TblPropertyDetails where PropertyId=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetPropertyDetailByPropertyIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetPropertyDetailByPropertyIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdatePropertyDetailAsync(UpdatePropertyDetailRequestDto updatePropertyDetailDto)
    {
        string query = "update TblPropertyDetails set PropertyId = @propertyId, PropertySize = @propertySize, BedroomCount = @bedroomCount, BathCount = @bathCount, RoomCount = @roomCount, GarageSize = @garageSize, BuildYear = @buildYear, Price = @price, Location = @location, VideoUrl = @videoUrl where Id = @id ";
        DynamicParameters parameters = new();
        parameters.Add("@id", updatePropertyDetailDto.Id);
        parameters.Add("@propertyId", updatePropertyDetailDto.PropertyId);
        parameters.Add("@propertySize", updatePropertyDetailDto.PropertySize);
        parameters.Add("@bedroomCount", updatePropertyDetailDto.BedroomCount);
        parameters.Add("@bathCount", updatePropertyDetailDto.BathCount);
        parameters.Add("@roomCount", updatePropertyDetailDto.RoomCount);
        parameters.Add("@garageSize", updatePropertyDetailDto.GarageSize);
        parameters.Add("@buildYear", updatePropertyDetailDto.BuildYear);
        parameters.Add("@price", updatePropertyDetailDto.Price);
        parameters.Add("@location", updatePropertyDetailDto.Location);
        parameters.Add("@videUrl", updatePropertyDetailDto.VideoUrl);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
