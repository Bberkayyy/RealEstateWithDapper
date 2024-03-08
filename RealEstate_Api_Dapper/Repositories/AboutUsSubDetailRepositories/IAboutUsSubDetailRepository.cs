using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;

public interface IAboutUsSubDetailRepository
{
    Task<List<GetAllAboutUsSubDetailResponseDto>> GetAllAboutUsSubDetailAsync();
    void CreateAboutUsSubDetail(CreateAboutUsSubDetailRequestDto createAboutUsSubDetailRequestDto);
    void UpdateAboutUsSubDetail(UpdateAboutUsSubDetailRequestDto updateAboutUsSubDetailRequestDto);
    void DeleteAboutUsSubDetail(int id);
    Task<GetAboutUsSubDetailByIdResponseDto> GetAboutUsSubDetailByIdAsync(int id);
}
