using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ClientDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ClientDtos.Responses;
using RealEstate_Api_Dapper.Repositories.ClientRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _clientRepository;

    public ClientsController(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ClientList()
    {
        List<GetAllClientResponseDto> values = await _clientRepository.GetAllClientAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientRequestDto createClientRequestDto)
    {
        _clientRepository.CreateClient(createClientRequestDto);
        return Ok("Müşteri Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteClient(int id)
    {
        _clientRepository.DeleteClient(id);
        return Ok("Müşteri Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateClient(UpdateClientRequestDto updateClientRequestDto)
    {
        _clientRepository.UpdateClient(updateClientRequestDto);
        return Ok("Müşteri Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClientById(int id)
    {
        GetClientByIdResponseDto value = await _clientRepository.GetClientByIdAsync(id);
        return Ok(value);
    }
}
