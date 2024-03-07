using Dapper;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<GetAllProductResponseDto>> GetAllProductAsync()
    {
        string query = "Select * From TblProduct";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllProductResponseDto> values = await connection.QueryAsync<GetAllProductResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<GetAllProductWithRelationshipsResponseDto>> GetAllProductWithRelationshipsAsync()
    {
        //string query = "Select TblProduct.Id,Title,Price,City,District,CategoryName where CategoryName = TblCategory.Name From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id";
        //" inner join TblEmployee on TblProduct.EmployeId = TblEmployee.Id";
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblCategory.Name as CategoryName, TblEmployee.Name as EmployeeName From TblProduct" +
            " inner join TblCategory on TblProduct.CategoryId=TblCategory.Id" +
            " inner join TblEmployee on TblProduct.EmployeeId=TblEmployee.Id";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllProductWithRelationshipsResponseDto> values = await connection.QueryAsync<GetAllProductWithRelationshipsResponseDto>(query);
            return values.ToList();
        }
    }
}
