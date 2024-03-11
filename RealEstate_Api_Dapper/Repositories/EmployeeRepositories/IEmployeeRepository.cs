using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Requests;
using RealEstate_Api_Dapper.Dtos.EmployeeDtos.Responses;

namespace RealEstate_Api_Dapper.Repositories.EmployeeRepositories;

public interface IEmployeeRepository
{
    Task<List<GetAllEmployeeResponseDto>> GetAllEmployeeAsync();
    void CreateEmployee(CreateEmployeeRequestDto createEmployeeRequestDto);
    void UpdateEmployee(UpdateEmployeeRequestDto updateEmployeeRequestDto);
    void DeleteEmployee(int id);
    Task<GetEmployeeByIdResponseDto> GetEmployeeByIdAsync(int id);
}
