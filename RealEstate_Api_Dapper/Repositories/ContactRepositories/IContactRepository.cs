using RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ContactRepositories;

public interface IContactRepository
{
    Task<List<GetAllContactResponseDto>> GetAllContactAsync();
    Task<List<GetLast4ContactResponseDto>> GetLast4ContactAsync();
    void CreateContact(CreateContactRequestDto createContactRequestDto);
    void UpdateContact(UpdateContactRequestDto updateContactRequestDto);
    void DeleteContact(int id);
    Task<GetContactByIdResponseDto> GetContactByIdAsync(int id);
}
