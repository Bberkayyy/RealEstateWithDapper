using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Requests;
using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.BottomGridRepositories;

public interface IBottomGridRepository
{
    Task<List<GetAllBottomGridResponseDto>> GetAllBottomGridAsync();
    void CreateBottomGrid(CreateBottomGridRequestDto createBottomGridRequestDto);
    void UpdateBottomGrid(UpdateBottomGridRequestDto updateBottomGridRequestDto);
    void DeleteBottomGrid(int id);
    Task<GetBottomGridByIdResponseDto> GetBottomGridByIdAsync(int id);
}
