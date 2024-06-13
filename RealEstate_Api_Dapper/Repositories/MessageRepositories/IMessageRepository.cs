using RealEstate_Api_Dapper.Dtos.MessageDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.MessageRepositories;

public interface IMessageRepository
{
    Task<List<GetLast5MessageByReceiverIdResponseDto>> GetLast5MessageByReceiverId(int id);
    Task<List<GetLast5MessageByReceiverIdWithRelationshipsResponseDto>> GetLast5MessageByReceiverIdWithRelationships(int id);
}
