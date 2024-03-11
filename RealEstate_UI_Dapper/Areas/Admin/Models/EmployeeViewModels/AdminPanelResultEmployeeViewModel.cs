namespace RealEstate_UI_Dapper.Areas.Admin.Models.EmployeeViewModels;

public class AdminPanelResultEmployeeViewModel
{
    public int id { get; set; }
    public string fullName { get; set; }
    public string title { get; set; }
    public string mail { get; set; }
    public string phoneNumber { get; set; }
    public string imageUrl { get; set; }
    public bool status { get; set; }
}
