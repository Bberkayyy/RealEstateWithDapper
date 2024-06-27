using Dapper;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.EmployeeRepositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly Context _context;

    public EmployeeRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateEmployeeAsync(CreateEmployeeRequestDto createEmployeeRequestDto)
    {
        string query = "insert into TblEmployee (FullName,Title,Mail,PhoneNumber,ImageUrl,Status) values (@fullName,@title,@mail,@phoneNumber,@imageUrl,@status)";
        DynamicParameters parameters = new();
        parameters.Add("@fullName", createEmployeeRequestDto.FullName);
        parameters.Add("@title", createEmployeeRequestDto.Title);
        parameters.Add("@mail", createEmployeeRequestDto.Mail);
        parameters.Add("@phoneNumber", createEmployeeRequestDto.PhoneNumber);
        parameters.Add("@imageUrl", createEmployeeRequestDto.ImageUrl);
        parameters.Add("@status", true);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        string query = "delete from TblEmployee where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllEmployeeResponseDto>> GetAllEmployeeAsync()
    {
        string query = "select * from TblEmployee";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllEmployeeResponseDto> values = await connection.QueryAsync<GetAllEmployeeResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetEmployeeByIdResponseDto> GetEmployeeByIdAsync(int id)
    {
        string query = "select * from TblEmployee where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetEmployeeByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetEmployeeByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateEmployeeAsync(UpdateEmployeeRequestDto updateEmployeeRequestDto)
    {
        string query = "update TblEmployee set FullName = @fullName, Title = @title, Mail = @mail, PhoneNumber = @phoneNumber, ImageUrl = @imageUrl, Status = @status where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@fullName", updateEmployeeRequestDto.FullName);
        parameters.Add("@title", updateEmployeeRequestDto.Title);
        parameters.Add("@mail", updateEmployeeRequestDto.Mail);
        parameters.Add("@phoneNumber", updateEmployeeRequestDto.PhoneNumber);
        parameters.Add("@imageUrl", updateEmployeeRequestDto.ImageUrl);
        parameters.Add("@status", updateEmployeeRequestDto.Status);
        parameters.Add("@id", updateEmployeeRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
