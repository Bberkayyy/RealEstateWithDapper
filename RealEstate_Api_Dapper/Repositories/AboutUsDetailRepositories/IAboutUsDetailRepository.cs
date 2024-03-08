using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;

public interface IAboutUsDetailRepository
{
    Task<List<GetAllAboutUsDetailResponseDto>> GetAllAboutUsDetailAsync();
    void CreateAboutUsDetail(CreateAboutUsDetailRequestDto createAboutUsDetailRequestDto);
    void UpdateAboutUsDetail(UpdateAboutUsDetailRequestDto updateAboutUsDetailRequestDto);
    void DeleteAboutUsDetail(int id);
    Task<GetAboutUsDetailByIdResponseDto> GetAboutUsDetailByIdAsync(int id);
}
