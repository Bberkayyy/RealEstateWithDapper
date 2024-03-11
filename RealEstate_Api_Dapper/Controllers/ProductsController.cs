using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ProductDtos.Requests;
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
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequestDto createProductRequestDto)
    {
        _productRepository.CreateProduct(createProductRequestDto);
        return Ok("İlan Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        _productRepository.DeleteProduct(id);
        return Ok("İlan Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestDto updateProductRequestDto)
    {
        _productRepository.UpdateProduct(updateProductRequestDto);
        return Ok("İlan Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        GetProductByIdResponseDto value = await _productRepository.GetProductByIdAsync(id);
        return Ok(value);
    }
    [HttpGet("GetWithRelationships/{id}")]
    public async Task<IActionResult> GetProductByIdWithRelationships(int id)
    {
        GetProductByIdWithRelationshipsResponseDto value = await _productRepository.GetProductByIdWithRelationshipsAsync(id);
        return Ok(value);
    }
}
