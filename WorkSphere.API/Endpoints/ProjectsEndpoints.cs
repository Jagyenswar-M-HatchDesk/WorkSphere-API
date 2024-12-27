using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;
using WorkSphere.Infrastructure;

namespace WorkSphere.API.Endpoints
{
    public static class ProjectsEndpoints
    {


        public static void Projects_Endpoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Projects");

            app.MapGet("GetAllProject", async (IProjectService projservice, string? title, string? department, string? client, string? status, string? manager, string? sorting = "", int pageNumber = 1, int pageSize = 10, bool isAscending = true) =>
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 10;

                var proj = await projservice.GetallProjAsync();

                //searching
                var filteredProjects = proj.Where(p =>
                    (string.IsNullOrEmpty(title) || p.Title!.Contains(title, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(department) || p.DepartmentNav!.DeptName.Contains(department, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(client) || p.ClientNavigation!.ClientName.Contains(client, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(status) || p.StatusNav!.StatusName.Contains(status, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(manager) || p.ManagerNavigation!.FirstName.Contains(manager, StringComparison.OrdinalIgnoreCase))
                //&&
                //(string.IsNullOrEmpty(status) || proj.StatusNav.StatusName.Contains(status, StringComparison.OrdinalIgnoreCase))
                );

                //sortiing
                filteredProjects = sorting.ToLower() switch
                {
                    "title" => isAscending ? filteredProjects.OrderBy(p => p.Title).ToList() : filteredProjects.OrderByDescending(p => p.Title).ToList(),
                    "startdate" => isAscending ? filteredProjects.OrderBy(p => p.StartDate).ToList() : filteredProjects.OrderByDescending(p => p.StartDate).ToList(),
                    "teamSize" => isAscending ? filteredProjects.OrderBy(p => p.TeamSize).ToList() : filteredProjects.OrderByDescending(p => p.TeamSize).ToList(),
                    "createdon" => isAscending ? filteredProjects.OrderBy(p => p.CreatedOn).ToList() : filteredProjects.OrderByDescending(p => p.CreatedOn).ToList(),
                    "manager" => isAscending ? filteredProjects.OrderBy(p => p.ManagerNavigation?.FirstName).ToList() : filteredProjects.OrderByDescending(p => p.ManagerNavigation?.FirstName).ToList(),
                    "enddate" => isAscending ? filteredProjects.OrderBy(p => p.Deadline).ToList() : filteredProjects.OrderByDescending(p => p.Deadline).ToList(),
                    "department" => isAscending ? filteredProjects.OrderBy(p => p.DepartmentNav?.DeptName).ToList() : filteredProjects.OrderByDescending(p => p.DepartmentNav?.DeptName).ToList(),
                    "status" => isAscending ? filteredProjects.OrderBy(p => p.StatusNav?.StatusName).ToList() : filteredProjects.OrderByDescending(p => p.StatusNav?.StatusName).ToList(),
                    _ => filteredProjects.OrderBy(p => p.ProjID).ToList(), // Default sorting by Title
                };


                var count = filteredProjects.Count();

                var pageProduct = filteredProjects.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                 .Select(proj => new ProjectsDTO
                 {
                     ProjID = proj.ProjID,
                     Title = proj.Title,
                     ProjDescr = proj.ProjDescr,
                     TeamSize = proj.TeamSize,
                     StartDate = proj.StartDate,
                     Department = proj.DepartmentID,
                     DepartmentName = proj.DepartmentNav?.DeptName ?? "Null",
                     Client = proj.ClientId,
                     ClientName = proj.ClientNavigation?.ClientName ?? "Null",
                     Manager = proj.ManagerID,
                     ManagerName = proj.ManagerNavigation?.FirstName ?? "Null",
                     Deadline = proj.Deadline,
                     ImagePath = proj.ImagePath,
                     Status = proj.StatusId,
                     StatusName = proj.StatusNav?.StatusName ?? "Null",
                     SeverityLevel = proj.SeverityLevelId,
                     SeverityLevelName = proj.SeverityLevelNav?.level ?? "Null",
                     IsActive = proj.IsActive,
                     IsCompleted = proj.IsCompleted,
                     ModifiedOn = proj.ModifiedOn,
                     CreatedBy = proj.CreatedBy,
                     CreatedOn = proj.CreatedOn
                 });

                return Results.Ok(new
                {
                    Total = count,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                    Projects = pageProduct
                });
            });



            //app.MapPost("AddProject", async (IProjectService projService, ProjectCreateDTO projDto) =>
            //{
            //    var addproject = await projService.AddProjectAsync(projDto);
            //    var proj = new ProjectsDTO()
            //    {
            //        ProjID = addproject.ProjID,
            //        Title = addproject.Title,
            //        ProjDescr = addproject.ProjDescr,
            //        TeamSize = addproject.TeamSize,
            //        StartDate = addproject.StartDate,
            //        Department = addproject.DepartmentID,
            //        Client = addproject.ClientId,
            //        Manager = addproject.ManagerID,
            //        Deadline = addproject.Deadline,
            //        ImagePath = addproject.ImagePath,
            //        Status = addproject.StatusId,
            //        SeverityLevel = addproject.SeverityLevelId,
            //        CreatedBy = addproject.CreatedBy,
            //        CreatedOn = addproject.CreatedOn,
            //        IsCompleted = addproject.IsCompleted,
            //        IsActive = addproject.IsActive,
            //        ModifiedOn = addproject.ModifiedOn

            //    };

            //    return Results.Ok(new
            //    {
            //        message = "Successfully Created a new Project",
            //        Project = proj
            //    });
            //});
            //app.MapPost("AddProject", async (IProjectService projService, [FromForm] ProjectCreateDTO projDto, IHostEnvironment environment) =>
            //{
            //    // Validate incoming project details
            //    if (projDto == null)
            //    {
            //        return Results.BadRequest(new { message = "Invalid project data" });
            //    }

            //    // Handle image upload
            //    string imagePath = null;
            //    if (projDto.ImageFile != null)
            //    {
            //        var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
            //        if (!Directory.Exists(uploadsFolder))
            //        {
            //            Directory.CreateDirectory(uploadsFolder);
            //        }

            //        var uniqueFileName = $"{Guid.NewGuid()}_{projDto.ImageFile.FileName}";
            //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await projDto.ImageFile.CopyToAsync(fileStream);
            //        }

            //        // Save relative path
            //        imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
            //    }

            //    // Add the project
            //    projDto.ImagePath = imagePath;
            //    var addproject = await projService.AddProjectAsync(projDto);

            //    var proj = new ProjectsDTO()
            //    {
            //        ProjID = addproject.ProjID,
            //        Title = addproject.Title,
            //        ProjDescr = addproject.ProjDescr,
            //        TeamSize = addproject.TeamSize,
            //        StartDate = addproject.StartDate,
            //        Department = addproject.DepartmentID,
            //        Client = addproject.ClientId,
            //        Manager = addproject.ManagerID,
            //        Deadline = addproject.Deadline,
            //        ImagePath = addproject.ImagePath,
            //        Status = addproject.StatusId,
            //        SeverityLevel = addproject.SeverityLevelId,
            //        CreatedBy = addproject.CreatedBy,
            //        CreatedOn = addproject.CreatedOn,
            //        IsCompleted = addproject.IsCompleted,
            //        IsActive = addproject.IsActive,
            //        ModifiedOn = addproject.ModifiedOn
            //    };

            //    return Results.Ok(new
            //    {
            //        message = "Successfully Created a new Project",
            //        Project = proj
            //    });
            //});


            app.MapPost("AddProject", async ([FromForm] IFormFile? imageFile, [FromForm] ProjectCreateDTO projDto, IProjectService projService, IHostEnvironment environment) =>
            {
                // Validate Anti-Forgery Token
                //await antiforgery.ValidateRequestAsync(context);

                // Validate DTO
                if (projDto == null)
                {
                    return Results.BadRequest(new { message = "Invalid project data." });
                }

                // Handle file upload
                string imagePath = null;
                if (imageFile != null)
                {
                    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, and .webp are allowed." });
                    }

                    var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
                }

                // Set the image path in DTO
                projDto.ImagePath = imagePath;

                // Add the project
                var addedProject = await projService.AddProjectAsync(projDto);

                // Return the response
                return Results.Ok(new
                {
                    message = "Successfully created a new project",
                    Project = new
                    {
                        addedProject.ProjID,
                        addedProject.Title,
                        addedProject.ProjDescr,
                        addedProject.ClientId,
                        addedProject.ManagerID,
                        addedProject.DepartmentID,
                        addedProject.TeamSize,
                        addedProject.StartDate,
                        addedProject.Deadline,
                        addedProject.ImagePath,
                        addedProject.StatusId,
                        addedProject.SeverityLevelId
                    }
                });
            }).DisableAntiforgery();

            //app.MapPost("AddProject1", async ([FromForm] IFormFile? imageFile, 
            //    [FromForm]string title, 
            //    [FromForm]string projdescr,
            //    [FromForm]int clientid,
            //    [FromForm]int managerid,
            //    [FromForm]int departmentid,
            //    [FromForm]int teamsize,
            //    [FromForm]datetime, IProjectService projService, IHostEnvironment environment) =>
            //{
            //    // Validate Anti-Forgery Token
            //    //await antiforgery.ValidateRequestAsync(context);

            //    // Validate DTO
            //    if (projDto == null)
            //    {
            //        return Results.BadRequest(new { message = "Invalid project data." });
            //    }

            //    // Handle file upload
            //    string imagePath = null;
            //    if (imageFile != null)
            //    {
            //        var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp" };
            //        var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            //        if (!allowedExtensions.Contains(fileExtension))
            //        {
            //            return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, and .webp are allowed." });
            //        }

            //        var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
            //        if (!Directory.Exists(uploadsFolder))
            //        {
            //            Directory.CreateDirectory(uploadsFolder);
            //        }

            //        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await imageFile.CopyToAsync(fileStream);
            //        }

            //        imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
            //    }

            //    // Set the image path in DTO
            //    projDto.ImagePath = imagePath;

            //    // Add the project
            //    var addedProject = await projService.AddProjectAsync(projDto);

            //    // Return the response
            //    return Results.Ok(new
            //    {
            //        message = "Successfully created a new project",
            //        Project = new
            //        {
            //            addedProject.ProjID,
            //            addedProject.Title,
            //            addedProject.ProjDescr,
            //            addedProject.ClientId,
            //            addedProject.ManagerID,
            //            addedProject.DepartmentID,
            //            addedProject.TeamSize,
            //            addedProject.StartDate,
            //            addedProject.Deadline,
            //            addedProject.ImagePath,
            //            addedProject.StatusId,
            //            addedProject.SeverityLevelId
            //        }
            //    });
            //}).DisableAntiforgery();
            app.MapPost("AddProject1", async (
    [FromForm] IFormFile? imageFile,
    [FromForm] string title,
    [FromForm] string projdescr,
    [FromForm] int clientid,
    [FromForm] int managerid,
    [FromForm] int departmentid,
    [FromForm] int teamsize,
    [FromForm] int severitylevel,
    [FromForm] string startDate, // Expecting string for manual parsing
    [FromForm] string deadline, // Expecting string for manual parsing
    IProjectService projService,
    IHostEnvironment environment) =>
            {
                // Parse DateTime values
                if (!DateTime.TryParse(startDate, out var parsedStartDate) ||
                    !DateTime.TryParse(deadline, out var parsedDeadline))
                {
                    return Results.BadRequest(new { message = "Invalid date format. Please use yyyy-MM-dd or yyyy-MM-ddTHH:mm:ss." });
                }

                // Handle file upload
                string imagePath = null;
                if (imageFile != null)
                {
                    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, and .webp are allowed." });
                    }

                    var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
                }

                // Construct DTO manually
                var projDto = new ProjectCreateDTO
                {
                    Title = title,
                    ProjDescr = projdescr,
                    Client = clientid,
                    Manager = managerid,
                    Department = departmentid,
                    TeamSize = teamsize,
                    StartDate = parsedStartDate,
                    Deadline = parsedDeadline,
                    ImagePath = imagePath,
                    SeverityLevel = severitylevel

                };

                // Add the project
                var addedProject = await projService.AddProjectAsync(projDto);

                // Return response
                return Results.Ok(new
                {
                    message = "Successfully created a new project",
                    Project = new
                    {
                        addedProject.ProjID,
                        addedProject.Title,
                        addedProject.ProjDescr,
                        addedProject.ClientId,
                        addedProject.ManagerID,
                        addedProject.DepartmentID,
                        addedProject.TeamSize,
                        addedProject.StartDate,
                        addedProject.Deadline,
                        addedProject.ImagePath,
                        //addedProject.StatusId,
                        addedProject.SeverityLevelId
                    }
                });
            }).DisableAntiforgery();






            app.MapGet("Project/{id}", async (IProjectService projService, int id) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if (proj != null)
                {
                    var viewproj = new ProjectsDTO
                    {
                        ProjID = proj.ProjID,
                        Title = proj.Title,
                        ProjDescr = proj.ProjDescr,
                        TeamSize = proj.TeamSize,
                        StartDate = proj.StartDate,
                        Department = proj.DepartmentID,
                        DepartmentName = proj.DepartmentNav?.DeptName ?? "Null",
                        Client = proj.ClientId,
                        ClientName = proj.ClientNavigation?.ClientName ?? "Null",
                        Manager = proj.ManagerID,
                        ManagerName = proj.ManagerNavigation?.FirstName ?? "Null",
                        Deadline = proj.Deadline,
                        ImagePath = proj.ImagePath,
                        Status = proj.StatusId,
                        StatusName = proj.StatusNav?.StatusName ?? "Null",
                        SeverityLevel = proj.SeverityLevelId,
                        SeverityLevelName = proj.SeverityLevelNav?.level ?? "Null",
                        IsActive = proj.IsActive,
                        IsCompleted = proj.IsCompleted,
                        ModifiedOn = proj.ModifiedOn,
                        CreatedBy = proj.CreatedBy,
                        CreatedOn = proj.CreatedOn
                    };


                    return Results.Ok(new
                    {
                        message = "Successfully Updated the Project",
                        Project = viewproj
                    });

                }
                return Results.Empty;
            });

