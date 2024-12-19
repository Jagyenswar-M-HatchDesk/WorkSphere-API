using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using WorkSphere.Domain;
using WorkSphere.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkSphere.Application.DTOs.RegisterDTO;

namespace WorkSphere.API.Endpoints
{
    public static class AccountEndpoints
    {
        public static void Register_LoginEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var app = endpointRouteBuilder.MapGroup("").WithTags("Account");

            

            app.MapPost("account/register", async (RegisterCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, WorkSphereDbContext dbContext) =>
            {
                // Validate incoming request
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password) )
                {
                    return Results.BadRequest("Invalid request data. Ensure all fields are provided.");
                }

                // Check if the department exists
                //var departmentExists = await dbContext.Departments.AnyAsync(d => d.Id == request.Department);
                //var roleExists = await roleManager.Roles.AnyAsync(r => r.Id == request.Rollid);

                //if (!departmentExists || !roleExists)
                //{
                //    return Results.BadRequest("Invalid department or role ID.");
                //}

                // Create the user
                var user = new User
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = request.Password,
                    Department = 1,
                    Rollid = 3,
                    DateOfJoining = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                };

                var result = await userManager.CreateAsync(user, request.Password);

                if (!result.Succeeded)
                {
                    return Results.BadRequest(result.Errors);
                }

                return Results.Ok(new { Message = "User registered successfully." });
            });

            app.MapGet("account/Getall", async (WorkSphereDbContext dbContext) =>
            {
                var users = await dbContext.Users.Where(e => e.IsActive == true).ToListAsync();
                return users.Select(users => new RegisterDTO()
                {
                    UserName = users.UserName,
                    Email = users.Email,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Password = users.PasswordHash,
                    Department = users.Department,
                    Rollid=users.Rollid
                });
            }).RequireAuthorization();

            //app.MapGet("account/me", async (ClaimsPrincipal claims, WorkSphereDbContext context) =>
            //{
            //    var userd = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //    int id = userd;
            //    //return await context.Users.Where(e => e.Id == userd).ToListAsync();
            //}).RequireAuthorization();
        }
    }
}
