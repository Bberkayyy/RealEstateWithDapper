using RealEstate_Api_Dapper.Dtos.PropertyAmenityDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.PropertyAmenityRepositoryies;

public interface IPropertyAmenityRepository
{
    Task<List<GetPropertyAmenityListByPropertyIdAndDoesHaveTrueResponseDto>> GetPropertyAmenityListByPropertyIdAndDoesHaveTrueAsync(int propertyId);
}
