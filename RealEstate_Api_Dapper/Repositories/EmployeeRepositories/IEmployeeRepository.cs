using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.EmployeeRepositories;

public interface IEmployeeRepository
{
    Task<List<GetAllEmployeeResponseDto>> GetAllEmployeeAsync();
    Task CreateEmployeeAsync(CreateEmployeeRequestDto createEmployeeRequestDto);
    Task UpdateEmployeeAsync(UpdateEmployeeRequestDto updateEmployeeRequestDto);
    Task DeleteEmployeeAsync(int id);
    Task<GetEmployeeByIdResponseDto> GetEmployeeByIdAsync(int id);
}
