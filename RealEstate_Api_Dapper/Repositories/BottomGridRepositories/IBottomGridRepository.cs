using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Requests;
using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.BottomGridRepositories;

public interface IBottomGridRepository
{
    Task<List<GetAllBottomGridResponseDto>> GetAllBottomGridAsync();
    Task CreateBottomGridAsync(CreateBottomGridRequestDto createBottomGridRequestDto);
    Task UpdateBottomGridAsync(UpdateBottomGridRequestDto updateBottomGridRequestDto);
    Task DeleteBottomGridAsync(int id);
    Task<GetBottomGridByIdResponseDto> GetBottomGridByIdAsync(int id);
}
