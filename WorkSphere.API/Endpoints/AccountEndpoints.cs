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
using WorkSphere.Application.Interfaces.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace WorkSphere.API.Endpoints
{
    public static class AccountEndpoints
    {
        public static void Register_LoginEndpoint(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var app = endpointRouteBuilder.MapGroup("").WithTags("Account");


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

            app.MapGet("account/Getall", async (WorkSphereDbContext dbContext, int pageNumber =1, int pageSize =10) =>
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 10) pageSize = 10;

                var users = await dbContext.Users.Where(e => e.IsActive == true).ToListAsync();

                var count = users.Count();

                var totalUsers = users.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(users => new UserShowDTO
                {
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Phone = users.PhoneNumber,
                    Gender = users.Gender,
                    Country = users.Country,
                    Email = users.Email,
                    RoleName = users.RoleNavigation.Name,
                    DeptName = users.DepartmentNavigation.DeptName,
                    DateOfBirth = users.DateOfBirth,
                    DateOfJoining = users.DateOfJoining,
                    IsActive = users.IsActive,
                    IsDeleted = users.IsDeleted,
                    ProfileImgPath = users.ProfileImgPath

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
            });

            

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
           
            app.MapPost("/account/login", [AllowAnonymous] async (LogInDTO request, UserManager<User> userManager, IConfiguration configuration) =>
            {
                if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
                {
                    return Results.BadRequest("Email and Password are required.");
                }

                // Get user by email
                var user = await userManager.Users.Include(r => r.RoleNavigation).FirstOrDefaultAsync(u => u.Email == request.Email);

                
                if (user == null)
                {
                    return Results.Unauthorized();
                }

                // Check password
                var passwordCheck = await userManager.CheckPasswordAsync(user, request.Password);
                if (!passwordCheck)
                {
                    return Results.Unauthorized();
                }

              

                // JWT Token Creation
                var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
              new Claim("FirstName", user.FirstName),
        new Claim("LastName", user.LastName),
            new Claim(ClaimTypes.Role,user!.RoleNavigation!.Name! )
        }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = configuration["Jwt:Issuer"],
                    Audience = configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                // Return JWT token and user info
                return Results.Ok(new
                {
                    Message = "Login successful.",
                    Token = tokenString,
                    User = new
                    {
                        user.Id,
                        user.UserName,
                        user.Email,
                        user.FirstName,
                        user.LastName,
                        user.RoleNavigation.Name

                    }
                });
            });






            app.MapGet("GetUser/{id}", async ( IAccountService service, int id) =>
            {
                var manager =  await service.GetUserByIdAsync(id);
                if(manager != null)
                {
                    var showManager = new UserShowDTO
                    {
                        FirstName = manager.FirstName,
                        LastName = manager.LastName,
                        Phone = manager.PhoneNumber,
                        Gender = manager.Gender,
                        Country = manager.Country,
                        Email = manager.Email,
                        RoleName = manager.RoleNavigation.Name,
                        DeptName = manager.DepartmentNavigation.DeptName,
                        DateOfBirth = manager.DateOfBirth,
                        DateOfJoining = manager.DateOfJoining,
                        IsActive = manager.IsActive,
                        IsDeleted = manager.IsDeleted,
                        ProfileImgPath = manager.ProfileImgPath

                    };

                    return Results.Ok(showManager);
                }

                return Results.NotFound("No User Found");

                
            });


        }
    }
}
