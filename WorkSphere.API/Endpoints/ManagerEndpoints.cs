using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Application.Services;
using WorkSphere.Domain;
using WorkSphere.Infrastructure;
using WorkSphere.Infrastructure.Repository;

namespace WorkSphere.API.Endpoints
{
    public static class ManagerEndpoints
    {
        public static void Manager_Endpoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Manager");

            app.MapGet("GetManagers", async (WorkSphereDbContext dbcontext) =>
            {
                var manager = await dbcontext.Users.Where(e => e.IsActive == true && e.Rollid == 2)
                .Select(manager => new ManagerDto()
                {
                    FullName = manager.FirstName + " " + manager.LastName,
                    Id = manager.Id,
                    projects = manager.Projects.Select(p => new ProjectsName() { Title = p.Title}).ToList(),
                }).ToListAsync();
                //var fullname = manager.Select(manager => new ManagerDto() { FullName = manager.FirstName + " " + manager.LastName, Id = manager.Id, projects = manager.Projects });
                return manager;
            });

            app.MapPost("account/register-manager", async (ManagerCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IAccountService service, IEmailService emailService) =>
            {
                if (string.IsNullOrWhiteSpace(request.Email) )//|| string.IsNullOrWhiteSpace(request.Password))
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
                    Rollid = 2, 
                    DateOfJoining = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    ModifiedOn = DateTime.Now,
                    CreatedBy = 1,
                    LastLogin = DateTime.Now
                };

                var password = await service.GeneratePasswordAsync();
                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return Results.BadRequest(result.Errors);
                }

                var role = await roleManager.FindByIdAsync(user.Rollid.ToString());
                if (role != null)
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }

                var emailSubject = "Your Manager Account Credentials";
                var emailBody = $@"
                    <h3>Welcome, {user.FirstName} {user.LastName}!</h3>
                    <p>Your manager account has been created successfully.</p>
                    <p><strong>Email:</strong> {user.Email}</p>
                    <p><strong>Password:</strong> {password}</p>
                    <p>Please log in and change your password immediately.</p>";

                await emailService.SendEmailAsync(user.Email, emailSubject, emailBody);

                return Results.Ok(new { Message = "User registered successfully.", manager = user.Email, Password = password });
            });

            
            app.MapPut("EditManager/{id}", async ([FromRoute] int id, [FromForm] IFormFile image, [FromForm] UserEditDto manager, UserManager<User> userManager, IHostEnvironment envoriment, IAccountService service) =>
            {
                if (manager == null)
                {
                    Results.BadRequest("Invalid DTO ");
                }

                string imagepath = null;
                if (image != null)
                {
                    var allowExtension = new[] { ".jpeg", ".jpg", ".webp", ".png", ".svg" };
                    var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();

                    if (!allowExtension.Contains(fileExtension))
                    {
                        return Results.BadRequest("Invalid Type File. We only allow .jpeg, .jpg, .png, .svg, .webp ");

                    }

                    var uploadfolder = Path.Combine(envoriment.ContentRootPath, "Uploads/ProfileImage");
                    if (!Directory.Exists(uploadfolder))
                    {
                        Directory.CreateDirectory(uploadfolder);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    var filepath = Path.Combine(uploadfolder, uniqueFileName);

                    using (var Filestream = new FileStream(filepath, FileMode.Create))
                    {
                        await image.CopyToAsync(Filestream);
                    }

                    imagepath = Path.Combine("Uploads/ProfileImage", uniqueFileName).Replace("\\", "/");
                }

                var editmanager = await service.GetUserByIdAsync(id);
                if (editmanager == null) return Results.BadRequest("NO User Found");

                editmanager.FirstName = manager.FirstName;
                editmanager.LastName = manager.LastName;
                editmanager.Email = manager.Email;
                editmanager.UserName = manager.Email;
                editmanager.Gender = manager.Gender;
                editmanager.PhoneNumber = manager.Phone;
                editmanager.Country = manager.Country;
                editmanager.DateOfBirth = manager.DateofBirth;
                editmanager.ModifiedOn = DateTime.Now;
                editmanager.ProfileImgPath = imagepath;

                await userManager.UpdateAsync(editmanager);
                return Results.Ok(new
                {
                    Message = "Manager Updated Successfully",
                    Info = new UserEditDto
                    {
                        FirstName = editmanager.FirstName,
                        LastName = editmanager.LastName,
                        Email = editmanager.Email,
                        Gender = editmanager.Gender,
                        Country = editmanager.Country,
                        DateofBirth = editmanager.DateOfBirth,
                        Phone = editmanager.PhoneNumber,

                    },
                    ImagePath = imagepath
                });



            }).DisableAntiforgery();


        }
    }
}
