using RealEstate_Api_Dapper.Dtos.PropertyDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.PropertyRepositories;

public interface IPropertyRepository
{
    Task<List<GetAllPropertyResponseDto>> GetAllPropertyAsync();
    Task<List<GetAllPropertyWithRelationshipsResponseDto>> GetAllPropertyWithRelationshipsAsync();
    Task<CreatedPropertyResponseDto> CreatePropertyAsync(CreatePropertyRequestDto createPropertyRequestDto);
    Task UpdatePropertyAsync(UpdatePropertyRequestDto updatePropertyRequestDto);
    Task DeletePropertyAsync(int id);
    Task<GetPropertyByIdResponseDto> GetPropertyByIdAsync(int id);
    Task<GetPropertyByIdWithRelationshipsResponseDto> GetPropertyByIdWithRelationshipsAsync(int id);
    Task PropertyDealOfTheDayStatusChangeToTrueAsync(int id);
    Task PropertyDealOfTheDayStatusChangeToFalseAsync(int id);
    Task<List<GetLast5PropertyResponseDto>> GetLast5PropertyAsync();
    Task<List<GetLast5PropertyWithRelationshipsResponseDto>> GetLast5PropertyWithRelationshipsAsync();
    Task<List<GetLast3PropertyResponseDto>> GetLast3PropertyAsync();
    Task<List<GetLast3PropertyWithRelationshipsResponseDto>> GetLast3PropertyWithRelationshipsAsync();
    Task<List<GetPropertyListByEstateAgentIdResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveTrueAsync(int id);
    Task<List<GetPropertyListByEstateAgentIdResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveFalseAsync(int id);
    Task<List<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveTrueWithRelationshipsAsync(int id);
    Task<List<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveFalseWithRelationshipsAsync(int id);
    Task PropertyIsActiveChangeToTrueAsync(int id);
    Task PropertyIsActiveChangeToFalseAsync(int id);
    Task<List<GetPropertyListBySearchFilterWithRelationshipsResponseDto>> GetPropertyListBySearchFilterWithRelationshipsAsync(string containsWord, int categoryId, string city);
    Task<List<GetPropertyListByDealOfTheDayTrueWithRelationshipsResponseDto>> GetPropertyListByDealOfTheDayTrueWithRelationshipsAsync();
}
