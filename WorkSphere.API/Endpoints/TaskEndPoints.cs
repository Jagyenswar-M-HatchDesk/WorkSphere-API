﻿using System.Runtime.CompilerServices;
using WorkSphere.Application.DTOs;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Application.Interfaces.IServices;

namespace WorkSphere.API.Endpoints
{
    public static class TaskEndPoints
    {
        public static void Task_EndPoints(this IEndpointRouteBuilder erb)
        {
            var app = erb.MapGroup("").WithTags("Task");

            app.MapGet("AllTask", async (ITaskService taskService, int pageNumber = 1, int pageSize = 10) =>
            {
                if(pageNumber <=0 ) pageNumber = 1;
                if(pageSize <= 0 ) pageSize = 10;

                var task = await taskService.GetTasksAsync();

                var count = task.Count();

                var totaltasks = task.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(task => new TaskDTO()
                {
                    TaskID = task.TaskID,
                    TaskTitle = task.TaskTitle,
                    TaskDescr = task.TaskDescr,
                    AssignedTo = task.AssignedTo,
                    Project = task.ProjID,
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
                        Project = task.ProjID,
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
            app.MapPost("AddTask", async (ITaskService taskService, TaskCreateDTO dto) =>
            {
                await taskService.AddTaskAsync(dto);
                var task = new TaskDTO()
                {
                    TaskTitle = dto.TaskTitle,
                    TaskDescr = dto.TaskDescr,
                    AssignedTo = dto.AssignedTo,
                    Project = dto.Project,
                    Progress = dto.Progress,
                    Status = dto.Status,
                    IsActive = true,
                    IsCompleted = false,
                    CreatedOn = DateTime.Now,
                    CreatedBy = dto.CreatedBy,
                    ModifiedOn = DateTime.Now

                };
                return Results.Ok(task);
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
