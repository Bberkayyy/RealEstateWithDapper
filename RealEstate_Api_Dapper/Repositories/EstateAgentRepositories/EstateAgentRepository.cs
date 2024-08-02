using Dapper;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EstateAgentDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.EstateAgentRepositories;

public class EstateAgentRepository : IEstateAgentRepository
{
    private readonly Context _context;

    public EstateAgentRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateEstateAgentAsync(CreateEstateAgentRequestDto createEstateAgentRequestDto)
    {
        string query = "insert into TblEstateAgent (FullName,Title,Mail,PhoneNumber,ImageUrl,Status) values (@fullName,@title,@mail,@phoneNumber,@imageUrl,@status)";
        DynamicParameters parameters = new();
        parameters.Add("@fullName", createEstateAgentRequestDto.FullName);
        parameters.Add("@title", createEstateAgentRequestDto.Title);
        parameters.Add("@mail", createEstateAgentRequestDto.Mail);
        parameters.Add("@phoneNumber", createEstateAgentRequestDto.PhoneNumber);
        parameters.Add("@imageUrl", createEstateAgentRequestDto.ImageUrl);
        parameters.Add("@status", true);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteEstateAgentAsync(int id)
    {
        string query = "delete from TblEstateAgent where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllEstateAgentResponseDto>> GetAllEstateAgentAsync()
    {
        string query = "select * from TblEstateAgent";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllEstateAgentResponseDto> values = await connection.QueryAsync<GetAllEstateAgentResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetEstateAgentByIdResponseDto> GetEstateAgentByIdAsync(int id)
    {
        string query = "select * from TblEstateAgent where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetEstateAgentByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetEstateAgentByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateEstateAgentAsync(UpdateEstateAgentRequestDto updateEstateAgentRequestDto)
    {
        string query = "update TblEstateAgent set FullName = @fullName, Title = @title, Mail = @mail, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@fullName", updateEstateAgentRequestDto.FullName);
        parameters.Add("@title", updateEstateAgentRequestDto.Title);
        parameters.Add("@mail", updateEstateAgentRequestDto.Mail);
        parameters.Add("@phoneNumber", updateEstateAgentRequestDto.PhoneNumber);
        parameters.Add("@imageUrl", updateEstateAgentRequestDto.ImageUrl);
        parameters.Add("@status", updateEstateAgentRequestDto.Status);
        parameters.Add("@id", updateEstateAgentRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