            //app.MapPost("AddProject", async ([FromForm] IFormFile? imageFile, [FromForm] ProjectCreateDTO projDto, IProjectService projService, IHostEnvironment environment) =>
            //{

            //    if (projDto == null)
            //    {
            //        return Results.BadRequest(new { message = "Invalid project data." });
            //    }

            //    // Validate and save the uploaded file
            //    string imagePath = null;
            //    if (imageFile != null)
            //    {
            //        var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp" };
            //        var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

            //        if (!allowedExtensions.Contains(fileExtension))
            //        {
            //            return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, and .webp are allowed." });
            //        }

            //        var uploadsFolder = Path.Combine(environment.ContentRootPath, "Uploads");
            //        if (!Directory.Exists(uploadsFolder))
            //        {
            //            Directory.CreateDirectory(uploadsFolder);
            //        }

            //        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
            //        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            //        using (var fileStream = new FileStream(filePath, FileMode.Create))
            //        {
            //            await imageFile.CopyToAsync(fileStream);
            //        }

            //        imagePath = Path.Combine("Uploads", uniqueFileName).Replace("\\", "/");
            //    }

            //    // Assign the uploaded image path to the DTO
            //    projDto.ImagePath = imagePath;

            //    // Add the project
            //    var addedProject = await projService.AddProjectAsync(projDto);

