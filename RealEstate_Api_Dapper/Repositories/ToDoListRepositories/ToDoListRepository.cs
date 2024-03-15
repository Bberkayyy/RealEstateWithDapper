using Dapper;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Responses;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ToDoListDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.ToDoListRepositories;

public class ToDoListRepository : IToDoListRepository
{
    private readonly Context _context;

    public ToDoListRepository(Context context)
    {
        _context = context;
    }

    public async void CreateToDoList(CreateToDoListRequestDto createToDoListRequestDto)
    {
        string query = "insert into TblToDoList Description,Status values (@description,@status)";
        DynamicParameters parameters = new();
        parameters.Add("@description", createToDoListRequestDto.Description);
        parameters.Add("@status", false);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteToDoList(int id)
    {
        string query = "delete * from TblStatus where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllToDoListResponseDto>> GetAllToDoListAsync()
    {
        string query = "select * from TblToDoList";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllToDoListResponseDto> values = await connection.QueryAsync<GetAllToDoListResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetToDoListByIdResponseDto> GetToDoListByIdAsync(int id)
    {
        string query = "select * from TblToDoList where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetToDoListByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetToDoListByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async void UpdateToDoList(UpdateToDoListRequestDto updateToDoListRequestDto)
    {
        string query = "Update TblToDoList set Description = @description, Status = @status where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@description", updateToDoListRequestDto.Description);
        parameters.Add("@status", updateToDoListRequestDto.Status);
        parameters.Add("@status", updateToDoListRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
