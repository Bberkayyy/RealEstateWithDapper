namespace RealEstate_UI_Dapper.Models.PropertyDetailsModels;

public class ResultPropertyDetailsViewModel
{
    public int id { get; set; }
    public int propertyId { get; set; }
    public int propertySize { get; set; }
    public int bedroomCount { get; set; }
    public int bathCount { get; set; }
    public int roomCount { get; set; }
    public int garageSize { get; set; }
    public string buildYear { get; set; }
    public double price { get; set; }
    public string location { get; set; }
    public string videoUrl { get; set; }
}
