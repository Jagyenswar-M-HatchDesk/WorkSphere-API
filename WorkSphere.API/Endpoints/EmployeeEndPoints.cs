using WorkSphere.Application.DTOs.EmployeeDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;

namespace WorkSphere.API.Endpoints
{
    public static  class EmployeeEndPoints
    {

        public static void MapEmployeeEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var app = endpointRouteBuilder.MapGroup("api").WithTags("Employee");

            app.MapGet("GetAllProduct", async (IEmployeeService empservice) =>
            {

                var emp = await empservice.GetAllEmployeeAsync();
                return Results.Ok(new
                {
                    Employees = emp
                });
            });

            app.MapPost("AddEmployee", async ( EmployeeCreateDTO empDto, IEmployeeService empService) =>
            {
                // Validate DTO
                if (empDto == null)
                {
                    return Results.BadRequest(new { message = "Invalid project data." });
                }

                // Handle file upload
                //string imagePath = null;
                //if (imageFile != null)
                //{
                //    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp" };
                //    var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                //    if (!allowedExtensions.Contains(fileExtension))
                //    {
                //        return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, and .webp are allowed." });
                //    }

                //    var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
                //    if (!Directory.Exists(uploadsFolder))
                //    {
                //        Directory.CreateDirectory(uploadsFolder);
                //    }

                //    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                //    using (var fileStream = new FileStream(filePath, FileMode.Create))
                //    {
                //        await imageFile.CopyToAsync(fileStream);
                //    }

                //    imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
                //}

                //// Set the image path in DTO
                //prodDto.ImagePath = imagePath;

                // Add the project
                var addedProject = await empService.AddEmployeeAsync(empDto);

                // Return the response
                return Results.Ok(new
                {
                    message = "Successfully created a new Employee",
                    Project = new
                    {
                        addedProject.empId,
                        addedProject.FirstName,
                        addedProject.LastName,
                        addedProject.DateOfJoining,
                        addedProject.RoleId,
                        addedProject.DepartmentId,
                        addedProject.IsActive,
                        addedProject.IsDeleted,
                        addedProject.ModifiedOn,

                    }
                });
            }).DisableAntiforgery();

            app.MapPut("UpdateEmployee/{id}", async (IEmployeeService empService, int id, EmployeeEditDTO employee) =>
            {
                // Fetch employee by ID
                var emp = await empService.GetEmployeeByIdAsync(id);
                emp.empId = id;

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
                emp.RoleId = 3;
                emp.DepartmentId = employee.DepartmentId;
                emp.IsActive = employee.IsActive ?? emp.IsActive; // If nullable, keep old value if null
                emp.DateOfJoining = employee.DateOfJoining;
                emp.ModifiedOn = DateTime.Now;
             

                // Call update service
                var updated = await empService.UpdateEmployeeAsync(emp);

                if (updated != null)
                {
                    return Results.Ok(new
                    {
                        message = "Successfully Updated data",
                        emp = new EmployeeDTO
                        {
                            empId = emp.empId,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            DateOfJoining = emp.DateOfJoining,
                            RoleId = emp.RoleId,
                            DepartmentId = emp.DepartmentId,
                            IsActive = emp.IsActive,
                            IsDeleted = emp.IsDeleted,
                            CreatedBy = emp.CreatedBy,
                            ModifiedOn = emp.ModifiedOn
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
        }
    }
}
