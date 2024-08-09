using Dapper;
using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.PropertyAmenityRepositoryies;

public class PropertyAmenityRepository : IPropertyAmenityRepository
{
    private readonly Context _context;

    public PropertyAmenityRepository(Context context)
    {
        _context = context;
    }

    public async Task CreatePropertyAmenityAsync(CreatePropertyAmenityRequestDto createPropertyAmenityDto)
    {
        string query = "insert into TblPropertyAmenity (PropertyId,AmenityId,DoesHave) values (@propertyId,@amenityId,@doesHave)";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", createPropertyAmenityDto.PropertyId);
        parameters.Add("@amenityId", createPropertyAmenityDto.AmenityId);
        parameters.Add("@doesHave", createPropertyAmenityDto.DoesHave);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto>> GetPropertyAmenityListByPropertyIdAndDoesHaveTrueAsync(int propertyId)
    {
        string query = "select TblPropertyAmenity.Id,TblPropertyAmenity.PropertyId,TblAmenity.Title as AmenityTitle from TblPropertyAmenity inner join TblAmenity on TblPropertyAmenity.AmenityId = TblAmenity.Id where TblPropertyAmenity.PropertyId = @propertyId and TblPropertyAmenity.DoesHave = 1";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", propertyId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto> values = await connection.QueryAsync<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetPropertyAmenityListByPropertyIdResponseDto>> GetPropertyAmenityListByPropertyIdAsync(int propertyId)
    {
        string query = "select TblPropertyAmenity.Id,TblPropertyAmenity.PropertyId,TblPropertyAmenity.DoesHave,TblAmenity.Title as AmenityTitle from TblPropertyAmenity inner join TblAmenity on TblPropertyAmenity.AmenityId = TblAmenity.Id where TblPropertyAmenity.PropertyId = @propertyId";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", propertyId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyAmenityListByPropertyIdResponseDto> values = await connection.QueryAsync<GetPropertyAmenityListByPropertyIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task PropertyAmenityChangeDoesHaveToFalseAsync(int id)
    {
        string query = "update TblPropertyAmenity set DoesHave = 0 where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task PropertyAmenityChangeDoesHaveToTrueAsync(int id)
    {
        string query = "update TblPropertyAmenity set DoesHave = 1 where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
