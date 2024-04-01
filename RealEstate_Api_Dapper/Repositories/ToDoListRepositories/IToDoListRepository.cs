using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ToDoListRepositories;

public interface IToDoListRepository
{
    Task<List<GetAllToDoListResponseDto>> GetAllToDoListAsync();
    void CreateToDoList(CreateToDoListRequestDto createToDoListRequestDto);
    void UpdateToDoList(UpdateToDoListRequestDto updateToDoListRequestDto);
    void DeleteToDoList(int id);
    Task<GetToDoListByIdResponseDto> GetToDoListByIdAsync(int id);
    void ToDoStatusChangeToTrue(int id);
    void ToDoStatusChangeToFalse(int id);
}
