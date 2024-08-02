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
        await _productRepository.CreateProductAsync(createProductRequestDto);
        return Ok("İlan Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productRepository.DeleteProductAsync(id);
        return Ok("İlan Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequestDto updateProductRequestDto)
    {
        await _productRepository.UpdateProductAsync(updateProductRequestDto);
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
        await _productRepository.ProductDealOfTheDayStatusChangeToTrueAsync(id);
        return Ok("İlan Günün Fırsatı Olarak Belirlendi.");
    }
    [HttpGet("ProductDealOfTheDayStatusChangeToFalse")]
    public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
    {
        await _productRepository.ProductDealOfTheDayStatusChangeToFalseAsync(id);
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
    [HttpGet("Last3ProductList")]
    public async Task<IActionResult> Last3ProductList()
    {
        List<GetLast3ProductResponseDto> value = await _productRepository.GetLast3ProductAsync();
        return Ok(value);
    }
    [HttpGet("Last3ProductListWithRelationships")]
    public async Task<IActionResult> Last3ProductListWithRelationships()
    {
        List<GetLast3ProductWithRelationshipsResponseDto> value = await _productRepository.GetLast3ProductWithRelationshipsAsync();
        return Ok(value);
    }
    [HttpGet("GetProductListByEstateAgentIdAndIsActiveTrue")]
    public async Task<IActionResult> GetProductListByEstateAgentIdAndIsActiveTrue(int id)
    {
        List<GetProductListByEstateAgentIdResponseDto> values = await _productRepository.GetProductListByEstateAgentIdAndIsActiveTrueAsync(id);
        return Ok(values);
    }
    [HttpGet("GetProductListByEstateAgentIdAndIsActiveTrueWithRelationships")]
    public async Task<IActionResult> GetProductListByEstateAgentIdAndIsActiveTrueWithRelationships(int id)
    {
        List<GetProductListByEstateAgentIdWithRelationshipsResponseDto> values = await _productRepository.GetProductListByEstateAgentIdAndIsActiveTrueWithRelationshipsAsync(id);
        return Ok(values);
    }
    [HttpGet("GetProductListByEstateAgentIdAndIsActiveFalse")]
    public async Task<IActionResult> GetProductListByEstateAgentIdAndIsActiveFalse(int id)
    {
        List<GetProductListByEstateAgentIdResponseDto> values = await _productRepository.GetProductListByEstateAgentIdAndIsActiveFalseAsync(id);
        return Ok(values);
    }
    [HttpGet("GetProductListByEstateAgentIdAndIsActiveFalseWithRelationships")]
    public async Task<IActionResult> GetProductListByEstateAgentIdAndIsActiveFalseWithRelationships(int id)
    {
        List<GetProductListByEstateAgentIdWithRelationshipsResponseDto> values = await _productRepository.GetProductListByEstateAgentIdAndIsActiveFalseWithRelationshipsAsync(id);
        return Ok(values);
    }
    [HttpGet("ProductIsActiveChangeToTrue")]
    public async Task<IActionResult> ProductIsActiveChangeToTrue(int id)
    {
        await _productRepository.ProductIsActiveChangeToTrueAsync(id);
        return Ok("İlan durumu aktif olarak değiştirildi.");
    }
    [HttpGet("ProductIsActiveChangeToFalse")]
    public async Task<IActionResult> ProductIsActiveChangeToFalse(int id)
    {
        await _productRepository.ProductIsActiveChangeToFalseAsync(id);
        return Ok("İlan durumu pasif olarak değiştirildi.");
    }
    [HttpGet("ProductListBySearchFilterWithRelationships")]
    public async Task<IActionResult> ProductListBySearchFilterWithRelationships(string containsWord, int categoryId, string city)
    {
        List<GetProductListBySearchFilterWithRelationshipsResponseDto> values = await _productRepository.GetProductListBySearchFilterWithRelationshipsAsync(containsWord, categoryId, city);
        return Ok(values);
    }
    [HttpGet("ProductListByDealOfTheDayTrueWithRelationships")]
    public async Task<IActionResult> GetProductListByDealOfTheDayTrueWithRelationshipsAsync()
    {
        List<GetProductListByDealOfTheDayTrueWithRelationshipsResponseDto> values = await _productRepository.GetProductListByDealOfTheDayTrueWithRelationshipsAsync();
        return Ok(values);
    }
}
