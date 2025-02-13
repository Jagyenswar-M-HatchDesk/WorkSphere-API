﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IServices
{
    public interface ITaskService
    {
        Task<IEnumerable<Tasks>> GetTasksAsync(int projectId);

        Task<TaskEditDTO> GetTaskByIdSaync(int id);

        Task<TaskDTO> UpdateTaskasync(TaskEditDTO task);

        Task <TaskDTO>AddTaskAsync(TaskCreateDTO task);

        Task<bool> DeleteTaskAsync(int id);

        Task<TaskEditDTO> ChangeStatusAsync(ChangeTaskStatusDto dto, int id);


        //Task completeTaskAsync(int id);
    }
}
