using Dapper;
using RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Requests;
using RealEstate_Api_Dapper.Dtos.SubFeatureDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.SubFeatureRepositories;

public class SubFeatureRepository : ISubFeatureRepository
{
    private readonly Context _context;

    public SubFeatureRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateSubFeatureAsync(CreateSubFeatureRequestDto createSubFeatureRequestDto)
    {
        string query = "Insert into TblSubFeature (Icon,TopTitle,Title,Description,SubTitle) values (@icon,@topTitle,@title,@description,@subTitle)";
        DynamicParameters parameters = new();
        parameters.Add("@icon", createSubFeatureRequestDto.Icon);
        parameters.Add("@topTitle", createSubFeatureRequestDto.TopTitle);
        parameters.Add("@title", createSubFeatureRequestDto.Title);
        parameters.Add("@description", createSubFeatureRequestDto.Description);
        parameters.Add("@subTitle", createSubFeatureRequestDto.SubTitle);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteSubFeatureAsync(int id)
    {
        string query = "Delete From TblSubFeature where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllSubFeatureResponseDto>> GetAllSubFeatureAsync()
    {
        string query = "Select * from TblSubFeature";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllSubFeatureResponseDto> values = await connection.QueryAsync<GetAllSubFeatureResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetSubFeatureByIdResponseDto> GetSubFeatureByIdAsync(int id)
    {
        string query = "Select * from TblSubFeature where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetSubFeatureByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetSubFeatureByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateSubFeatureAsync(UpdateSubFeatureRequestDto updateSubFeatureRequestDto)
    {
        string query = "Update TblSubFeature set Icon = @icon, TopTitle = @topTitle, Title = @title, Description = @description, SubTitle = @subTitle where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@icon", updateSubFeatureRequestDto.Icon);
        parameters.Add("@topTitle", updateSubFeatureRequestDto.TopTitle);
        parameters.Add("@title", updateSubFeatureRequestDto.Title);
        parameters.Add("@description", updateSubFeatureRequestDto.Description);
        parameters.Add("@subTitle", updateSubFeatureRequestDto.SubTitle);
        parameters.Add("@id", updateSubFeatureRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
