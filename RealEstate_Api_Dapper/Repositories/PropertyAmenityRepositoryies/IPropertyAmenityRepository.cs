using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.PropertyAmenityRepositoryies;

public interface IPropertyAmenityRepository
{
    Task<List<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto>> GetPropertyAmenityListByPropertyIdAndDoesHaveTrueAsync(int propertyId);
    Task CreatePropertyAmenityAsync(CreatePropertyAmenityRequestDto createPropertyAmenityDto);
    Task<List<GetPropertyAmenityListByPropertyIdResponseDto>> GetPropertyAmenityListByPropertyIdAsync(int propertyId);
    Task PropertyAmenityChangeDoesHaveToTrueAsync(int id);
    Task PropertyAmenityChangeDoesHaveToFalseAsync(int id);
}
