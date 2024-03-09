using RealEstate_Api_Dapper.Dtos.ClientDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ClientDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ClientRepositories;

public interface IClientRepository
{
    Task<List<GetAllClientResponseDto>> GetAllClientAsync();
    void CreateClient(CreateClientRequestDto createClientRequestDto);
    void UpdateClient(UpdateClientRequestDto updateClientRequestDto);
    void DeleteClient(int id);
    Task<GetClientByIdResponseDto> GetClientByIdAsync(int id);
}
