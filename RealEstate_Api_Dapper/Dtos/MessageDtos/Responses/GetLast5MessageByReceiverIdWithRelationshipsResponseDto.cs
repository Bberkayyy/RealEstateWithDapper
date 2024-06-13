namespace RealEstate_Api_Dapper.Dtos.MessageDtos.Responses;

public class GetLast5MessageByReceiverIdWithRelationshipsResponseDto
{
    public int Id { get; set; }
    public string SenderName { get; set; }
    public string ReceiverName { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public DateTime SendDate { get; set; }
    public bool IsRead { get; set; }
}
