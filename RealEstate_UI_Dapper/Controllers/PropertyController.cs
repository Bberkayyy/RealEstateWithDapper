using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Models.PropertyDetailsModels;
using RealEstate_UI_Dapper.Models.PropertyModels;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

namespace RealEstate_UI_Dapper.Controllers;

public class PropertyController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ApiSettings _apiSettings;

    public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
    {
        _httpClientFactory = httpClientFactory;
        _apiSettings = apiSettings.Value;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Properties/PropertyListWithRelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultPropertyViewModel>? values = JsonConvert.DeserializeObject<List<ResultPropertyViewModel>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet("property/propertydetail/{slug}/{id}")]
    public async Task<IActionResult> PropertyDetail(int id)
    {
        ViewBag.PropertyId = id;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "PropertyDetails/GetByPropertyId?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultPropertyDetailsViewModel? value = JsonConvert.DeserializeObject<ResultPropertyDetailsViewModel>(jsonData);
            ViewBag.location = ExtractPlaceName(value.location);
            ViewBag.video = ConvertToEmbedUrl(value.videoUrl);
            return View();
        }
        return View();
    }
    public async Task<IActionResult> FilteredIndex(string containsWord, int categoryId, string city)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Properties/PropertyListBySearchFilterWithRelationships?containsWord={containsWord}&categoryId={categoryId}&city={city}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            List<ResultPropertyViewModel>? values = JsonConvert.DeserializeObject<List<ResultPropertyViewModel>>(jsonData);
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
}
