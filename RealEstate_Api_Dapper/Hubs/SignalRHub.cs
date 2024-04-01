using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;

namespace RealEstate_Api_Dapper.Hubs;

public class SignalRHub : Hub
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SignalRHub(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task SendCategoryCount()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessageCategoryCount = await client.GetAsync("https://localhost:7221/api/Statistics/CategoryCount");
        string jsonDataCategoryCount = await responseMessageCategoryCount.Content.ReadAsStringAsync();
        await Clients.All.SendAsync("receiveCategoryCount", jsonDataCategoryCount);
    }
    public async Task GetTodoList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:7221/api/ToDoLists");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        List<GetAllToDoListResponseDto>? values = JsonConvert.DeserializeObject<List<GetAllToDoListResponseDto>>(jsonData);
        await Clients.All.SendAsync("receiveTodoList", values);
    }
}