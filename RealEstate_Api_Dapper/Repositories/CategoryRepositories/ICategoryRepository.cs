using RealEstate_Api_Dapper.Dtos.CategoryDtos.Requests;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.CategoryRepositories;

public interface ICategoryRepository
{
    Task<List<GetAllCategoryResponseDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryRequestDto createCategoryRequestDto);
    Task UpdateCategoryAsync(UpdateCategoryRequestDto updateCategoryRequestDto);
    Task DeleteCategoryAsync(int id);
    Task<GetCategoryByIdResponseDto> GetCategoryByIdAsync(int id);
}
