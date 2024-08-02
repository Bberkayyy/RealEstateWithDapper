using RealEstate_Api_Dapper.Dtos.PropertyDetailDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.PropertyDetailRepositories;

public interface IPropertyDetailRepository
{
    Task<GetPropertyDetailByPropertyIdResponseDto> GetPropertyDetailByPropertyIdAsync(int id);
}
