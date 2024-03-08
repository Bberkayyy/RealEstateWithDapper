using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Responses;
using RealEstate_Api_Dapper.Repositories.ProductRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        List<GetAllProductResponseDto> values = await _productRepository.GetAllProductAsync();
        return Ok(values);
    }
    [HttpGet("ProductListWithRelationships")]
    public async Task<IActionResult> ProductListWithRelationships()
    {
        List<GetAllProductWithRelationshipsResponseDto> values = await _productRepository.GetAllProductWithRelationshipsAsync();
        return Ok(values);
    }
}
