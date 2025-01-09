using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.EmployeeDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;

namespace WorkSphere.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
            
        }


        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeCreateDTO employee)
        {
           return await _employeeRepo.AddEmployee(employee);
        }

       
        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepo.DeleteEmployee(id);
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeeAsync()
        {
            return await _employeeRepo.GetAllEmployee();
        }

        public async Task<EmployeeEditDTO> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepo.GetEmployeeById(id);
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeEditDTO employee)
        {
            return await _employeeRepo.UpdateEmployee(employee);
        }
    }
}
