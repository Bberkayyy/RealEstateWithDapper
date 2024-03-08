using RealEstate_Api_Dapper.Dtos.LocationDtos.Requests;
using RealEstate_Api_Dapper.Dtos.LocationDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.LocationRepositories;

public interface ILocationRepository
{
    Task<List<GetAllLocationResponseDto>> GetAllLocationAsync();
    void CreateLocation(CreateLocationRequestDto createLocationRequestDto);
    void UpdateLocation(UpdateLocationRequestDto updateLocationRequestDto);
    void DeleteLocation(int id);
    Task<GetLocationByIdResponseDto> GetLocationByIdAsync(int id);
}
