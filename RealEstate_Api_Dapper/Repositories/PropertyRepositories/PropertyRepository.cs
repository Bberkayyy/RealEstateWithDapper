using Dapper;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Requests;
using RealEstate_Api_Dapper.Dtos.PropertyDtos.Responses;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;
using System.Text.RegularExpressions;

namespace RealEstate_Api_Dapper.Repositories.PropertyRepositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly Context _context;

    public PropertyRepository(Context context)
    {
        _context = context;
    }

    public async Task CreatePropertyAsync(CreatePropertyRequestDto createPropertyRequestDto)
    {
        string query = "insert into TblProperty (Title,SlugUrl,Price,CoverImage,City,District,Address,Description,Type,DealOfTheDay,CreatedDate,IsActive,CategoryId,EstateAgentId) values (@title,@slugUrl,@price,@coverImage,@city,@district,@address,@description,@type,@dealOfTheDay,@createdDate,@isActive,@categoryId,@estateAgentId)";
        DynamicParameters parameters = new();
        parameters.Add("@title", createPropertyRequestDto.Title);
        parameters.Add("@slugUrl", CreateSlugUrl(createPropertyRequestDto.Title));
        parameters.Add("@price", createPropertyRequestDto.Price);
        parameters.Add("@coverImage", createPropertyRequestDto.CoverImage);
        parameters.Add("@city", createPropertyRequestDto.City);
        parameters.Add("@district", createPropertyRequestDto.District);
        parameters.Add("@address", createPropertyRequestDto.Address);
        parameters.Add("@description", createPropertyRequestDto.Description);
        parameters.Add("@type", createPropertyRequestDto.Type);
        parameters.Add("@dealOfTheDay", false);
        parameters.Add("@createdDate", DateTime.Now);
        parameters.Add("@isActive", true);
        parameters.Add("@categoryId", createPropertyRequestDto.CategoryId);
        parameters.Add("@estateAgentId", createPropertyRequestDto.EstateAgentId);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeletePropertyAsync(int id)
    {
        string query = "Delete from TblProperty where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetAllPropertyResponseDto>> GetAllPropertyAsync()
    {
        string query = "Select * From TblProperty";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllPropertyResponseDto> values = await connection.QueryAsync<GetAllPropertyResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<GetAllPropertyWithRelationshipsResponseDto>> GetAllPropertyWithRelationshipsAsync()
    {
        string query = "Select TblProperty.Id, TblProperty.Title, TblProperty.SlugUrl, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetAllPropertyWithRelationshipsResponseDto> values = await connection.QueryAsync<GetAllPropertyWithRelationshipsResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<GetLast5PropertyResponseDto>> GetLast5PropertyAsync()
    {

        string query = "Select top(5) * from TblProperty order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast5PropertyResponseDto> value = await connection.QueryAsync<GetLast5PropertyResponseDto>(query);
            return value.ToList();
        }
    }

    public async Task<List<GetLast5PropertyWithRelationshipsResponseDto>> GetLast5PropertyWithRelationshipsAsync()
    {
        string query = "Select top(5) TblProperty.Id, TblProperty.Title, TblProperty.SlugUrl, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId = TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId = TblEstateAgent.Id order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast5PropertyWithRelationshipsResponseDto> value = await connection.QueryAsync<GetLast5PropertyWithRelationshipsResponseDto>(query);
            return value.ToList();
        }
    }

    public async Task<GetPropertyByIdResponseDto> GetPropertyByIdAsync(int id)
    {
        string query = "Select * from TblProperty where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetPropertyByIdResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetPropertyByIdResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<GetPropertyByIdWithRelationshipsResponseDto> GetPropertyByIdWithRelationshipsAsync(int id)
    {
        string query = "Select TblProperty.Id, TblProperty.Title, TblProperty.SlugUrl, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id where TblProperty.Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            GetPropertyByIdWithRelationshipsResponseDto? value = await connection.QueryFirstOrDefaultAsync<GetPropertyByIdWithRelationshipsResponseDto>(query, parameters);
            return value;
        }
    }

    public async Task<List<GetPropertyListBySearchFilterWithRelationshipsResponseDto>> GetPropertyListBySearchFilterWithRelationshipsAsync(string containsWord, int categoryId, string city)
    {
        string query = "Select TblProperty.Id, TblProperty.Title, TblProperty.SlugUrl, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id where TblProperty.Title like '%" +
            containsWord +
            "%' and TblProperty.CategoryId = @categoryId and TblProperty.City = @city";
        DynamicParameters parameters = new();
        parameters.Add("@categoryId", categoryId);
        parameters.Add("@city", city);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyListBySearchFilterWithRelationshipsResponseDto> values = await connection.QueryAsync<GetPropertyListBySearchFilterWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetPropertyListByEstateAgentIdResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveFalseAsync(int id)
    {
        string query = "Select * from TblProperty where EstateAgentId=@id and IsActive=0";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyListByEstateAgentIdResponseDto> values = await connection.QueryAsync<GetPropertyListByEstateAgentIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveFalseWithRelationshipsAsync(int id)
    {
        string query = "Select TblProperty.Id, TblProperty.Title, TblProperty.SlugUrl, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id where TblProperty.EstateAgentId = @id and IsActive=0";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto> values = await connection.QueryAsync<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetPropertyListByEstateAgentIdResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveTrueAsync(int id)
    {
        string query = "Select * from TblProperty where EstateAgentId=@id and IsActive=1";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyListByEstateAgentIdResponseDto> values = await connection.QueryAsync<GetPropertyListByEstateAgentIdResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto>> GetPropertyListByEstateAgentIdAndIsActiveTrueWithRelationshipsAsync(int id)
    {
        string query = "Select TblProperty.Id, TblProperty.Title, TblProperty.SlugUrl, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id where TblProperty.EstateAgentId = @id and IsActive=1";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto> values = await connection.QueryAsync<GetPropertyListByEstateAgentIdWithRelationshipsResponseDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task PropertyDealOfTheDayStatusChangeToFalseAsync(int id)
    {
        string query = "update TblProperty set DealOfTheDay = 0 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task PropertyDealOfTheDayStatusChangeToTrueAsync(int id)
    {
        string query = "update TblProperty set DealOfTheDay = 1 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task PropertyIsActiveChangeToFalseAsync(int id)
    {
        string query = "update TblProperty set IsActive = 0 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task PropertyIsActiveChangeToTrueAsync(int id)
    {
        string query = "update TblProperty set IsActive = 1 where Id=@id";
        DynamicParameters parameters = new();
        parameters.Add("@id", id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdatePropertyAsync(UpdatePropertyRequestDto updatePropertyRequestDto)
    {
        string query = "Update TblProperty set Title = @title, SlugUrl = @slugUrl, Price = @price, CoverImage = @coverImage, City = @city, District = @district, Address = @address, Description = @description, Type = @type, DealOfTheDay = @dealOfTheDay, IsActive = @isActive, CategoryId = @categoryId, EstateAgentId = @estateAgentId where Id = @id";
        DynamicParameters parameters = new();
        parameters.Add("@title", updatePropertyRequestDto.Title);
        parameters.Add("@slugUrl", CreateSlugUrl(updatePropertyRequestDto.Title));
        parameters.Add("@price", updatePropertyRequestDto.Price);
        parameters.Add("@coverImage", updatePropertyRequestDto.CoverImage);
        parameters.Add("@city", updatePropertyRequestDto.City);
        parameters.Add("@district", updatePropertyRequestDto.District);
        parameters.Add("@address", updatePropertyRequestDto.Address);
        parameters.Add("@description", updatePropertyRequestDto.Description);
        parameters.Add("@type", updatePropertyRequestDto.Type);
        parameters.Add("@dealOfTheDay", updatePropertyRequestDto.DealOfTheDay);
        parameters.Add("@isActive", updatePropertyRequestDto.IsActive);
        parameters.Add("@categoryId", updatePropertyRequestDto.CategoryId);
        parameters.Add("@estateAgentId", updatePropertyRequestDto.EstateAgentId);
        parameters.Add("@id", updatePropertyRequestDto.Id);
        using (IDbConnection connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<GetPropertyListByDealOfTheDayTrueWithRelationshipsResponseDto>> GetPropertyListByDealOfTheDayTrueWithRelationshipsAsync()
    {
        string query = "Select TblProperty.Id, TblProperty.Title, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id where TblProperty.DealOfTheDay = 1";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetPropertyListByDealOfTheDayTrueWithRelationshipsResponseDto> values = await connection.QueryAsync<GetPropertyListByDealOfTheDayTrueWithRelationshipsResponseDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<GetLast3PropertyResponseDto>> GetLast3PropertyAsync()
    {
        string query = "Select top(3) * from TblProperty order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast3PropertyResponseDto> value = await connection.QueryAsync<GetLast3PropertyResponseDto>(query);
            return value.ToList();
        }
    }

    public async Task<List<GetLast3PropertyWithRelationshipsResponseDto>> GetLast3PropertyWithRelationshipsAsync()
    {
        string query = "Select top(3) TblProperty.Id, TblProperty.Title, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblProperty.DealOfTheDay, TblProperty.CreatedDate, TblProperty.IsActive, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId = TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId = TblEstateAgent.Id order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            IEnumerable<GetLast3PropertyWithRelationshipsResponseDto> value = await connection.QueryAsync<GetLast3PropertyWithRelationshipsResponseDto>(query);
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
