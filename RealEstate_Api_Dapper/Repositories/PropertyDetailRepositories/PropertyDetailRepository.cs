using Dapper;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;
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
}
