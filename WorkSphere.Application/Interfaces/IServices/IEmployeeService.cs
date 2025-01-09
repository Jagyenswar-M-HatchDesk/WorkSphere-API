using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.EmployeeDTO;

namespace WorkSphere.Application.Interfaces.IServices
{
    public  interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployeeAsync();

        Task<EmployeeEditDTO> GetEmployeeByIdAsync(int id);

        Task<EmployeeDTO> AddEmployeeAsync(EmployeeCreateDTO employee);

        Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeEditDTO employee);

        Task<bool> DeleteEmployeeAsync(int id);
    }
}
