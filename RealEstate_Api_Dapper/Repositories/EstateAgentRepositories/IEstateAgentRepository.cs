using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.EstateAgentRepositories;

public interface IEstateAgentRepository
{
    Task<List<GetAllEstateAgentResponseDto>> GetAllEstateAgentAsync();
    Task CreateEstateAgentAsync(CreateEstateAgentRequestDto createEstateAgentRequestDto);
    Task UpdateEstateAgentAsync(UpdateEstateAgentRequestDto updateEstateAgentRequestDto);
    Task DeleteEstateAgentAsync(int id);
    Task<GetEstateAgentByIdResponseDto> GetEstateAgentByIdAsync(int id);
}
