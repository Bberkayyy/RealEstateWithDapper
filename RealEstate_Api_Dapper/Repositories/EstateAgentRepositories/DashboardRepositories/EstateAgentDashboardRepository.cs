using Dapper;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
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

    public int GetEstateAgentProductCount(int id)
    {
        string query = "select count(*) from TblProduct where EmployeeId = @employeeId";
        DynamicParameters parameters = new();
        parameters.Add("@employeeId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query, parameters);
        }
    }

    public int GetEstateAgentProductCountByStatusFalse(int id)
    {
        string query = "select count(*) from TblProduct where EmployeeId = @employeeId and  IsActive = 0";
        DynamicParameters parameters = new();
        parameters.Add("@employeeId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query, parameters);
        }
    }

    public int GetEstateAgentProductCountByStatusTrue(int id)
    {
        string query = "select count(*) from TblProduct where EmployeeId = @employeeId and  IsActive = 1";
        DynamicParameters parameters = new();
        parameters.Add("@employeeId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query, parameters);
        }
    }

    public int GetProductCount()
    {
        string query = "select count(*) from TblProduct";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public async Task<List<EstateAgentDashboardChartResponseDto>> Get5CityForChart()
    {
        string query = "Select City,Count(*) as CityCount From TblProduct Group by City order by CityCount desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<EstateAgentDashboardChartResponseDto> values = await connection.QueryAsync<EstateAgentDashboardChartResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<EstateAgentLast5ProductWithRelationshipsResponseDto>> GetEstateAgentLast5Product(int id)
    {
        string query = "Select top(5) TblProduct.Id, TblProduct.Title, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblCategory.Name as CategoryName, TblEmployee.FullName as EmployeeName From TblProduct inner join TblCategory on TblProduct.CategoryId = TblCategory.Id inner join TblEmployee on TblProduct.EmployeeId = TblEmployee.Id where EmployeeId=@employeeId order by Id desc";
        DynamicParameters parameters = new();
        parameters.Add("@employeeId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<EstateAgentLast5ProductWithRelationshipsResponseDto> value = await connection.QueryAsync<EstateAgentLast5ProductWithRelationshipsResponseDto>(query, parameters);
            return value.ToList();
        }
    }
}
