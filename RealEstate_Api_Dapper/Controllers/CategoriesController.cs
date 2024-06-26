﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Requests;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Responses;
using RealEstate_Api_Dapper.Repositories.CategoryRepositories;

namespace RealEstate_Api_Dapper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        List<GetAllCategoryResponseDto> values = await _categoryRepository.GetAllCategoryAsync();
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto createCategoryRequestDto)
    {
        await _categoryRepository.CreateCategoryAsync(createCategoryRequestDto);
        return Ok("Kategory Başarılı Bir Şekilde Eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryRepository.DeleteCategoryAsync(id);
        return Ok("Kategori Başarılı Bir Şekilde Silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestDto updateCategoryRequestDto)
    {
        await _categoryRepository.UpdateCategoryAsync(updateCategoryRequestDto);
        return Ok("Kategori Başarılı Bir Şekilde Güncellendi.");
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        GetCategoryByIdResponseDto value = await _categoryRepository.GetCategoryByIdAsync(id);
        return Ok(value);
    }
}
