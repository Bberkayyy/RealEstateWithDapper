using RealEstate_Api_Dapper.Dtos.LocationDtos.Requests;
using RealEstate_Api_Dapper.Dtos.LocationDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.LocationRepositories;

public interface ILocationRepository
{
    Task<List<GetAllLocationResponseDto>> GetAllLocationAsync();
    Task CreateLocationAsync(CreateLocationRequestDto createLocationRequestDto);
    Task UpdateLocationAsync(UpdateLocationRequestDto updateLocationRequestDto);
    Task DeleteLocationAsync(int id);
    Task<GetLocationByIdResponseDto> GetLocationByIdAsync(int id);
}
