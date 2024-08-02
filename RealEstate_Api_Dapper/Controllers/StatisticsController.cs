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
    [HttpGet("ActiveEstateAgentCount")]
    public IActionResult ActiveEstateAgentCount()
    {
        return Ok(_statisticRepository.ActiveEstateAgentCount());
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
    [HttpGet("CategoryNameWithMostPropertyCount")]
    public IActionResult CategoryNameWithMostPropertyCount()
    {
        return Ok(_statisticRepository.CategoryNameWithMostPropertyCount());
    }
    [HttpGet("CityNameWithMostPropertyCount")]
    public IActionResult CityNameWithMostPropertyCount()
    {
        return Ok(_statisticRepository.CityNameWithMostPropertyCount());
    }  
    [HttpGet("DifferentCityCount")]
    public IActionResult DifferentCityCount()
    {
        return Ok(_statisticRepository.DifferentCityCount());
    }  
    [HttpGet("EstateAgentNameWithMostPropertyCount")]
    public IActionResult EstateAgentNameWithMostPropertyCount()
    {
        return Ok(_statisticRepository.EstateAgentNameWithMostPropertyCount());
    }  
    [HttpGet("LastAddedPropertyPrice")]
    public IActionResult LastAddedPropertyPrice()
    {
        return Ok(_statisticRepository.LastAddedPropertyPrice());
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
    [HttpGet("PropertyCount")]
    public IActionResult PropertyCount()
    {
        return Ok(_statisticRepository.PropertyCount());
    }
}
