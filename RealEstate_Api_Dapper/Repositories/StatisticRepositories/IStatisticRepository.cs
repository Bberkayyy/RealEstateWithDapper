namespace RealEstate_Api_Dapper.Repositories.StatisticRepositories;

public interface IStatisticRepository
{
    int CategoryCount();
    int ActiveCategoryCount();
    int PassiveCategoryCount();
    int PropertyCount();
    int ApartmentCount();
    string EstateAgentNameWithMostPropertyCount();
    string CategoryNameWithMostPropertyCount();
    decimal AverageRentPrice();
    decimal AverageSalePrice();
    string CityNameWithMostPropertyCount();
    int DifferentCityCount();
    decimal LastAddedPropertyPrice();
    string NewestBuildingYear();
    string OldestBuildingYear();
    int AverageRoomCount();
    int ActiveEstateAgentCount();
}
