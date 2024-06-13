namespace RealEstate_Api_Dapper.Dtos.MessageDtos.Responses;

public class GetLast5MessageByReceiverIdResponseDto
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime SendDate { get; set; }
    public bool IsRead { get; set; }
}
