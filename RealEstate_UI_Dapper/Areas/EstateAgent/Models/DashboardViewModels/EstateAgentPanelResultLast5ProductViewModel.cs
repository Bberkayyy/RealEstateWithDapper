namespace RealEstate_UI_Dapper.Areas.EstateAgent.Models.DashboardViewModels;

public class EstateAgentPanelResultLast5ProductViewModel
{
    public int id { get; set; }
    public string title { get; set; }
    public decimal price { get; set; }
    public string coverImage { get; set; }
    public string city { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public bool dealOfTheDay { get; set; }
    public DateTime createdDate { get; set; }
    public string categoryName { get; set; }
    public string employeeName { get; set; }
}
