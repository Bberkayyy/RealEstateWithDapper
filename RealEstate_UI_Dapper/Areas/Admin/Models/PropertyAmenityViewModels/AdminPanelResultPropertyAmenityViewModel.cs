namespace RealEstate_UI_Dapper.Areas.Admin.Models.PropertyAmenityViewModels;

public class AdminPanelResultPropertyAmenityViewModel
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string AmenityTitle { get; set; }
    public bool DoesHave { get; set; }
}
