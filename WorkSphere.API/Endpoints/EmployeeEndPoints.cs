using Microsoft.AspNetCore.Identity;
using WorkSphere.Application.DTOs.EmployeeDTO;
using WorkSphere.Application.DTOs.RegisterDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;

namespace WorkSphere.API.Endpoints
{
    public static  class EmployeeEndPoints
    {

        public static void MapEmployeeEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var app = endpointRouteBuilder.MapGroup("api").WithTags("Employee");

            app.MapGet("GetAllEmployee", async (IEmployeeService empservice) =>
            {

                var emp = await empservice.GetAllEmployeeAsync();
                return emp;
            });

            //app.MapPost("AddEmployee", async ( EmployeeCreateDTO empDto, IEmployeeService empService) =>
            //{
            //    // Validate DTO
            //    if (empDto == null)
            //    {
            //        return Results.BadRequest(new { message = "Invalid project data." });
            //    }

            //    // Handle file upload
            //    //string imagePath = null;
            //    //if (imageFile != null)
            //    //{
            //    //    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp" };
            //    //    var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            //    //    if (!allowedExtensions.Contains(fileExtension))
            //    //    {
            //    //        return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, and .webp are allowed." });
            //    //    }

            //    //    var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
            //    //    if (!Directory.Exists(uploadsFolder))
            //    //    {
            //    //        Directory.CreateDirectory(uploadsFolder);
            //    //    }

            //    //    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            //    //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //    //    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //    //    {
            //    //        await imageFile.CopyToAsync(fileStream);
            //    //    }

            //    //    imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
            //    //}

            //    //// Set the image path in DTO
            //    //prodDto.ImagePath = imagePath;

            //    // Add the project
            //    var addedProject = await empService.AddEmployeeAsync(empDto);

            //    // Return the response
            //    return Results.Ok(new
            //    {
            //        message = "Successfully created a new Employee",
            //        Project = new
            //        {
            //            addedProject.Id,
            //            addedProject.FirstName,
            //            addedProject.LastName,
            //            addedProject.DateOfJoining,
            //            addedProject.RoleId,
            //            addedProject.DepartmentId,
            //            addedProject.IsActive,
            //            addedProject.IsDeleted,
            //            addedProject.ModifiedOn,

            //        }
            //    });
            //}).DisableAntiforgery();

            app.MapPut("UpdateEmployee/{id}", async (IEmployeeService empService, int id, EmployeeEditDTO employee) =>
            {
                // Fetch employee by ID
                var emp = await empService.GetEmployeeByIdAsync(id);
                emp.Id = id;

                if (emp == null)
                {
                    return Results.NotFound(new
                    {
                        message = "This is not an employee"
                    });
                }

                // Update employee with new data from DTO
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
         
             

                // Call update service
                var updated = await empService.UpdateEmployeeAsync(emp);

                if (updated != null)
                {
                    return Results.Ok(new
                    {
                        message = "Successfully Updated data",
                        emp = new EmployeeDTO
                        {
                            Id = emp.Id,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Email = emp.Email
                     
                        }
                    });
                }

                return Results.StatusCode(500); // Internal server error for unexpected issues
            });


            app.MapGet("Employee/{id}", async (IEmployeeService empService, int id) =>
            {
                var emp = await empService.GetEmployeeByIdAsync(id);
                if (emp != null)
                {
                    return Results.Ok(new
                    {
                        message = "Successfully fetched the employee",
                        Employee = emp
                    });
                }

                // Return a custom message if employee is not found
                return Results.NotFound(new
                {
                    message = "This is not an employee"
                });
            });


            app.MapDelete("Employee/{id}", async (IEmployeeService empService, int id) =>
            {
                var emp = await empService.DeleteEmployeeAsync(id);
                
                if (emp)
                {
                    
                    return Results.Ok(new
                    {
                        message = "Employee has been deleted successfully",
                        Employee = emp
                    });

                }
                return Results.NotFound(new
                {
                    message = "This is not an employee"
                });
            });

            app.MapPost("account/register-Employee", async (EmployeeCreateDTO request, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, IAccountService service, IEmailService emailService) =>
            {
                if (string.IsNullOrWhiteSpace(request.Email))//|| string.IsNullOrWhiteSpace(request.Password))
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
                    Rollid = 3,
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

                var emailSubject = "Your Employee Account Credentials";
                var emailBody = $@"
                    <h3>Welcome, {user.FirstName} {user.LastName}!</h3>
                    <p>Your Employee account has been created successfully.</p>
                    <p><strong>Email:</strong> {user.Email}</p>
                    <p><strong>Password:</strong> {password}</p>
                    <p>Please log in and change your password immediately.</p>";

                await emailService.SendEmailAsync(user.Email, emailSubject, emailBody);

                return Results.Ok(new { Message = "User registered successfully.", manager = user.Email, Password = password });
            });
        }
    }
}
