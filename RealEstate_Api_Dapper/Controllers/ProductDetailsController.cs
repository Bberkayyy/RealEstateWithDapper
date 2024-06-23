using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ProductDetailDtos.Responses;
using RealEstate_Api_Dapper.Repositories.ProductDetailRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductDetailRepository _productDetailRepository;

    public ProductDetailsController(IProductDetailRepository productDetailRepository)
    {
        _productDetailRepository = productDetailRepository;
    }

    [HttpGet("GetByProductId")]
    public async Task<IActionResult> GetProductDetailsByProductId(int id)
    {
        GetProductDetailByProductIdResponseDto value = await _productDetailRepository.GetProductDetailByProductIdAsync(id);
        return Ok(value);
    }
}
