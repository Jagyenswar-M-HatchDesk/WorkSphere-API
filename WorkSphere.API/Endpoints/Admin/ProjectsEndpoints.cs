using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.DTOs.ClientDTO;
using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;
using WorkSphere.Infrastructure;

namespace WorkSphere.API.Endpoints.Admin
{
    public static class ProjectsEndpoints
    {
        

        public static void Projects_Endpoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Projects");

            app.MapGet("GetAllProject", async (IProjectService projservice, int pageNumber=1, int pageSize=10) =>
            {
                if(pageNumber <=0 ) pageNumber=1;
                if (pageSize <=0 ) pageSize=10;

                var proj = await projservice.GetallProjAsync();

                var count = proj.Count();

                var pageProduct = proj.Skip((pageNumber -1)*pageSize).Take(pageSize)
                 .Select(proj => new ProjectsDTO()
                {
                     ProjID = proj.ProjID,
                    Title = proj.Title,
                    ProjDescr = proj.ProjDescr,
                    TeamSize = proj.TeamSize,
                    StartDate = proj.StartDate,
                    Department = proj.Department,
                    Client = proj.Client,
                    Manager = proj.Manager,
                    Deadline = proj.Deadline,
                    ImagePath = proj.ImagePath,
                    Status = proj.Status,
                    SeverityLevel = proj.SeverityLevel,
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
                    TotalPages = (int)Math.Ceiling(count/(double)pageSize),
                    Projects = pageProduct
                });
            });

            app.MapPost("AddProject", async (IProjectService projService, ProjectCreateDTO projDto) =>
            {
                var addproject = await projService.AddProjectAsync(projDto);
                var proj = new ProjectsDTO()
                {
                    ProjID = addproject.ProjID,
                    Title = addproject.Title,
                    ProjDescr = addproject.ProjDescr,
                    TeamSize = addproject.TeamSize,
                    StartDate = addproject.StartDate,
                    Department = addproject.Department,
                    Client = addproject.Client,
                    Manager = addproject.Manager,
                    Deadline = addproject.Deadline,
                    ImagePath = addproject.ImagePath,
                    Status = addproject.Status,
                    SeverityLevel = addproject.SeverityLevel,
                    CreatedBy = addproject.CreatedBy,
                    CreatedOn = addproject.CreatedOn,
                    IsCompleted = addproject.IsCompleted,
                    IsActive = addproject.IsActive,
                    ModifiedOn = addproject.ModifiedOn

                };

                return Results.Ok(new
                {
                    message = "Successfully Created a new Project",
                    Project = proj
                });
            });

            app.MapGet("Project/{id}", async (IProjectService projService, int id) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if(proj != null)
                {
                    var viewproj = new ProjectsDTO()
                    {
                        ProjID = proj.ProjID,
                        Title = proj.Title,
                        ProjDescr = proj.ProjDescr,
                        TeamSize = proj.TeamSize,
                        StartDate = proj.StartDate,
                        Department = proj.Department,
                        Client = proj.Client,
                        Manager = proj.Manager,
                        Deadline = proj.Deadline,
                        ImagePath = proj.ImagePath,
                        Status = proj.Status,
                        SeverityLevel = proj.SeverityLevel,
                        CreatedBy = proj.CreatedBy,
                        CreatedOn = proj.CreatedOn,
                        IsCompleted = proj.IsCompleted,
                        IsActive = proj.IsActive,
                        ModifiedOn = proj.ModifiedOn
                    };
                    return Results.Ok(new 
                    {
                        message = "Successfully Updated the Project",
                        Project = viewproj
                    });

                }
                return Results.Empty;
            });

            app.MapPut("UpdateProject/{id}", async (IProjectService projService, int id, ProjectEditDTO projDto) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if (proj == null) return Results.NotFound();

                proj.Title = projDto.Title;
                proj.ProjDescr = projDto.ProjDescr;
                proj.TeamSize = projDto.TeamSize;
                proj.StartDate = projDto.StartDate;
                proj.Department = projDto.Department;
                //proj.Client = projDto.Client;
                proj.Manager = projDto.Manager;
                proj.Deadline = projDto.Deadline;
                proj.ImagePath = projDto.ImagePath;
                proj.Status = projDto.Status;
                proj.SeverityLevel = projDto.SeverityLevel;
                proj.ModifiedOn = DateTime.Now;

                await projService.UpdateProjAsync(proj);
                return Results.Ok(new
                {
                    message = "Successfully Updated data",
                    Project = proj
                });
            });
            app.MapGet("SearchProjects", async (IProjectService projService, string? title) =>
            {
                // Fetch all projects
                var projects = await projService.GetallProjAsync();

                // Apply filters if search criteria are provided
                var filteredProjects = projects.Where(proj =>
                    (string.IsNullOrEmpty(title) || proj.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                    //&&
                    //(string.IsNullOrEmpty(department) || proj..Contains(department, StringComparison.OrdinalIgnoreCase)) &&
                    //(string.IsNullOrEmpty(client) || proj.Client.Contains(client, StringComparison.OrdinalIgnoreCase)) &&
                    //(string.IsNullOrEmpty(status) || proj.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                );

                // Transform to DTOs
                var result = filteredProjects.Select(proj => new ProjectsDTO()
                {
                    ProjID = proj.ProjID,
                    Title = proj.Title,
                    ProjDescr = proj.ProjDescr,
                    TeamSize = proj.TeamSize,
                    StartDate = proj.StartDate,
                    Department = proj.Department,
                    Client = proj.Client,
                    Manager = proj.Manager,
                    Deadline = proj.Deadline,
                    ImagePath = proj.ImagePath,
                    Status = proj.Status,
                    SeverityLevel = proj.SeverityLevel
                });

                return Results.Ok(result);
            });

            
            //app.MapPost()
        }

    }
}
