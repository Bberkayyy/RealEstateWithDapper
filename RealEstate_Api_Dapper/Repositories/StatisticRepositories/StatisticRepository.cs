using Dapper;
using RealEstate_Api_Dapper.Models.DapperContext;
using System.Data;

namespace RealEstate_Api_Dapper.Repositories.StatisticRepositories;

public class StatisticRepository : IStatisticRepository
{
    private readonly Context _context;

    public StatisticRepository(Context context)
    {
        _context = context;
    }

    public int ActiveCategoryCount()
    {
        string query = "Select count(*) from TblCategory where Status = 1";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public int ActiveEstateAgentCount()
    {
        string query = "Select count(*) from TblEstateAgent where Status = 1";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public int ApartmentCount()
    {
        string query = "SELECT COUNT(*) from (Select TblProperty.Id, TblProperty.Title, TblProperty.Price, TblProperty.CoverImage, TblProperty.City, TblProperty.District, TblProperty.Address, TblProperty.Description, TblProperty.Type, TblCategory.Name as CategoryName, TblEstateAgent.FullName as EstateAgentName From TblProperty inner join TblCategory on TblProperty.CategoryId=TblCategory.Id inner join TblEstateAgent on TblProperty.EstateAgentId=TblEstateAgent.Id) as query where query.CategoryName = 'Daire'";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public decimal AverageRentPrice()
    {
        string query = "SELECT AVG(Price) FROM TblProperty WHERE Type COLLATE Latin1_General_CI_AI = 'Kiralık'";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public int AverageRoomCount()
    {
        string query = "SELECT Avg(RoomCount) FROM TblPropertyDetails";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public decimal AverageSalePrice()
    {
        string query = "SELECT AVG(Price) FROM TblProperty WHERE Type COLLATE Latin1_General_CI_AI = 'Satılık'";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public int CategoryCount()
    {
        string query = "SELECT Count(*) FROM TblCategory";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public string CategoryNameWithMostPropertyCount()
    {
        string query = "SELECT top(1) TblCategory.Name, Count(*) FROM TblProperty inner join TblCategory on TblProperty.CategoryId = TblCategory.Id group by TblCategory.Name order by COUNT(*) desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public string CityNameWithMostPropertyCount()
    {
        string query = "SELECT  top(1) City, Count(*) FROM TblProperty group by City order by COUNT(*) desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public int DifferentCityCount()
    {
        string query = "select count(Distinct(City)) from TblProperty";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public string EstateAgentNameWithMostPropertyCount()
    {
        string query = "SELECT top(1) FullName, Count(*) FROM TblProperty inner join TblEstateAgent on TblProperty.EstateAgentId = TblEstateAgent.Id group by FullName order by COUNT(*) desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public decimal LastAddedPropertyPrice()
    {
        string query = "select top(1) Price from TblProperty order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<decimal>(query);
        }
    }

    public string NewestBuildingYear()
    {
        string query = "select BuildYear from TblPropertyDetails order by BuildYear desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public string OldestBuildingYear()
    {
        string query = "select BuildYear from TblPropertyDetails order by BuildYear";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public int PassiveCategoryCount()
    {
        string query = "Select count(*) from TblCategory where Status = 0";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public int PropertyCount()
    {
        string query = "SELECT Count(*) FROM TblProperty";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }
}
