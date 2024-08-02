namespace RealEstate_Api_Dapper.Repositories.StatisticRepositories;

public interface IStatisticRepository
{
    int CategoryCount();
    int ActiveCategoryCount();
    int PassiveCategoryCount();
    int ProductCount();
    int ApartmentCount();
    string EstateAgentNameWithMostProductCount();
    string CategoryNameWithMostProductCount();
    decimal AverageRentPrice();
    decimal AverageSalePrice();
    string CityNameWithMostProductCount();
    int DifferentCityCount();
    decimal LastAddedProductPrice();
    string NewestBuildingYear();
    string OldestBuildingYear();
    int AverageRoomCount();
    int ActiveEstateAgentCount();
}
