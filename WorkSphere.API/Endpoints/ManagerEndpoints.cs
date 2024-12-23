using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Infrastructure;

namespace WorkSphere.API.Endpoints
{
    public static class ManagerEndpoints
    {
        public static void Manager_Endpoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Manager");

            app.MapGet("GetManagers", async (WorkSphereDbContext dbcontext) =>
            {
                var manager = await dbcontext.Users.Where(e => e.IsActive == true && e.Rollid == 2).ToListAsync();
                var fullname = manager.Select(manager => new ManagerDto() { FullName = manager.FirstName + " " + manager.LastName, Id = manager.Id });
                return fullname;
            });
        }
    }
}
