namespace RealEstate_UI_Dapper.Areas.EstateAgent.Models.ProductViewModels;

public class EstateAgentPanelCreateAdvertViewModel
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string CoverImage { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public bool DealOfTheDay { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public int CategoryId { get; set; }
    public int EstateAgentId { get; set; }
}
