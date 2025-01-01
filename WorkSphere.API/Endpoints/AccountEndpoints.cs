using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Identity;
using WorkSphere.Domain;
using WorkSphere.Application;
using WorkSphere.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WorkSphere.Application.DTOs.RegisterDTO;
using System.Runtime.InteropServices;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Application.DTOs.UserDTO;

namespace WorkSphere.API.Endpoints
{
    public static class AccountEndpoints
    {
        public static void Register_LoginEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var app = endpointRouteBuilder.MapGroup("").WithTags("Account");



            //app.MapPost("account/register", async (RegisterCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, WorkSphereDbContext dbContext) =>
            //{
            //    // Validate incoming request
            //    if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password) )
            //    {
            //        return Results.BadRequest("Invalid request data. Ensure all fields are provided.");
            //    }

            //    // Check if the department exists
            //    //var departmentExists = await dbContext.Departments.AnyAsync(d => d.Id == request.Department);
            //    //var roleExists = await roleManager.Roles.AnyAsync(r => r.Id == request.Rollid);

            //    //if (!departmentExists || !roleExists)
            //    //{
            //    //    return Results.BadRequest("Invalid department or role ID.");
            //    //}

            //    // Create the user
            //    var user = new User
            //    {
            //        UserName = request.Email,
            //        Email = request.Email,
            //        FirstName = request.FirstName,
            //        LastName = request.LastName,
            //        PasswordHash = request.Password,
            //        DeptId = 1,
            //        Rollid = 3,
            //        DateOfJoining = DateTime.UtcNow,
            //        IsActive = true,
            //        IsDeleted = false
            //    };

            //    var result = await userManager.CreateAsync(user, request.Password);

            //    if (!result.Succeeded)
            //    {
            //        return Results.BadRequest(result.Errors);
            //    }

            //    return Results.Ok(new { Message = "User registered successfully." ,
            //    User = user});
            //});

            app.MapPost("account/register", async (RegisterCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager) =>
            {
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return Results.BadRequest("Invalid request data.");
                }

                var user = new User
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DeptId = 1,
                    Rollid = 3, // Default to Employee role
                    DateOfJoining = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                };

                var result = await userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    return Results.BadRequest(result.Errors);
                }

