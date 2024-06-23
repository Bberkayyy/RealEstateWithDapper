using Dapper;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Requests;
using RealEstate_Api_Dapper.Dtos.AmenityDtos.Responses;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Requests;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.AmenityRepositories;

public class AmenityRepository : IAmenityRepository
{
    private readonly Context _context;

    public AmenityRepository(Context context)
    {
        _context = context;
    }
    public async Task CreateAmenity(CreateAmenityRequestDto createAmenityRequestDto)
    {
        string query = "insert into TblAmenity (Title) values (@title)";
        DynamicParameters parameters = new();
        parameters.Add("@title", createAmenityRequestDto.Title);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteAmenity(int id)
    {
        string query = "Delete From TblAmenity Where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllAmenityResponseDto>> GetAllAmenityAsync()
    {
        string query = "Select * From TblAmenity";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllAmenityResponseDto> values = await connection.QueryAsync<GetAllAmenityResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task UpdateAmenity(UpdateAmenityRequestDto updateAmenityRequestDto)
    {
        string query = "Update TblAmenity Set Title = @title where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@categoryName", updateAmenityRequestDto.Title);
        parameters.Add("@id", updateAmenityRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
