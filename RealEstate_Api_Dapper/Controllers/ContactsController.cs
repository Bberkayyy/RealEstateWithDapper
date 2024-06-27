using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Responses;
using RealEstate_Api_Dapper.Repositories.ContactRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IContactRepository _ContactRepository;

    public ContactsController(IContactRepository ContactRepository)
    {
        _ContactRepository = ContactRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ContactList()
    {
        List<GetAllContactResponseDto> values = await _ContactRepository.GetAllContactAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateContact(CreateContactRequestDto createContactRequestDto)
    {
        await _ContactRepository.CreateContactAsync(createContactRequestDto);
        return Ok("İletişim Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteContact(int id)
    {
        await _ContactRepository.DeleteContactAsync(id);
        return Ok("İletişim Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateContact(UpdateContactRequestDto updateContactRequestDto)
    {
        await _ContactRepository.UpdateContactAsync(updateContactRequestDto);
        return Ok("İletişim Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetContactById(int id)
    {
        GetContactByIdResponseDto value = await _ContactRepository.GetContactByIdAsync(id);
        return Ok(value);
    }
    [HttpGet("Last4ContactList")]
    public async Task<IActionResult> Last4ContactList()
    {
        List<GetLast4ContactResponseDto> value = await _ContactRepository.GetLast4ContactAsync();
        return Ok(value);
    }
}
