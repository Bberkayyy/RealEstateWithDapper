using Dapper;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsDetailDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.AboutUsDetailRepositories;

public class AboutUsDetailRepository : IAboutUsDetailRepository
{
    private readonly Context _context;

    public AboutUsDetailRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateAboutUsDetailAsync(CreateAboutUsDetailRequestDto createAboutUsDetailRequestDto)
    {
        string query = "Insert into TblAboutUsDetail (Title,Subtitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
        DynamicParameters parameters = new();
        parameters.Add("@title", createAboutUsDetailRequestDto.Title);
        parameters.Add("@subtitle", createAboutUsDetailRequestDto.Subtitle);
        parameters.Add("@description1", createAboutUsDetailRequestDto.Description1);
        parameters.Add("@description2", createAboutUsDetailRequestDto.Description2);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteAboutUsDetailAsync(int id)
    {
        string query = "Delete From TblAboutUsDetail where Id=@id ";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetAboutUsDetailByIdResponseDto> GetAboutUsDetailByIdAsync(int id)
    {
        string query = "Select * From TblAboutUsDetail where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetAboutUsDetailByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetAboutUsDetailByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetAllAboutUsDetailResponseDto>> GetAllAboutUsDetailAsync()
    {
        string query = "Select * From TblAboutUsDetail";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllAboutUsDetailResponseDto> values = await connection.QueryAsync<GetAllAboutUsDetailResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task UpdateAboutUsDetailAsync(UpdateAboutUsDetailRequestDto updateAboutUsDetailRequestDto)
    {
        string query = "Update TblAboutUsDetail Set Title=@title, Subtitle=@subtitle, Description1=@description1, Description2=@description2 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", updateAboutUsDetailRequestDto.Id);
        parameters.Add("@title", updateAboutUsDetailRequestDto.Title);
        parameters.Add("@subtitle", updateAboutUsDetailRequestDto.Subtitle);
        parameters.Add("@description1", updateAboutUsDetailRequestDto.Description1);
        parameters.Add("@description2", updateAboutUsDetailRequestDto.Description2);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
