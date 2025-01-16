using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
            

            app.MapGet("GetAllProject", async (IProjectService projservice, string? sorting = "", int pageNumber = 1, int pageSize = 10, bool isAscending = true) =>
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 10;

                var proj = await projservice.GetallProjAsync();



                //sortiing
                proj = sorting.ToLower() switch
                {
                    "title" => isAscending ? proj.OrderBy(p => p.Title).ToList() : proj.OrderByDescending(p => p.Title).ToList(),
                    "startdate" => isAscending ? proj.OrderBy(p => p.StartDate).ToList() : proj.OrderByDescending(p => p.StartDate).ToList(),
                    "teamSize" => isAscending ? proj.OrderBy(p => p.TeamSize).ToList() : proj.OrderByDescending(p => p.TeamSize).ToList(),
                    "createdon" => isAscending ? proj.OrderBy(p => p.CreatedOn).ToList() : proj.OrderByDescending(p => p.CreatedOn).ToList(),
                    "manager" => isAscending ? proj.OrderBy(p => p.ManagerNavigation?.FirstName).ToList() : proj.OrderByDescending(p => p.ManagerNavigation?.FirstName).ToList(),
                    "enddate" => isAscending ? proj.OrderBy(p => p.Deadline).ToList() : proj.OrderByDescending(p => p.Deadline).ToList(),
                    "department" => isAscending ? proj.OrderBy(p => p.DepartmentNav?.DeptName).ToList() : proj.OrderByDescending(p => p.DepartmentNav?.DeptName).ToList(),
                    "status" => isAscending ? proj.OrderBy(p => p.StatusNav?.StatusName).ToList() : proj.OrderByDescending(p => p.StatusNav?.StatusName).ToList(),
                    _ => proj.OrderBy(p => p.ProjID).ToList(), // Default sorting by Title
                };


                var count = proj.Count();

                var pageProduct = proj.Skip((pageNumber - 1) * pageSize).Take(pageSize)
                 .Select(proj => new ProjectsDTO
                 {
                     Id = proj.ProjID,
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
                     SeverityLevelName = proj.SeverityLevelNav?.level ?? "Null",
                     SeverityLevel = proj.SeverityLevelId,
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
            }).RequireAuthorization(new AuthorizeAttribute { Roles = " Admin" });

            app.MapPost("AddProject", async ([FromForm] IFormFile? imageFile, [FromForm] ProjectCreateDTO projDto, IProjectService projService, IHostEnvironment environment) =>
            {
                

                // Validate DTO
                if (projDto == null)
                {
                    return Results.BadRequest(new { message = "Invalid project data." });
                }

                // Handle file upload
                string imagePath = null;
                if (imageFile != null)
                {
                    var allowedExtensions = new[] { ".jpeg", ".jpg", ".png", ".webp", ".pdf", ".docx", ".zip", ".rar" };
                    var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        return Results.BadRequest(new { message = "Invalid file type. Only .jpeg, .jpg, .png, .rar, .zip, .docx, .pdf and .webp are allowed." });
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
            }).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" }).DisableAntiforgery();

            
            app.MapGet("Project/{id}", async (IProjectService projService, int id) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if (proj != null)
                {
                    var viewproj = new ProjectsDTO
                    {
                        Id = proj.ProjID,
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
                return Results.NotFound("No Project Found");
            }).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

            
           
            app.MapPut("UpdateProject/{id}", async ([FromRoute]int id,[FromForm] IFormFile? imageFile, [FromForm] ProjectEditDTO projDto, IProjectService projService, IHostEnvironment environment) =>
            {
                //if (projDto == null)
                //{
                //    return Results.BadRequest(new { message = "Invalid project data." });
                //}

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
                proj.ImagePath = imagePath;
                //proj.StatusId = projDto.Status;
                proj.SeverityLevelId = projDto.SeverityLevel;
                proj.ModifiedOn = DateTime.Now;

                await projService.UpdateProjAsync(proj);
                return Results.Ok(new
                {
                    message = "Successfully Updated data",
                    Project = new ProjectsDTO
                    {
                        Id = proj.ProjID,
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
            }).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" }).DisableAntiforgery();

            
            app.MapGet("SearchProjects", async (IProjectService projService, string? query, int pageNumber = 1, int pageSize = 10) =>
            {
                if (pageNumber <= 0) pageNumber = 1;
                if (pageSize <= 0) pageSize = 10;

                // Fetch all projects
                var projects = await projService.GetallProjAsync();

                // Apply filter based on the query parameter
                var filteredProjects = projects.Where(proj =>
                    (string.IsNullOrEmpty(query) || proj.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                     proj.DepartmentNav.DeptName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                     proj.ClientNavigation.ClientName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                     proj.ManagerNavigation.FirstName.Contains(query, StringComparison.OrdinalIgnoreCase)
                     /*proj.StatusNav.StatusName.Contains(query, StringComparison.OrdinalIgnoreCase)*/)
                );

                var count = filteredProjects.Count();
                // Transform to DTOs
                var result = filteredProjects.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(proj => new ProjectsDTO
                {
                    Id = proj.ProjID,
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
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                    Projects = result
                });
            });

            app.MapPut("CompleteProject", async (IProjectService service, int id) =>
            {
                await service.CompleteProjectAsync(id);
                return Results.Ok("The Project status has change to Completed");
            });

            app.MapDelete("DeleteProject", async (IProjectService service, int id) =>
            {
                await service.DeleteProjAsync(id);
                return Results.Ok("The Data has been Deleted");
            }).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });

            app.MapPut("ChangeStatus", async (IProjectService service, ChangeStatusDto dto, int id) =>
            {
                await service.ChangeStatusAsync(dto, id);
                return Results.Ok("The Status Has CHanged");
            }).RequireAuthorization(new AuthorizeAttribute { Roles = "Admin" });
        }

    }
}
