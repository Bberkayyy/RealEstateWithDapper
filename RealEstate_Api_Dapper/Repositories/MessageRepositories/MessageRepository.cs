using Dapper;
using RealEstate_Api_Dapper.Dtos.MessageDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.MessageRepositories;

public class MessageRepository : IMessageRepository
{
    private readonly Context _context;

    public MessageRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<GetLast5MessageByReceiverIdResponseDto>> GetLast5MessageByReceiverIdAsync(int id)
    {
        string query = "Select Top(5)* from TblMessage where ReceiverId=@receiverId order by Id desc";
        DynamicParameters parameters = new();
        parameters.Add("@receiverId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast5MessageByReceiverIdResponseDto> values = await connection.QueryAsync<GetLast5MessageByReceiverIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetLast5MessageByReceiverIdWithRelationshipsResponseDto>> GetLast5MessageByReceiverIdWithRelationshipsAsync(int id)
    {
        string query = "Select Top(5) TblMessage.Id, Sender.Name as SenderName, Receiver.Name as ReceiverName, TblMessage.Subject, TblMessage.Content, TblMessage.SendDate, TblMessage.IsRead From TblMessage inner join TblAppUser as Sender on TblMessage.SenderId=Sender.Id inner join TblAppUser as Receiver on TblMessage.ReceiverId = Receiver.Id where TblMessage.ReceiverId = @receiverId order by Id desc";
        DynamicParameters parameters = new();
        parameters.Add("@receiverId", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast5MessageByReceiverIdWithRelationshipsResponseDto> values = await connection.QueryAsync<GetLast5MessageByReceiverIdWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }
}
