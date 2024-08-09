using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.PropertyDetailRepositories;

public interface IPropertyDetailRepository
{
    Task CreatePropertyDetailAsync(CreatePropertyDetailRequestDto createPropertyDetailDto);
    Task UpdatePropertyDetailAsync(UpdatePropertyDetailRequestDto updatePropertyDetailDto);
    Task DeletePropertyDetailAsync(int id);
    Task<GetPropertyDetailByPropertyIdResponseDto> GetPropertyDetailByPropertyIdAsync(int id);
}
