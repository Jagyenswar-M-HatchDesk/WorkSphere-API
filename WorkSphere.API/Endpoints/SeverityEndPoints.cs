using Microsoft.EntityFrameworkCore;
using WorkSphere.Infrastructure;

namespace WorkSphere.API.Endpoints
{
    public static class SeverityEndPoints
    {
        public static void Severity_Endponits(this IEndpointRouteBuilder builder)
        {
            var app = builder.MapGroup("").WithTags("Severity Levels");

            app.MapGet("GetSeverityLevel", async (WorkSphereDbContext dbcontext) =>
            {
                var level = await dbcontext.SeverityLevel.ToListAsync();
                return level;
            });
        }
    }
}
