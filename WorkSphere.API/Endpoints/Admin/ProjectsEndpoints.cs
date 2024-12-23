using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.DTOs;
using WorkSphere.Application.DTOs.ClientDTO;
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

            app.MapGet("GetAllProject", async (IProjectService projservice) =>
            {
                var proj = await projservice.GetallProjAsync();
                return proj.Select(proj => new ProjectsDTO()
                {
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
                });
            });

            app.MapPost("AddProject", async (IProjectService projService, ProjectsDTO projDto) =>
            {
                await projService.AddProjectAsync(projDto);
                var proj = new ProjectsDTO()
                {
                    Title = projDto.Title,
                    ProjDescr = projDto.ProjDescr,
                    TeamSize = projDto.TeamSize,
                    StartDate = projDto.StartDate,
                    Department = projDto.Department,
                    Client = projDto.Client,
                    Manager = projDto.Manager,
                    Deadline = projDto.Deadline,
                    ImagePath = projDto.ImagePath,
                    Status = projDto.Status,

                };
                return Results.Ok(proj);
            });

            app.MapGet("Project/{id}", async (IProjectService projService, int id) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if(proj != null)
                {
                    var viewproj = new ProjectsDTO()
                    {
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
                    };
                    return Results.Ok(viewproj);

                }
                return Results.Empty;
            });

            app.MapPut("UpdateProject/{id}", async (IProjectService projService, int id, ProjectsDTO projDto) =>
            {
                var proj = await projService.GetProjByIdAsync(id);
                if (proj == null) return Results.NotFound();

                proj.Title = projDto.Title;
                proj.ProjDescr = projDto.ProjDescr;
                proj.TeamSize = projDto.TeamSize;
                proj.StartDate = projDto.StartDate;
                proj.Department = projDto.Department;
                proj.Client = projDto.Client;
                proj.Manager = projDto.Manager;
                proj.Deadline = projDto.Deadline;
                proj.ImagePath = projDto.ImagePath;
                proj.Status = projDto.Status;

                await projService.UpdateProjAsync(proj);
                return Results.Ok(proj);
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
                });

                return Results.Ok(result);
            });

            app.MapGet("SearchClient", async (WorkSphereDbContext context, string? Name) =>
            {
                var client = await context.Clients.Where(e => e.IsActive == true).ToListAsync();

                var selectedclients = client.Where(c => (string.IsNullOrEmpty(Name) || c.ClientName.Contains(Name, StringComparison.OrdinalIgnoreCase)));

                var rslt = selectedclients.Select(c => new ClientDTO() { Name = c.ClientName });

                return Results.Ok(rslt);    
            });
            //app.MapPost()
        }

    }
}
