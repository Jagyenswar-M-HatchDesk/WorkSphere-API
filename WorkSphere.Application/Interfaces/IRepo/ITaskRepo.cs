﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IRepo
{
    public interface ITaskRepo
    {
        Task<IEnumerable<Tasks>> GetTasks();
        Task<Tasks> GetTaskbyId(int id);
        Task AddTask(TaskCreateDTO task);
        Task EditTask(Tasks task);
        Task CompleteTask(int id);
    }
}
