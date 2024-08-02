using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.EstateAgentRepositories.DashboardRepositories;

public interface IEstateAgentDashboardRepository
{
    int GetEstateAgentPropertyCount(int id);
    int GetPropertyCount();
    int GetEstateAgentPropertyCountByStatusTrue(int id);
    int GetEstateAgentPropertyCountByStatusFalse(int id);

    Task<List<EstateAgentDashboardChartResponseDto>> Get5CityForChart();
    Task<List<EstateAgentLast5PropertyWithRelationshipsResponseDto>> GetEstateAgentLast5Property(int id);
}
