using RealEstate_Api_Dapper.Dtos.MessageDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.MessageRepositories;

public interface IMessageRepository
{
    Task<List<GetLast5MessageByReceiverIdResponseDto>> GetLast5MessageByReceiverIdAsync(int id);
    Task<List<GetLast5MessageByReceiverIdWithRelationshipsResponseDto>> GetLast5MessageByReceiverIdWithRelationshipsAsync(int id);
}
