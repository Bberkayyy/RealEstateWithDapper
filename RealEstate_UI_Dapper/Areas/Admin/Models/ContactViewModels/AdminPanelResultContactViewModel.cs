namespace RealEstate_UI_Dapper.Areas.Admin.Models.DashboardViewModels;

public class AdminPanelResultContactViewModel
{
    public int id { get; set; }
    public string name { get; set; }
    public string subject { get; set; }
    public string email { get; set; }
    public string message { get; set; }
    public DateTime sendDate { get; set; }
}
