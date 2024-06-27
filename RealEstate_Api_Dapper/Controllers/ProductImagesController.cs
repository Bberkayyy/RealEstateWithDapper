using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.ProductImageDtos.Requests;
using RealEstate_Api_Dapper.Dtos.ProductImageDtos.Responses;
using RealEstate_Api_Dapper.Repositories.ProductImageRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    private readonly IProductImageRepository _productImageRepository;

    public ProductImagesController(IProductImageRepository ProductImageRepository)
    {
        _productImageRepository = ProductImageRepository;
    }
    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        List<GetAllProductImagesResponseDto> values = await _productImageRepository.GetAllProductImageAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageRequestDto createProductImageRequestDto)
    {
        await _productImageRepository.CreateProductImageAsync(createProductImageRequestDto);
        return Ok("İlan Fotoğrafı Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(int id)
    {
        await _productImageRepository.DeleteProductImageAsync(id);
        return Ok("İlan Fotoğrafı Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageRequestDto updateProductImageRequestDto)
    {
        await _productImageRepository.UpdateProductImageAsync(updateProductImageRequestDto);
        return Ok("İlan Fotoğrafı Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("GetProductImagesByProductId")]
    public async Task<IActionResult> GetProductImagesByProductId(int id)
    {
        List<GetProductImagesByProductIdResponseDto> value = await _productImageRepository.GetProductImagesByProductIdAsync(id);
        return Ok(value);
    }
}
