using RealEstate_Api_Dapper.Dtos.AmenityDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.AmenityRepositories;

public interface IAmenityRepository
{
    Task<List<GetAllAmenityResponseDto>> GetAllAmenityAsync();
    Task CreateAmenity(CreateAmenityRequestDto createAmenityRequestDto);
    Task UpdateAmenity(UpdateAmenityRequestDto updateAmenityRequestDto);
    Task DeleteAmenity(int id);
}
