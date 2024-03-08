using Dapper;
using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AboutUsSubDetailDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.AboutUsSubDetailRepositories;

public class AboutUsSubDetailRepository : IAboutUsSubDetailRepository
{
    private readonly Context _context;

    public AboutUsSubDetailRepository(Context context)
    {
        _context = context;
    }

    public async void CreateAboutUsSubDetail(CreateAboutUsSubDetailRequestDto createAboutUsSubDetailRequestDto)
    {
        string query = "Inser into TblAboutUsSubDetail (Name,Status) values (@aboutUsSubDetailName,@aboutUsSubDetailStatus)";
        DynamicParameters parameters = new();
        parameters.Add("@aboutUsSubDetailName", createAboutUsSubDetailRequestDto.Name);
        parameters.Add("@aboutUsSubDetailStatus", true);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteAboutUsSubDetail(int id)
    {
        string query = "Delete from TblAboutUsSubDetail where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetAboutUsSubDetailByIdResponseDto> GetAboutUsSubDetailByIdAsync(int id)
    {
        string query = "Select * from TblAboutUsSubDetail where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetAboutUsSubDetailByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetAboutUsSubDetailByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetAllAboutUsSubDetailResponseDto>> GetAllAboutUsSubDetailAsync()
    {
        string query = "Select * from TblAboutUsSubDetail";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllAboutUsSubDetailResponseDto> values = await connection.QueryAsync<GetAllAboutUsSubDetailResponseDto>(query);
            return values.ToList();
        }
    }

    public async void UpdateAboutUsSubDetail(UpdateAboutUsSubDetailRequestDto updateAboutUsSubDetailRequestDto)
    {
        string query = "Update TblAboutUsSubDetail Set Name = @aboutUsSubDetailName, Status = @aboutUsSubDetailStatus where Id=@aboutUsSubDetailId";
        DynamicParameters parameters = new();
        parameters.Add("@aboutUsSubDetailName", updateAboutUsSubDetailRequestDto.Name);
        parameters.Add("@aboutUsSubDetailStatus", updateAboutUsSubDetailRequestDto.Status);
        parameters.Add("@aboutUsSubDetailId", updateAboutUsSubDetailRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
