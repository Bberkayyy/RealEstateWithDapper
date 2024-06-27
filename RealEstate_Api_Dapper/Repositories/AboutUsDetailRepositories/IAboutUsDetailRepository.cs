using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;

public interface IAboutUsDetailRepository
{
    Task<List<GetAllAboutUsDetailResponseDto>> GetAllAboutUsDetailAsync();
    Task CreateAboutUsDetailAsync(CreateAboutUsDetailRequestDto createAboutUsDetailRequestDto);
    Task UpdateAboutUsDetailAsync(UpdateAboutUsDetailRequestDto updateAboutUsDetailRequestDto);
    Task DeleteAboutUsDetailAsync(int id);
    Task<GetAboutUsDetailByIdResponseDto> GetAboutUsDetailByIdAsync(int id);
}
