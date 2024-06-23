using Dapper;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
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

    public async Task<List<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto>> GetPropertyAmenityListByPropertyIdAndDoesHaveTrueAsync(int productId)
    {
        string query = "select TblPropertyAmenity.Id,TblPropertyAmenity.PropertyId,TblAmenity.Title as AmenityTitle from TblPropertyAmenity inner join TblAmenity on TblPropertyAmenity.AmenityId = TblAmenity.Id where TblPropertyAmenity.PropertyId = @propertyId and TblPropertyAmenity.DoesHave = 1";
        DynamicParameters parameters = new();
        parameters.Add("@propertyId", productId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto> values = await connection.QueryAsync<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto>(query, parameters);
            return values.ToList();
        }
    }
}