                var role = await roleManager.FindByIdAsync(user.Rollid.ToString());
                if (role != null)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }

                return Results.Ok(new { Message = "User registered successfully." });
            });

            app.MapPost("account/register-admin", async (RegisterCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager) =>
            {
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return Results.BadRequest("Invalid request data.");
                }

                var user = new User
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DeptId = 1,
                    Rollid = 1, // Default to Employee role
                    DateOfJoining = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                };

                var result = await userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    return Results.BadRequest(result.Errors);
                }

                var role = await roleManager.FindByIdAsync(user.Rollid.ToString());
                if (role != null)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }

                return Results.Ok(new { Message = "User registered successfully." });
            });


            //app.MapPost("account/register-admin", async (RegisterCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, WorkSphereDbContext dbContext) =>
            //{
            //    // Validate incoming request
            //    if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
            //    {
            //        return Results.BadRequest("Invalid request data. Ensure all fields are provided.");
            //    }

            //    // Check if the department exists
            //    //var departmentExists = await dbContext.Departments.AnyAsync(d => d.Id == request.Department);
            //    //var roleExists = await roleManager.Roles.AnyAsync(r => r.Id == request.Rollid);

            //    //if (!departmentExists || !roleExists)
            //    //{
            //    //    return Results.BadRequest("Invalid department or role ID.");
            //    //}

            //    // Create the user
            //    var user = new User
            //    {
            //        UserName = request.Email,
            //        Email = request.Email,
            //        FirstName = request.FirstName,
            //        LastName = request.LastName,
            //        PasswordHash = request.Password,
            //        DeptId = 1,
            //        Rollid = 1,
            //        DateOfJoining = DateTime.UtcNow,
            //        IsActive = true,
            //        IsDeleted = false
            //    };

            //    var result = await userManager.CreateAsync(user, request.Password);

            //    if (!result.Succeeded)
            //    {
            //        return Results.BadRequest(result.Errors);
            //    }

            //    return Results.Ok(new
            //    {
            //        Message = "User registered successfully.",
            //        User = user
            //    });
            //});

            app.MapGet("account/Getall", async (WorkSphereDbContext dbContext, int pageNumber =1, int pageSize =10) =>
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 10) pageSize = 10;

                var users = await dbContext.Users.Where(e => e.IsActive == true).ToListAsync();

                var count = users.Count();

                var totalUsers = users.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(users => new RegisterDTO()
                {
                    UserName = users.UserName,
                    Email = users.Email,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Password = users.PasswordHash,
                    Department = users.DeptId,
                    Rollid=users.Rollid
                });

                return Results.Ok(new
                {
                    TotalCount = count,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPAges = (int)Math.Ceiling(count / (double)pageSize),
                    TotalUsers = totalUsers
                });
            });

            
            app.MapGet("account/checkAuth", async (ClaimsPrincipal claims, UserManager<User> userManager) =>
            {
                // Check if user is authenticated
                if (claims.Identity?.IsAuthenticated != true)
                {
                    return Results.Unauthorized();
                }

                // Get user details from claims
                var userId = claims.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Results.Unauthorized();
                }

                var user = await userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return Results.Unauthorized();
                }

                return Results.Ok(new
                {
                    IsAuthenticated = true,
                    User = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.FirstName,
                        user.LastName,
                        user.DeptId,
                        user.Rollid
                    }
                });
            }).RequireAuthorization();

            

            app.MapPost("account/logout", async (SignInManager<User> signInManager, HttpContext httpContext) =>
            {
                await signInManager.SignOutAsync();

                httpContext.Response.Cookies.Delete(".AspNetCore.Identity.Application");

                return Results.Ok(new { Message = "User logged out successfully." });
            });

            //app.MapPut("CreateManager", async (WorkSphereDbContext dbcontext,  ) =>
            //{

            //})
            app.MapGet("UserInfo", async (HttpContext httpContext, UserManager<User> userManager) =>
            {
                // Ensure the user is authenticated
                if (!httpContext.User.Identity.IsAuthenticated)
                {
                    return Results.Unauthorized();
                }

                // Get the currently logged-in user
                var userIdClaim = httpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim == null)
                {
                    return Results.BadRequest("User ID not found in claims.");
                }

                int userId = int.Parse(userIdClaim);
                var user = await userManager.FindByIdAsync(userId.ToString());

                if (user == null)
                {
                    return Results.NotFound("User not found.");
                }

                // Get roles
                var roles = await userManager.GetRolesAsync(user);

                // Map to DTO
                var userInfo = new UserDTO
                {
                    UserID = user.Id,
                    Email = user.UserName,
                    //Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Roles = roles.ToList()
                };

                return Results.Ok(userInfo);
            });
            app.MapPost("account/login", async (LogInDTO request, SignInManager<User> signInManager, UserManager<User> userManager) =>
            {
                // Validate the incoming request
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return Results.BadRequest("Email and Password are required.");
                }

                // Find the user by email

                //var user = await userManager.FindByEmailAsync(request.Email);
                var user = await userManager.Users
        .Include(u => u.DepartmentNavigation)
        .Include(u => u.RoleNavigation)
        .FirstOrDefaultAsync(u => u.Email == request.Email);
                if (user == null)
                {
                    return Results.Unauthorized();//new { Message = "Invalid email or password." });
                }

                // Check if the user is active
                if (!user.IsActive)
                {
                    return Results.Forbid();//new { Message = "Account is inactive. Please contact support." });
                }

                // Attempt to sign in the user
                var passwordCheck = await userManager.CheckPasswordAsync(user, request.Password);
                if (!passwordCheck)
                {
                    return Results.Unauthorized();//new { Message = "Invalid email or password." });
                }

                // Sign in the user
                await signInManager.SignInAsync(user, isPersistent: false);

                // Create a response with user info and roles
                var roles = await userManager.GetRolesAsync(user);

                var token = await userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "Purpose");
                return Results.Ok(new
                {
                    Message = "Login successful.",
                    Token = token,
                    User = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.FirstName,
                        user.LastName,
                        user.DepartmentNavigation.DeptName,
                        user.RoleNavigation.Name,
                        Roles = roles
                    }
                });
            });


        }
    }
}
