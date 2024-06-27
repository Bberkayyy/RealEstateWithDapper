using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models.ProductDetailsModels;
using RealEstate_UI_Dapper.Models.ProductModels;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace RealEstate_UI_Dapper.Controllers;

public class PropertyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PropertyController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/Products/ProductListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultProductViewModel>? values = JsonConvert.DeserializeObject<List<ResultProductViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> PropertyDetail(int id)
    {
        ViewBag.productId = id;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/ProductDetails/GetByProductId?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultProductDetailsViewModel? value = JsonConvert.DeserializeObject<ResultProductDetailsViewModel>(jsonData);
            ViewBag.location = ExtractPlaceName(value.location);
            ViewBag.video = ConvertToEmbedUrl(value.videoUrl);
            return View();
        }
        return View();
    }
    public async Task<IActionResult> FilteredIndex(string containsWord, int categoryId, string city)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:7221/api/Products/ProductListBySearchFilterWithRelationships?containsWord={containsWord}&categoryId={categoryId}&city={city}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultProductViewModel>? values = JsonConvert.DeserializeObject<List<ResultProductViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    private string ExtractPlaceName(string url)
    {
        try
        {
            var uri = new Uri(url);
            string path = uri.AbsolutePath;
            var regex = new Regex(@"^/maps/place/(.*?)(/|@|$)");
            var match = regex.Match(path);

            if (match.Success)
            {
                string placeNameEncoded = match.Groups[1].Value;
                string placeName = Uri.UnescapeDataString(placeNameEncoded);
                placeName = placeName.Replace('+', ' ');
                return $"https://www.google.com/maps?q={placeName}&z=15&output=embed";
            }
            else
            {
                return "Yer adı bulunamadı.";
            }
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
    private string ConvertToEmbedUrl(string youtubeUrl)
    {
        try
        {
            var uri = new Uri(youtubeUrl);
            if (!uri.Host.Contains("youtube.com") || !uri.AbsolutePath.Contains("/watch"))
            {
                return string.Empty;
            }

            var query = HttpUtility.ParseQueryString(uri.Query);
            string videoId = query["v"];
            if (string.IsNullOrEmpty(videoId))
            {
                return string.Empty;
            }

            return $"https://www.youtube.com/embed/{videoId}";
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
    /*https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d387190.2895687731!2d-74.26055986835598!3d40.697668402590374!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89c24fa5d33f083b%3A0xc80b8f06e177fe62!2sNew+York%2C+NY%2C+USA!5e0!3m2!1sen!2sin!4v1562582305883!5m2!1sen!2sin */
}
