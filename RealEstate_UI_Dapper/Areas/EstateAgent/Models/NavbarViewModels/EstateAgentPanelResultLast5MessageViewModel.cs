namespace RealEstate_UI_Dapper.Areas.EstateAgent.Models.NavbarViewModels;

public class EstateAgentPanelResultLast5MessageViewModel
{
    public int id { get; set; }
    public string senderName { get; set; }
    public string receiverName { get; set; }
    public string subject { get; set; }
    public string content { get; set; }
    public DateTime sendDate { get; set; }
    public bool isRead { get; set; }
}
