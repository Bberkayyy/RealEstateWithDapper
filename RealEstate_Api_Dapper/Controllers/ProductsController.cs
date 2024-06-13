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
    [HttpGet("ProductDealOfTheDayStatusChangeToTrue")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
    {
        _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
        return Ok("İlan Günün Fırsatı Olarak Belirlendi.");
    }
    [HttpGet("ProductDealOfTheDayStatusChangeToFalse")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
    {
        _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
        return Ok("İlan Günün Fırsatlarından Çıkarıldı.");
    }
    [HttpGet("Last5ProductList")]
    public async Task<IActionResult> Last5ProductList()
    {
        List<GetLast5ProductResponseDto> value = await _productRepository.GetLast5ProductAsync();
        return Ok(value);
    }
    [HttpGet("Last5ProductListWithRelationships")]
    public async Task<IActionResult> Last5ProductListWithRelationships()
    {
        List<GetLast5ProductWithRelationshipsResponseDto> value = await _productRepository.GetLast5ProductWithRelationshipsAsync();
        return Ok(value);
    }
    [HttpGet("GetProductListByEmployeeIdAndIsActiveTrue")]
    public async Task<IActionResult> GetProductListByEmployeeIdAndIsActiveTrue(int id)
    {
        List<GetProductListByEmployeeIdResponseDto> values = await _productRepository.GetProductListByEmployeeIdAndIsActiveTrueAsync(id);
        return Ok(values);
    }
    [HttpGet("GetProductListByEmployeeIdAndIsActiveTrueWithRelationships")]
    public async Task<IActionResult> GetProductListByEmployeeIdAndIsActiveTrueWithRelationships(int id)
    {
        List<GetProductListByEmployeeIdWithRelationshipsResponseDto> values = await _productRepository.GetProductListByEmployeeIdAndIsActiveTrueWithRelationshipsAsync(id);
        return Ok(values);
    }
    [HttpGet("GetProductListByEmployeeIdAndIsActiveFalse")]
    public async Task<IActionResult> GetProductListByEmployeeIdAndIsActiveFalse(int id)
    {
        List<GetProductListByEmployeeIdResponseDto> values = await _productRepository.GetProductListByEmployeeIdAndIsActiveFalseAsync(id);
        return Ok(values);
    }
    [HttpGet("GetProductListByEmployeeIdAndIsActiveFalseWithRelationships")]
    public async Task<IActionResult> GetProductListByEmployeeIdAndIsActiveFalseWithRelationships(int id)
    {
        List<GetProductListByEmployeeIdWithRelationshipsResponseDto> values = await _productRepository.GetProductListByEmployeeIdAndIsActiveFalseWithRelationshipsAsync(id);
        return Ok(values);
    }
    [HttpGet("ProductIsActiveChangeToTrue")]
    public IActionResult ProductIsActiveChangeToTrue(int id)
    {
        _productRepository.ProductIsActiveChangeToTrue(id);
        return Ok("İlan durumu aktif olarak değiştirildi.");
    }
    [HttpGet("ProductIsActiveChangeToFalse")]
    public IActionResult ProductIsActiveChangeToFalse(int id)
    {
        _productRepository.ProductIsActiveChangeToFalse(id);
        return Ok("İlan durumu pasif olarak değiştirildi.");
    }
}