            //    // Return response
            //    return Results.Ok(new
            //    {
            //        message = "Successfully created a new project",
            //        Project = new
            //        {
            //            addedProject.ProjID,
            //            addedProject.Title,
            //            addedProject.ProjDescr,
            //            addedProject.ClientId,
            //            addedProject.ManagerID,
            //            addedProject.DepartmentID,
            //            addedProject.TeamSize,
            //            addedProject.StartDate,
            //            addedProject.Deadline,
            //            addedProject.ImagePath,
            //            addedProject.StatusId,
            //            addedProject.SeverityLevelId
            //        }
            //    });
            //});

            app.MapPut("UpdateProject/{id}", async (IProjectService projService, int id, ProjectEditDTO projDto) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if (proj == null) return Results.NotFound();

                proj.Title = projDto.Title;
                proj.ProjDescr = projDto.ProjDescr;
                proj.TeamSize = projDto.TeamSize;
                proj.StartDate = projDto.StartDate;
                proj.DepartmentID = projDto.Department;
                //proj.Client = projDto.Client;
                proj.ManagerID = projDto.Manager;
                proj.Deadline = projDto.Deadline;
                proj.ImagePath = projDto.ImagePath;
                proj.StatusId = projDto.Status;
                proj.SeverityLevelId = projDto.SeverityLevel;
                proj.ModifiedOn = DateTime.Now;

                await projService.UpdateProjAsync(proj);
                return Results.Ok(new
                {
                    message = "Successfully Updated data",
                    Project = new ProjectsDTO
                    {
                        ProjID = proj.ProjID,
                        Title = proj.Title,
                        ProjDescr = proj.ProjDescr,
                        TeamSize = proj.TeamSize,
                        StartDate = proj.StartDate,
                        Department = proj.DepartmentID,
                        DepartmentName = proj.DepartmentNav?.DeptName ?? "Null",
                        Client = proj.ClientId,
                        ClientName = proj.ClientNavigation?.ClientName ?? "Null",
                        Manager = proj.ManagerID,
                        ManagerName = proj.ManagerNavigation?.FirstName ?? "Null",
                        Deadline = proj.Deadline,
                        ImagePath = proj.ImagePath,
                        Status = proj.StatusId,
                        StatusName = proj.StatusNav?.StatusName ?? "Null",
                        SeverityLevel = proj.SeverityLevelId,
                        SeverityLevelName = proj.SeverityLevelNav?.level ?? "Null",
                        IsActive = proj.IsActive,
                        IsCompleted = proj.IsCompleted,
                        ModifiedOn = proj.ModifiedOn,
                        CreatedBy = proj.CreatedBy,
                        CreatedOn = proj.CreatedOn
                    }
                });
            });

