using Dapper;
using RealEstate_Api_Dapper.Dtos.LocationDtos.Requests;
using RealEstate_Api_Dapper.Dtos.LocationDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.LocationRepositories;

public class LocationRepository : ILocationRepository
{
    private readonly Context _context;

    public LocationRepository(Context context)
    {
        _context = context;
    }

    public async void CreateLocation(CreateLocationRequestDto createLocationRequestDto)
    {
        string query = "Insert into TblLocation (City,ImageUrl,PropertyCount) values (@city,@imageUrl,@propertyCount)";
        DynamicParameters parameters = new();
        parameters.Add("@city", createLocationRequestDto.City);
        parameters.Add("@imageUrl", createLocationRequestDto.ImageUrl);
        parameters.Add("@PropertyCount", createLocationRequestDto.PropertyCount);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteLocation(int id)
    {
        string query = "Delete From TblLocation where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllLocationResponseDto>> GetAllLocationAsync()
    {
        string query = "Select * from TblLocation";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllLocationResponseDto> values = await connection.QueryAsync<GetAllLocationResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetLocationByIdResponseDto> GetLocationByIdAsync(int id)
    {
        string query = "Select * from TblLocation where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetLocationByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetLocationByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async void UpdateLocation(UpdateLocationRequestDto updateLocationRequestDto)
    {
        string query = "Update TblLocation set City = @city, ImageUrl = @imageUrl, PropertyCount = @propertyCount where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@city", updateLocationRequestDto.City);
        parameters.Add("@imageUrl", updateLocationRequestDto.ImageUrl);
        parameters.Add("@propertyCount", updateLocationRequestDto.PropertyCount);
        parameters.Add("@id", updateLocationRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
