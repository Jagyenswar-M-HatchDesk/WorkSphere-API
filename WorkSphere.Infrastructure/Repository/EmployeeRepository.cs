using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.DTOs.EmployeeDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkSphere.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepo
    {

        private readonly WorkSphereDbContext _context;
        public EmployeeRepository(WorkSphereDbContext  context)
        {
            _context = context;
        }
        public async Task<EmployeeDTO> AddEmployee(EmployeeCreateDTO employee)
        {
            var newEmployee = new User()
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
               Rollid = 3,
               DeptId = employee.DepartmentId,
                IsActive = true,
                IsDeleted=false,
                ModifiedOn = DateTime.Now,
                CreatedBy = employee.CreatedBy,
                DateOfJoining = DateTime.Now,
            };

            _context.Users.Add(newEmployee);
            await _context.SaveChangesAsync();
            return new EmployeeDTO()
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Email = newEmployee.Email,
                RoleId = newEmployee.Rollid,
                DepartmentId = newEmployee.DeptId,
                IsActive = true,
                ModifiedOn = DateTime.Now,
                CreatedBy = newEmployee.CreatedBy,
                DateOfJoining = DateTime.Now,
            };
        }

        public async  Task<bool> DeleteEmployee(int id)
        {
            var isDeleted = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Rollid == 3);
            if (isDeleted == null)
            {
                return false;
            }
            else
            {
                _context.Users.Remove(isDeleted);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<EmployeeDTO>> GetAllEmployee()
        {
            var emp = await _context.Users
                .Include(u => u.DepartmentNavigation) 
                .Where(e => e.IsActive == true && e.Rollid == 3)
                .Select(x => new EmployeeDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    RoleId = x.Rollid,
                    DepartmentId = x.DeptId,
                    DepartmentName = x.DepartmentNavigation!.DeptName, 
                    IsActive = true,
                    ModifiedOn = DateTime.Now,
                    CreatedBy = x.CreatedBy,
                    DateOfJoining = x.DateOfJoining
                }).ToListAsync();

            return emp;
        }


        public async Task<EmployeeEditDTO> GetEmployeeById(int id)
        {
            var objEmp = await _context.Users.FirstOrDefaultAsync(x => x.Id == id && x.Rollid == 3);
            if (objEmp != null)
            {
                return new EmployeeEditDTO
                {       
                    Id = objEmp.Id,
                    FirstName = objEmp.FirstName,
                    LastName = objEmp.LastName,
                    Email = objEmp.Email,
                    RoleId = objEmp.Rollid,
                    DepartmentId = objEmp.DeptId,
                    IsActive = true,
                    ModifiedOn = DateTime.Now,
                    CreatedBy = objEmp.CreatedBy,
                    DateOfJoining = DateTime.Now,
                };
            }
            return null;
        }

        public async Task<EmployeeDTO> UpdateEmployee(EmployeeEditDTO employee)
        {
            var emp = await _context.Users.FirstOrDefaultAsync(x => x.Id == employee.Id && x.Rollid == 3);
            if (emp != null)
            {
                // Map updated values
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
                emp.Rollid = 3; // Keep constant or map from DTO if needed
                emp.DeptId = employee.DepartmentId;
                emp.IsActive = true;
                emp.ModifiedOn = DateTime.Now;
                emp.CreatedBy = employee.CreatedBy;
                emp.DateOfJoining = employee.DateOfJoining;

                // Update entity in context
                _context.Users.Update(emp);
                await _context.SaveChangesAsync();

                // Return updated DTO
                return new EmployeeDTO
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email,
                    RoleId = emp.Rollid,
                    DepartmentId = emp.DeptId,
                    IsActive = emp.IsActive,
                    ModifiedOn = emp.ModifiedOn,
                    CreatedBy = emp.CreatedBy,
                    DateOfJoining = emp.DateOfJoining
                };
            }

            return null;
        }

    }
}
