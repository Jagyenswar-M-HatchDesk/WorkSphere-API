using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.EmployeeDTO;
using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IRepo
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDTO>> GetAllEmployee();

        Task<EmployeeEditDTO> GetEmployeeById(int id);

        Task<EmployeeDTO> AddEmployee(EmployeeCreateDTO employee);

        Task<EmployeeDTO> UpdateEmployee(EmployeeEditDTO employee);
       
        Task<bool> DeleteEmployee(int id);
    }
}
