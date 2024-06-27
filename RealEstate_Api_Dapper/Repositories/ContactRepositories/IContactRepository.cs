using RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ContactRepositories;

public interface IContactRepository
{
    Task<List<GetAllContactResponseDto>> GetAllContactAsync();
    Task<List<GetLast4ContactResponseDto>> GetLast4ContactAsync();
    Task CreateContactAsync(CreateContactRequestDto createContactRequestDto);
    Task UpdateContactAsync(UpdateContactRequestDto updateContactRequestDto);
    Task DeleteContactAsync(int id);
    Task<GetContactByIdResponseDto> GetContactByIdAsync(int id);
}
