using System.Runtime.CompilerServices;
using WorkSphere.Application.DTOs;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Application.Interfaces.IServices;
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
                    ProjID = task.ProjID,
                    Progress = task.Progress,
                    Status = task.StatusId,
                    IsActive = task.IsActive,
                    IsCompleted = task.IsCompleted,
                    CreatedOn = task.CreatedOn,
                    CreatedBy = task.CreatedBy,
                    ModifiedOn = task.ModifiedOn

                });

                return Results.Ok(new
                {
                    Totalcount = count,
                    Page = pageNumber,
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
                        ProjID = task.ProjID,
                        Progress = task.Progress,
                        Status = task.StatusId,
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
           

            app.MapPost("AddTask/{projectId}", async (int projectId, ITaskService taskService, TaskCreateDTO dto) =>
            {
                // Project ID ko DTO mein set karo
                dto.ProjID = projectId;

                // Add task asynchronously using taskService
                var taskDTO = await taskService.AddTaskAsync(dto);

                return Results.Ok(taskDTO);
            });



            app.MapPut("UpdateTask/{id}", async (ITaskService taskService, int id, TaskCreateDTO projDto) =>
            {
                var task = await taskService.GetTaskByIdSaync(id);
                if (task == null) return Results.NotFound();

                task.TaskTitle = projDto.TaskTitle;
                task.TaskDescr = projDto.TaskDescr;
                task.AssignedTo = projDto.AssignedTo;
                task.Progress = projDto.Progress;
                task.StatusId = projDto.Status;
                //task.Client = projDto.Client;
                //task.Manager = projDto.Manager;
                //task.Deadline = projDto.Deadline;
                //task.ImagePath = projDto.ImagePath;
                //task.Status = projDto.Status;

                await taskService.UpdateTaskasync(task);
                return Results.Ok(task);
            });
        }
    }
}
