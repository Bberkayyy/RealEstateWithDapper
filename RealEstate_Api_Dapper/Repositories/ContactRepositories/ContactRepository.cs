using Dapper;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ContactDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.ContactRepositories;

public class ContactRepository : IContactRepository
{
    private readonly Context _context;

    public ContactRepository(Context context)
    {
        _context = context;
    }

    public async void CreateContact(CreateContactRequestDto createContactRequestDto)
    {
        string query = "insert into TblContact Name,Subject,Email,Message,SendDate values (@name,@subject,@email,@message,@sendDate)";
        DynamicParameters parameters = new();
        parameters.Add("@name", createContactRequestDto.Name);
        parameters.Add("@subject", createContactRequestDto.Subject);
        parameters.Add("@email", createContactRequestDto.Email);
        parameters.Add("@message", createContactRequestDto.Message);
        parameters.Add("@sendDate", DateTime.Now);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteContact(int id)
    {
        string query = "delete * from TblContact where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllContactResponseDto>> GetAllContactAsync()
    {
        string query = "select * from TblContact";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllContactResponseDto> values = await connection.QueryAsync<GetAllContactResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetContactByIdResponseDto> GetContactByIdAsync(int id)
    {
        string query = "select * from TblContact where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetContactByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetContactByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetLast4ContactResponseDto>> GetLast4ContactAsync()
    {
        string query = "select top(4) * from TblContact order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast4ContactResponseDto> values = await connection.QueryAsync<GetLast4ContactResponseDto>(query);
            return values.ToList();
        }
    }

    public async void UpdateContact(UpdateContactRequestDto updateContactRequestDto)
    {
        string query = "Update TblContact set Name = @name, Subject = @subject, Email = @email,Message = @message where Id=@id)";
        DynamicParameters parameters = new();
        parameters.Add("@name", updateContactRequestDto.Name);
        parameters.Add("@subject", updateContactRequestDto.Subject);
        parameters.Add("@email", updateContactRequestDto.Email);
        parameters.Add("@message", updateContactRequestDto.Message);
        parameters.Add("@id", updateContactRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
