using WorkSphere.Infrastructure;
using WorkSphere.Application.DTOs;
using WorkSphere.Domain;
using Microsoft.EntityFrameworkCore;

namespace WorkSphere.API.Endpoints
{
    public static class DepartmentEndpoints
    {
        public static void DepartmentEndpoint(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Department");

            app.MapPost("AddDepartment", async (WorkSphereDbContext dbcontext, DepartmentDTO dto) =>
            {
                var dept = new Department
                {
                    DeptName = dto.DeptName,
                    IsActive = true,
                    IsDelete = false,
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now
                };
                dbcontext.AddAsync(dept);
                await dbcontext.SaveChangesAsync();

                return Results.Ok(new
                {
                    Message = "Successfully Created a Department",
                    Department = dept 
                });

            });

            app.MapGet("GetDepartment", async (WorkSphereDbContext dbcontext) =>
            {
                var dept = await dbcontext.mst_Departments.Where(e => e.IsActive == true).ToListAsync();
                return dept;
            });

            
        }
    }
}
