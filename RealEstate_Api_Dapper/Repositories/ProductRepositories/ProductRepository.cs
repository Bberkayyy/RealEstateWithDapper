using Dapper;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;
using System.Text.RegularExpressions;

namespace RealEstate_Api_Dapper.Repositories.ProductRepositories;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateProductAsync(CreateProductRequestDto createProductRequestDto)
    {
        string query = "insert into TblProduct (Title,SlugUrl,Price,CoverImage,City,District,Address,Description,Type,DealOfTheDay,CreatedDate,IsActive,CategoryId,EstateAgentId) values (@title,@slugUrl,@price,@coverImage,@city,@district,@address,@description,@type,@dealOfTheDay,@createdDate,@isActive,@categoryId,@estateAgentId)";
        DynamicParameters parameters = new();
        parameters.Add("@title", createProductRequestDto.Title);
        parameters.Add("@slugUrl", CreateSlugUrl(createProductRequestDto.Title));
        parameters.Add("@price", createProductRequestDto.Price);
        parameters.Add("@coverImage", createProductRequestDto.CoverImage);
        parameters.Add("@city", createProductRequestDto.City);
        parameters.Add("@district", createProductRequestDto.District);
        parameters.Add("@address", createProductRequestDto.Address);
        parameters.Add("@description", createProductRequestDto.Description);
        parameters.Add("@type", createProductRequestDto.Type);
        parameters.Add("@dealOfTheDay", false);
        parameters.Add("@createdDate", DateTime.Now);
        parameters.Add("@isActive", true);
        parameters.Add("@categoryId", createProductRequestDto.CategoryId);
        parameters.Add("@estateAgentId", createProductRequestDto.EstateAgentId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteProductAsync(int id)
    {
        string query = "Delete from TblProduct where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
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
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.SlugUrl, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId=TblEstateAgent.Id";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllProductWithRelationshipsResponseDto> values = await connection.QueryAsync<GetAllProductWithRelationshipsResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<GetLast5ProductResponseDto>> GetLast5ProductAsync()
    {

        string query = "Select top(5) * from TblProduct order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast5ProductResponseDto> value = await connection.QueryAsync<GetLast5ProductResponseDto>(query);
            return value.ToList();
        }
    }

    public async Task<List<GetLast5ProductWithRelationshipsResponseDto>> GetLast5ProductWithRelationshipsAsync()
    {
        string query = "Select top(5) TblProduct.Id, TblProduct.Title, TblProduct.SlugUrl, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId = TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId = TblEstateAgent.Id order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast5ProductWithRelationshipsResponseDto> value = await connection.QueryAsync<GetLast5ProductWithRelationshipsResponseDto>(query);
            return value.ToList();
        }
    }

    public async Task<GetProductByIdResponseDto> GetProductByIdAsync(int id)
    {
        string query = "Select * from TblProduct where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetProductByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetProductByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<GetProductByIdWithRelationshipsResponseDto> GetProductByIdWithRelationshipsAsync(int id)
    {
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.SlugUrl, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId=TblEstateAgent.Id where TblProduct.Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetProductByIdWithRelationshipsResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetProductByIdWithRelationshipsResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetProductListBySearchFilterWithRelationshipsResponseDto>> GetProductListBySearchFilterWithRelationshipsAsync(string containsWord, int categoryId, string city)
    {
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.SlugUrl, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId=TblEstateAgent.Id where TblProduct.Title like '%" +
            containsWord +
            "%' and TblProduct.CategoryId = @categoryId and TblProduct.City = @city";
        DynamicParameters parameters = new();
        parameters.Add("@categoryId", categoryId);
        parameters.Add("@city", city);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductListBySearchFilterWithRelationshipsResponseDto> values = await connection.QueryAsync<GetProductListBySearchFilterWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetProductListByEstateAgentIdResponseDto>> GetProductListByEstateAgentIdAndIsActiveFalseAsync(int id)
    {
        string query = "Select * from TblProduct where EstateAgentId=@id and IsActive=0";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductListByEstateAgentIdResponseDto> values = await connection.QueryAsync<GetProductListByEstateAgentIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetProductListByEstateAgentIdWithRelationshipsResponseDto>> GetProductListByEstateAgentIdAndIsActiveFalseWithRelationshipsAsync(int id)
    {
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.SlugUrl, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId=TblEstateAgent.Id where TblProduct.EstateAgentId = @id and IsActive=0";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductListByEstateAgentIdWithRelationshipsResponseDto> values = await connection.QueryAsync<GetProductListByEstateAgentIdWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetProductListByEstateAgentIdResponseDto>> GetProductListByEstateAgentIdAndIsActiveTrueAsync(int id)
    {
        string query = "Select * from TblProduct where EstateAgentId=@id and IsActive=1";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductListByEstateAgentIdResponseDto> values = await connection.QueryAsync<GetProductListByEstateAgentIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetProductListByEstateAgentIdWithRelationshipsResponseDto>> GetProductListByEstateAgentIdAndIsActiveTrueWithRelationshipsAsync(int id)
    {
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.SlugUrl, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId=TblEstateAgent.Id where TblProduct.EstateAgentId = @id and IsActive=1";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductListByEstateAgentIdWithRelationshipsResponseDto> values = await connection.QueryAsync<GetProductListByEstateAgentIdWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task ProductDealOfTheDayStatusChangeToFalseAsync(int id)
    {
        string query = "update TblProduct set DealOfTheDay = 0 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task ProductDealOfTheDayStatusChangeToTrueAsync(int id)
    {
        string query = "update TblProduct set DealOfTheDay = 1 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task ProductIsActiveChangeToFalseAsync(int id)
    {
        string query = "update TblProduct set IsActive = 0 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task ProductIsActiveChangeToTrueAsync(int id)
    {
        string query = "update TblProduct set IsActive = 1 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateProductAsync(UpdateProductRequestDto updateProductRequestDto)
    {
        string query = "Update TblProduct set Title = @title, SlugUrl = @slugUrl, Price = @price, CoverImage = @coverImage, City = @city, District = @district, Address = @address, Description = @description, Type = @type, DealOfTheDay = @dealOfTheDay, IsActive = @isActive, CategoryId = @categoryId, EstateAgentId = @estateAgentId where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@title", updateProductRequestDto.Title);
        parameters.Add("@slugUrl", CreateSlugUrl(updateProductRequestDto.Title));
        parameters.Add("@price", updateProductRequestDto.Price);
        parameters.Add("@coverImage", updateProductRequestDto.CoverImage);
        parameters.Add("@city", updateProductRequestDto.City);
        parameters.Add("@district", updateProductRequestDto.District);
        parameters.Add("@address", updateProductRequestDto.Address);
        parameters.Add("@description", updateProductRequestDto.Description);
        parameters.Add("@type", updateProductRequestDto.Type);
        parameters.Add("@dealOfTheDay", updateProductRequestDto.DealOfTheDay);
        parameters.Add("@isActive", updateProductRequestDto.IsActive);
        parameters.Add("@categoryId", updateProductRequestDto.CategoryId);
        parameters.Add("@estateAgentId", updateProductRequestDto.EstateAgentId);
        parameters.Add("@id", updateProductRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetProductListByDealOfTheDayTrueWithRelationshipsResponseDto>> GetProductListByDealOfTheDayTrueWithRelationshipsAsync()
    {
        string query = "Select TblProduct.Id, TblProduct.Title, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId=TblEstateAgent.Id where TblProduct.DealOfTheDay = 1";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetProductListByDealOfTheDayTrueWithRelationshipsResponseDto> values = await connection.QueryAsync<GetProductListByDealOfTheDayTrueWithRelationshipsResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<GetLast3ProductResponseDto>> GetLast3ProductAsync()
    {
        string query = "Select top(3) * from TblProduct order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast3ProductResponseDto> value = await connection.QueryAsync<GetLast3ProductResponseDto>(query);
            return value.ToList();
        }
    }

    public async Task<List<GetLast3ProductWithRelationshipsResponseDto>> GetLast3ProductWithRelationshipsAsync()
    {
        string query = "Select top(3) TblProduct.Id, TblProduct.Title, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblProduct.DealOfTheDay, TblProduct.CreatedDate, TblProduct.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProduct inner join TblCategory on TblProduct.CategoryId = TblCategory.Id inner join TblEstateAgent on TblProduct.EstateAgentId = TblEstateAgent.Id order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast3ProductWithRelationshipsResponseDto> value = await connection.QueryAsync<GetLast3ProductWithRelationshipsResponseDto>(query);
            return value.ToList();
        }
    }
    private string CreateSlugUrl(string title)
    {
        title = title.ToLowerInvariant();
        title = title.Replace(" ", "-");
        title = Regex.Replace(title, @"[^a-z0-9\s-]", "");
        title = Regex.Replace(title, @"\s+", " ").Trim();
        title = Regex.Replace(title, @"\s", "-");
        return title;
    }
}
