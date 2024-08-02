using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.EstateAgentRepositories.DashboardRepositories;

public interface IEstateAgentDashboardRepository
{
    int GetEstateAgentProductCount(int id);
    int GetProductCount();
    int GetEstateAgentProductCountByStatusTrue(int id);
    int GetEstateAgentProductCountByStatusFalse(int id);

    Task<List<EstateAgentDashboardChartResponseDto>> Get5CityForChart();
    Task<List<EstateAgentLast5ProductWithRelationshipsResponseDto>> GetEstateAgentLast5Product(int id);
}
