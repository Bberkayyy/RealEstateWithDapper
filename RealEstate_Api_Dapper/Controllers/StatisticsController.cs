using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Repositories.StatisticRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticRepository _statisticRepository;

    public StatisticsController(IStatisticRepository statisticRepository)
    {
        _statisticRepository = statisticRepository;
    }
    [HttpGet("ActiveCategoryCount")]
    public IActionResult ActiveCategoryCount()
    {
        return Ok(_statisticRepository.ActiveCategoryCount());
    }
    [HttpGet("ActiveEmployeeCount")]
    public IActionResult ActiveEmployeeCount()
    {
        return Ok(_statisticRepository.ActiveEmployeeCount());
    }
    [HttpGet("ApartmentCount")]
    public IActionResult ApartmentCount()
    {
        return Ok(_statisticRepository.ApartmentCount());
    }
    [HttpGet("AverageRentPrice")]
    public IActionResult AverageRentPrice()
    {
        return Ok(_statisticRepository.AverageRentPrice());
    }
    [HttpGet("AverageRoomCount")]
    public IActionResult AverageRoomCount()
    {
        return Ok(_statisticRepository.AverageRoomCount());
    }
    [HttpGet("AverageSalePrice")]
    public IActionResult AverageSalePrice()
    {
        return Ok(_statisticRepository.AverageSalePrice());
    }
    [HttpGet("CategoryCount")]
    public IActionResult CategoryCount()
    {
        return Ok(_statisticRepository.CategoryCount());
    }
    [HttpGet("CategoryNameWithMostProductCount")]
    public IActionResult CategoryNameWithMostProductCount()
    {
        return Ok(_statisticRepository.CategoryNameWithMostProductCount());
    }
    [HttpGet("CityNameWithMostProductCount")]
    public IActionResult CityNameWithMostProductCount()
    {
        return Ok(_statisticRepository.CityNameWithMostProductCount());
    }  
    [HttpGet("DifferentCityCount")]
    public IActionResult DifferentCityCount()
    {
        return Ok(_statisticRepository.DifferentCityCount());
    }  
    [HttpGet("EmployeeNameWithMostProductCount")]
    public IActionResult EmployeeNameWithMostProductCount()
    {
        return Ok(_statisticRepository.EmployeeNameWithMostProductCount());
    }  
    [HttpGet("LastAddedProductPrice")]
    public IActionResult LastAddedProductPrice()
    {
        return Ok(_statisticRepository.LastAddedProductPrice());
    } 
    [HttpGet("NewestBuildingYear")]
    public IActionResult NewestBuildingYear()
    {
        return Ok(_statisticRepository.NewestBuildingYear());
    }
    [HttpGet("OldestBuildingYear")]
    public IActionResult OldestBuildingYear()
    {
        return Ok(_statisticRepository.OldestBuildingYear());
    } 
    [HttpGet("PassiveCategoryCount")]
    public IActionResult PassiveCategoryCount()
    {
        return Ok(_statisticRepository.PassiveCategoryCount());
    }  
    [HttpGet("ProductCount")]
    public IActionResult ProductCount()
    {
        return Ok(_statisticRepository.ProductCount());
    }
}
