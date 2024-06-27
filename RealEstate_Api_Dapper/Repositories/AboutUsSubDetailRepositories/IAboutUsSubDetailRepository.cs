using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;

public interface IAboutUsSubDetailRepository
{
    Task<List<GetAllAboutUsSubDetailResponseDto>> GetAllAboutUsSubDetailAsync();
    Task CreateAboutUsSubDetailAsync(CreateAboutUsSubDetailRequestDto createAboutUsSubDetailRequestDto);
    Task UpdateAboutUsSubDetailAsync(UpdateAboutUsSubDetailRequestDto updateAboutUsSubDetailRequestDto);
    Task DeleteAboutUsSubDetailAsync(int id);
    Task<GetAboutUsSubDetailByIdResponseDto> GetAboutUsSubDetailByIdAsync(int id);
}
