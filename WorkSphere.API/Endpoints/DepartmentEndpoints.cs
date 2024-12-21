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

            });

            app.MapGet("GetDepartment", async (WorkSphereDbContext dbcontext) =>
            {
                var dept = await dbcontext.Departments.Where(e => e.IsActive == true).ToListAsync();
                return dept;
            });

            app.MapGet("GetSeverityLevel", async (WorkSphereDbContext dbcontext) =>
            {
                var level = await dbcontext.SeverityLevel.ToListAsync();
                return level;
            });
        }
    }
}
