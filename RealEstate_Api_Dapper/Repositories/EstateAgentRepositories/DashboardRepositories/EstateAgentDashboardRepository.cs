using Dapper;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Responses;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.EstateAgentRepositories.DashboardRepositories;

public class EstateAgentDashboardRepository : IEstateAgentDashboardRepository
{
    private readonly Context _context;

    public EstateAgentDashboardRepository(Context context)
    {
        _context = context;
    }

    public int GetEstateAgentPropertyCount(int id)
    {
        string query = "select count(*) from TblProperty where EstateAgentId = @estateAgentId";
        DynamicParameters parameters = new();
        parameters.Add("@estateAgentId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query, parameters);
        }
    }

    public int GetEstateAgentPropertyCountByStatusFalse(int id)
    {
        string query = "select count(*) from TblProperty where EstateAgentId = @estateAgentId and  IsActive = 0";
        DynamicParameters parameters = new();
        parameters.Add("@estateAgentId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query, parameters);
        }
    }

    public int GetEstateAgentPropertyCountByStatusTrue(int id)
    {
        string query = "select count(*) from TblProperty where EstateAgentId = @estateAgentId and  IsActive = 1";
        DynamicParameters parameters = new();
        parameters.Add("@estateAgentId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query, parameters);
        }
    }

    public int GetPropertyCount()
    {
        string query = "select count(*) from TblProperty";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public async Task<List<EstateAgentDashboardChartResponseDto>> Get5CityForChart()
    {
        string query = "Select City,Count(*) as CityCount From TblProperty Group by City order by CityCount desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<EstateAgentDashboardChartResponseDto> values = await connection.QueryAsync<EstateAgentDashboardChartResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<EstateAgentLast5PropertyWithRelationshipsResponseDto>> GetEstateAgentLast5Property(int id)
    {
        string query = "Select top(5) TblProperty.Id, TblProperty.Title, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId = TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId = TblEstateAgent.Id where EstateAgentId=@estateAgentId order by Id desc";
        DynamicParameters parameters = new();
        parameters.Add("@estateAgentId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<EstateAgentLast5PropertyWithRelationshipsResponseDto> value = await connection.QueryAsync<EstateAgentLast5PropertyWithRelationshipsResponseDto>(query, parameters);
            return value.ToList();
        }
    }

    public async Task<List<EstateAgentLast3PropertyWithRelationshipsResponseDto>> GetEstateAgentLast3ActiveProperty(int id)
    {
        string query = "Select top(3) TblProperty.Id, TblProperty.Title, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId = TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId = TblEstateAgent.Id where EstateAgentId=@estateAgentId and IsActive=1 order by Id desc";
        DynamicParameters parameters = new();
        parameters.Add("@estateAgentId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<EstateAgentLast3PropertyWithRelationshipsResponseDto> value = await connection.QueryAsync<EstateAgentLast3PropertyWithRelationshipsResponseDto>(query, parameters);
            return value.ToList();
        }
    }
}
