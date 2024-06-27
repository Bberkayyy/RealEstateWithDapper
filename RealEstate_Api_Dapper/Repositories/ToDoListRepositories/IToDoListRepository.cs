using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.ToDoListRepositories;

public interface IToDoListRepository
{
    Task<List<GetAllToDoListResponseDto>> GetAllToDoListAsync();
    Task CreateToDoListAsync(CreateToDoListRequestDto createToDoListRequestDto);
    Task UpdateToDoListAsync(UpdateToDoListRequestDto updateToDoListRequestDto);
    Task DeleteToDoListAsync(int id);
    Task<GetToDoListByIdResponseDto> GetToDoListByIdAsync(int id);
    Task ToDoStatusChangeToTrueAsync(int id);
    Task ToDoStatusChangeToFalseAsync(int id);
}
