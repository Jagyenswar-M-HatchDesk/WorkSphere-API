using Microsoft.EntityFrameworkCore;
using WorkSphere.Infrastructure;

namespace WorkSphere.API.Extension
{
    public static class MigrationDbcontext
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using WorkSphereDbContext context = scope.ServiceProvider.GetRequiredService<WorkSphereDbContext>();

            context.Database.Migrate();
        }
    }
}
