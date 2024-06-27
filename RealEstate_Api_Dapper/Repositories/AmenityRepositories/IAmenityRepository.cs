using RealEstate_Api_Dapper.Dtos.AmenityDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.AmenityRepositories;

public interface IAmenityRepository
{
    Task<List<GetAllAmenityResponseDto>> GetAllAmenityAsync();
    Task CreateAmenityAsync(CreateAmenityRequestDto createAmenityRequestDto);
    Task UpdateAmenityAsync(UpdateAmenityRequestDto updateAmenityRequestDto);
    Task DeleteAmenityAsync(int id);
}
