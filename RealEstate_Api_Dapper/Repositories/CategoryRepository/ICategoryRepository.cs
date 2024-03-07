using RealEstate_Api_Dapper.Dtos.CategoryDtos.Requests;
using RealEstate_Api_Dapper.Dtos.CategoryDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<GetAllCategoryResponseDto>> GetAllCategoryAsync();
    void CreateCategory(CreateCategoryRequestDto createCategoryRequestDto);
    void UpdateCategory(UpdateCategoryRequestDto updateCategoryRequestDto);
    void DeleteCategory(int id);
    Task<GetCategoryByIdResponseDto> GetCategoryByIdAsync(int id);
}
