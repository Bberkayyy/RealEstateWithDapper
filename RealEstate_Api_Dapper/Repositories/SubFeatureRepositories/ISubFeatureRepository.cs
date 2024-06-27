using RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Requests;
using RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.SubFeatureRepositories;

public interface ISubFeatureRepository
{
    Task<List<GetAllSubFeatureResponseDto>> GetAllSubFeatureAsync();
    Task CreateSubFeatureAsync(CreateSubFeatureRequestDto createSubFeatureRequestDto);
    Task UpdateSubFeatureAsync(UpdateSubFeatureRequestDto updateSubFeatureRequestDto);
    Task DeleteSubFeatureAsync(int id);
    Task<GetSubFeatureByIdResponseDto> GetSubFeatureByIdAsync(int id);
}
