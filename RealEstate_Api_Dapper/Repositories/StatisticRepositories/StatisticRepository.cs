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

    public int ActiveEmployeeCount()
    {
        string query = "Select count(*) from TblEmployee where Status = 1";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public int ApartmentCount()
    {
        string query = "SELECT COUNT(*) from (Select TblProduct.Id, TblProduct.Title, TblProduct.Price, TblProduct.CoverImage, TblProduct.City, TblProduct.District, TblProduct.Address, TblProduct.Description, TblProduct.Type, TblCategory.Name as CategoryName, TblEmployee.FullName as EmployeeName From TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.Id inner join TblEmployee on TblProduct.EmployeeId=TblEmployee.Id) as query where query.CategoryName = 'Daire'";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public decimal AverageRentPrice()
    {
        throw new NotImplementedException();
    }

    public int AverageRoomCount()
    {
        string query = "SELECT Avg(RoomCount) FROM TblProductDetails";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public decimal AverageSalePrice()
    {
        throw new NotImplementedException();
    }

    public int CategoryCount()
    {
        string query = "SELECT Count(*) FROM TblCategory";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public string CategoryNameWithMostProductCount()
    {
        string query = "SELECT top(1) TblCategory.Name, Count(*) FROM TblProduct inner join TblCategory on TblProduct.CategoryId = TblCategory.Id group by TblCategory.Name order by COUNT(*) desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public string CityNameWithMostProductCount()
    {
        string query = "SELECT  top(1) City, Count(*) FROM TblProduct group by City order by COUNT(*) desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public int DifferentCityCount()
    {
        string query = "select count(Distinct(City)) from TblProduct";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }

    public string EmployeeNameWithMostProductCount()
    {
        string query = "SELECT top(1) FullName, Count(*) FROM TblProduct inner join TblEmployee on TblProduct.EmployeeId = TblEmployee.Id group by FullName order by COUNT(*) desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public decimal LastAddedProductPrice()
    {
        string query = "select top(1) Price from TblProduct order by Id desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<decimal>(query);
        }
    }

    public string NewestBuildingYear()
    {
        string query = "select BuildYear from TblProductDetails order by BuildYear desc";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<string>(query);
        }
    }

    public string OldestBuildingYear()
    {
        string query = "select BuildYear from TblProductDetails order by BuildYear";
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

    public int ProductCount()
    {
        string query = "SELECT Count(*) FROM TblProduct";
        using (IDbConnection connection = _context.CreateConnection())
        {
            return connection.ExecuteScalar<int>(query);
        }
    }
}
