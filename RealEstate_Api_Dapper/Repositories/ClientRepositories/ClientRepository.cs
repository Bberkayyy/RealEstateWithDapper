using Dapper;
using RealEstate_Api_Dapper.Dtos.ClientDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ClientDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.ClientRepositories;

public class ClientRepository : IClientRepository
{
    private readonly Context _context;

    public ClientRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateClientAsync(CreateClientRequestDto createClientRequestDto)
    {
        string query = "insert into TblClient (FullName,Title,Comment,Status) values (@fullName,@title,@comment,@status)";
        DynamicParameters parameters = new();
        parameters.Add("@fullName", createClientRequestDto.FullName);
        parameters.Add("@title", createClientRequestDto.Title);
        parameters.Add("@comment", createClientRequestDto.Comment);
        parameters.Add("@status", false);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteClientAsync(int id)
    {
        string query = "delete from TblClient where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllClientResponseDto>> GetAllClientAsync()
    {
        string query = "select * from TblClient";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllClientResponseDto> values = await connection.QueryAsync<GetAllClientResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetClientByIdResponseDto> GetClientByIdAsync(int id)
    {
        string query = "select * from TblClient where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetClientByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetClientByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateClientAsync(UpdateClientRequestDto updateClientRequestDto)
    {
        string query = "update TblClient set FullName = @fullName, Title = @title, Comment = @comment, Status = @status where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@fullName", updateClientRequestDto.FullName);
        parameters.Add("@title", updateClientRequestDto.Title);
        parameters.Add("@comment", updateClientRequestDto.Comment);
        parameters.Add("@status", updateClientRequestDto.Status);
        parameters.Add("@id", updateClientRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
