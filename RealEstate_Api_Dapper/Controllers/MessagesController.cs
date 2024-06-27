using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.MessageDtos.Responses;
using RealEstate_Api_Dapper.Repositories.MessageRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageRepository _messageRepository;

    public MessagesController(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    [HttpGet("Last5MessageByReceiverId")]
    public async Task<IActionResult> GetLast5MessageByReceiverId(int id)
    {
        List<GetLast5MessageByReceiverIdResponseDto> values = await _messageRepository.GetLast5MessageByReceiverIdAsync(id);
        return Ok(values);
    }
    [HttpGet("Last5MessageByReceiverIdWithRelationships")]
    public async Task<IActionResult> GetLast5MessageByReceiverIdWithRelationships(int id)
    {
        List<GetLast5MessageByReceiverIdWithRelationshipsResponseDto> values = await _messageRepository.GetLast5MessageByReceiverIdWithRelationshipsAsync(id);
        return Ok(values);
    }
}
