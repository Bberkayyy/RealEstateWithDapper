using Dapper;
using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Requests;
using RealEstate_Api_Dapper.Dtos.BottomGridDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.BottomGridRepositories;

public class BottomGridRepository : IBottomGridRepository
{
    private readonly Context _context;

    public BottomGridRepository(Context context)
    {
        _context = context;
    }

    public async void CreateBottomGrid(CreateBottomGridRequestDto createBottomGridRequestDto)
    {
        string query = "Insert into TblBottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
        DynamicParameters parameters = new();
        parameters.Add("@icon", createBottomGridRequestDto.Icon);
        parameters.Add("@title", createBottomGridRequestDto.Title);
        parameters.Add("@description", createBottomGridRequestDto.Description);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteBottomGrid(int id)
    {
        string query = "Delete From TblBottomGrid where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllBottomGridResponseDto>> GetAllBottomGridAsync()
    {
        string query = "Select * from TblBottomGrid";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllBottomGridResponseDto> values = await connection.QueryAsync<GetAllBottomGridResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetBottomGridByIdResponseDto> GetBottomGridByIdAsync(int id)
    {
        string query = "Select * from TblBottomGrid where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetBottomGridByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetBottomGridByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async void UpdateBottomGrid(UpdateBottomGridRequestDto updateBottomGridRequestDto)
    {
        string query = "Update TblBottomGrid set Icon = @icon, Title = @title, Description = @description where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@icon", updateBottomGridRequestDto.Icon);
        parameters.Add("@title", updateBottomGridRequestDto.Title);
        parameters.Add("@description", updateBottomGridRequestDto.Description);
        parameters.Add("@id", updateBottomGridRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
