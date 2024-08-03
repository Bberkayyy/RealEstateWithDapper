namespace RealEstate_UI_Dapper.Models.PropertyModels;

public class ResultPropertyWithRelationshipsViewModel
{
    public int id { get; set; }
    public string title { get; set; }
    public string slugUrl { get; set; }
    public decimal price { get; set; }
    public string coverImage { get; set; }
    public string city { get; set; }
    public string district { get; set; }
    public string address { get; set; }
    public string description { get; set; }
    public string type { get; set; }
    public bool DealOfTheDay { get; set; }
    public DateTime CreatedDate { get; set; }
    public string categoryName { get; set; }
    public string estateAgentName { get; set; }
}
