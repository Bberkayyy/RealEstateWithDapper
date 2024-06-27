using RealEstate_Api_Dapper.Dtos.ClientDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ClientDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ClientRepositories;

public interface IClientRepository
{
    Task<List<GetAllClientResponseDto>> GetAllClientAsync();
    Task CreateClientAsync(CreateClientRequestDto createClientRequestDto);
    Task UpdateClientAsync(UpdateClientRequestDto updateClientRequestDto);
    Task DeleteClientAsync(int id);
    Task<GetClientByIdResponseDto> GetClientByIdAsync(int id);
}
