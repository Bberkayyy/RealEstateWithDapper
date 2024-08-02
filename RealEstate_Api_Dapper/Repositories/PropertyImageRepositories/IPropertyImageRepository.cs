using RealEstate_Api_Dapper.Dtos.PropertyDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;
using RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyImageDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.PropertyImageRepositories;

public interface IPropertyImageRepository
{
    Task<List<GetAllPropertyImagesResponseDto>> GetAllPropertyImageAsync();
    Task CreatePropertyImageAsync(CreatePropertyImageRequestDto createPropertyRequestDto);
    Task UpdatePropertyImageAsync(UpdatePropertyImageRequestDto updatePropertyRequestDto);
    Task DeletePropertyImageAsync(int id);
    Task<GetPropertyImageByIdResponseDto> GetPropertyImageByIdAsync(int id);
    Task<List<GetPropertyImagesByPropertyIdResponseDto>> GetPropertyImagesByPropertyIdAsync(int id);
}
