using Dapper;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Requests;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.CategoryRepositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly Context _context;

    public CategoryRepository(Context context)
    {
        _context = context;
    }

    public async void CreateCategory(CreateCategoryRequestDto createCategoryRequestDto)
    {
        string query = "Insert Into TblCategory (Name,Status) values (@categoryName,@categoryStatus)";
        DynamicParameters parameters = new();
        parameters.Add("@categoryName", createCategoryRequestDto.Name);
        parameters.Add("@categoryStatus", true);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteCategory(int id)
    {
        string query = "Delete From TblCategory Where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllCategoryResponseDto>> GetAllCategoryAsync()
    {
        string query = "Select * From TblCategory";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllCategoryResponseDto> values = await connection.QueryAsync<GetAllCategoryResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetCategoryByIdResponseDto> GetCategoryByIdAsync(int id)
    {
        string query = "Select * From TblCategory Where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetCategoryByIdResponseDto value = await connection.QueryFirstOrDefaultAsync<GetCategoryByIdResponseDto>(query,parameters);
            return value;
        }
    }

    public async void UpdateCategory(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        string query = "Update TblCategory Set Name = @categoryName, Status = @categoryStatus where Id=@categoryId";
        DynamicParameters parameters = new();
        parameters.Add("@categoryName", updateCategoryRequestDto.Name);
        parameters.Add("@categoryStatus", updateCategoryRequestDto.Status);
        parameters.Add("@categoryId", updateCategoryRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
