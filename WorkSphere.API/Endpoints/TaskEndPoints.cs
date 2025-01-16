using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using WorkSphere.Application.DTOs;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Application.Services;
using WorkSphere.Domain;

namespace WorkSphere.API.Endpoints
{
    public static class TaskEndPoints
    {
        public static void Task_EndPoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Task");

            app.MapGet("GetAllTask/{ProjectId}", async (int projectId , ITaskService taskService, int pageNumber = 1, int pageSize = 10) =>
            {
                if(pageNumber <=0 ) pageNumber = 1;
                if(pageSize <= 0 ) pageSize = 10;

                var task = await taskService.GetTasksAsync(projectId);

                var count = task.Count();

                var totaltasks = task.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(task => new TaskDTO()
                {
                    TaskID = task.TaskID,
                    TaskTitle = task.TaskTitle,
                    TaskDescr = task.TaskDescr,
                    AssignedTo = task.AssignedTo,
                    StatusName = task.StatusNav?.StatusName ?? "Null",
                    SeverityLevelName = task.SeverityLevelNav?.level ?? "Null",
                    EmployeeName = task.AssignedEmployee != null ? $"{task.AssignedEmployee.FirstName} {task.AssignedEmployee.LastName}": "Null",
                    SeverityLevel = task.SeverityLevelId,
                    ProjID = task.Id,
                    Progress = task.Progress,
                    Status = task.StatusId,
                    IsActive = task.IsActive,
                    IsCompleted = task.IsCompleted,
                    StartDate = task.StartDate,
                    EndDate  = task.EndDate ,
                    CreatedOn = task.CreatedOn,
                    CreatedBy = task.CreatedBy,
                    ModifiedOn = task.ModifiedOn

                });

                return Results.Ok(new
                {
                    Total = count,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(count / (double)pageSize),
                    Totaltasks = totaltasks

                });

            });

            app.MapGet("Task/{id}", async (ITaskService taskService, int id) =>
            {
                var task = await taskService.GetTaskByIdSaync(id);
                if (task != null)
                {
                    var taskshow = new TaskDTO()
                    {
                        TaskID = task.TaskID,
                        TaskTitle = task.TaskTitle,
                        TaskDescr = task.TaskDescr,
                        AssignedTo = task.AssignedTo,
                        StartDate = task.StartDate,
                        EndDate = task.EndDate,
                        SeverityLevel =  task.SeverityLevel,
                        ImagePath = task.ImagePath,
                        ProjID = task.ProjID,
                        Progress = task.Progress,
                        Status = task.Status,
                        IsActive = task.IsActive,
                        IsCompleted = task.IsCompleted,
                        CreatedOn = task.CreatedOn,
                        CreatedBy = task.CreatedBy,
                        ModifiedOn = task.ModifiedOn

                    };
                    return Results.Ok(taskshow);
                }
                return Results.Empty;
            });

            app.MapPost("AddTask/{projectId}", async ([FromForm] IFormFile ? imageFile , int projectId, ITaskService taskService, IProjectService projService , [FromForm] TaskCreateDTO dto , IHostEnvironment environment) =>
            {

                var projectExists = await projService.GetProjByIdAsync(projectId);
                if (projectExists == null)
                {
                    return Results.BadRequest(new { message = $"Project with ID {projectId} does not exist." });
                }

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
                dto.ImagePath = imagePath;
                // Project ID ko DTO mein set karo
                dto.ProjID = projectId;

                // Add task asynchronously using taskService
                var taskDTO = await taskService.AddTaskAsync(dto);

                return Results.Ok(taskDTO);
            }).DisableAntiforgery(); 

            app.MapPut("UpdateTask/{id}", async (ITaskService taskService, [FromRoute]int id, [FromForm] IFormFile? imageFile, [FromForm] TaskEditDTO dto , IHostEnvironment environment) =>
            {
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

                dto.ImagePath = imagePath;


                var task = await taskService.GetTaskByIdSaync(id);
                if (task == null) return Results.NotFound();

              
                task.TaskTitle = dto.TaskTitle;
                task.TaskDescr = dto.TaskDescr;
                task.AssignedTo = dto.AssignedTo;
                task.Progress = dto.Progress;
                task.StartDate = dto.StartDate;
                task.EndDate = dto.EndDate;
                task.Status = dto.Status;
                task.ImagePath= dto.ImagePath;
                task.SeverityLevel = dto.SeverityLevel;
              

                await taskService.UpdateTaskasync(task);
                return Results.Ok(task);
            }).DisableAntiforgery();


            app.MapDelete("Task/{id}", async (ITaskService taskService, int id) =>
            {
                var task = await taskService.DeleteTaskAsync(id);
                if (task)
                {
                    return Results.Ok(new
                    {
                        message = "Task has been deleted successfully",
                        Task = task
                    });

                }
                return Results.Empty;
            });
        }

 
    }
}