            app.MapGet("SearchProjects", async (IProjectService projService, string? title, string? department, string? client, string? status, string? manager, int pageNumber = 1, int pageSize = 10) =>
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 10;
                // Fetch all projects
                var projects = await projService.GetallProjAsync();

                // Apply filters if search criteria are provided
                var filteredProjects = projects.Where(proj =>
                    (string.IsNullOrEmpty(title) || proj.Title!.Contains(title, StringComparison.OrdinalIgnoreCase))
                    &&
                    (string.IsNullOrEmpty(department) || proj.DepartmentNav!.DeptName.Contains(department, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(client) || proj.ClientNavigation!.ClientName.Contains(client, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(status) || proj.StatusNav!.StatusName.Contains(status, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(status) || proj.ManagerNavigation!.FirstName.Contains(status, StringComparison.OrdinalIgnoreCase))
                //&&
                //(string.IsNullOrEmpty(status) || proj.StatusNav.StatusName.Contains(status, StringComparison.OrdinalIgnoreCase))
                );

                var count = filteredProjects.Count();
                // Transform to DTOs
                var result = filteredProjects.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(proj => new ProjectsDTO
                {
                    ProjID = proj.ProjID,
                    Title = proj.Title,
                    ProjDescr = proj.ProjDescr,
                    TeamSize = proj.TeamSize,
                    StartDate = proj.StartDate,
                    Department = proj.DepartmentID,
                    DepartmentName = proj.DepartmentNav?.DeptName ?? "Null",
                    Client = proj.ClientId,
                    ClientName = proj.ClientNavigation?.ClientName ?? "Null",
                    Manager = proj.ManagerID,
                    ManagerName = proj.ManagerNavigation?.FirstName ?? "Null",
                    Deadline = proj.Deadline,
                    ImagePath = proj.ImagePath,
                    Status = proj.StatusId,
                    StatusName = proj.StatusNav?.StatusName ?? "Null",
                    SeverityLevel = proj.SeverityLevelId,
                    SeverityLevelName = proj.SeverityLevelNav?.level ?? "Null",
                    IsActive = proj.IsActive,
                    IsCompleted = proj.IsCompleted,
                    ModifiedOn = proj.ModifiedOn,
                    CreatedBy = proj.CreatedBy,
                    CreatedOn = proj.CreatedOn
                });

                return Results.Ok(new
                {
                    Count = count,
                    CurrentPaage = pageNumber,
                    Size = pageSize,
                    TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                    Peojects = result
                });
            });


            //app.MapPost()
            // app.MapDelete("CompleteProject", async ())
        }

    }
}
