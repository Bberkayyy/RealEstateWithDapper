namespace RealEstate_UI_Dapper.Models.ProductDetailsModels;

public class ResultProductDetailsViewModel
{
    public int id { get; set; }
    public int productId { get; set; }
    public int productSize { get; set; }
    public int bedroomCount { get; set; }
    public int bathCount { get; set; }
    public int roomCount { get; set; }
    public int garageSize { get; set; }
    public string buildYear { get; set; }
    public double price { get; set; }
    public string location { get; set; }
    public string videoUrl { get; set; }
}
