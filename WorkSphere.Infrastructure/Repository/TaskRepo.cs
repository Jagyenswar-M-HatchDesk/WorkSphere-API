using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Domain;

namespace WorkSphere.Infrastructure.Repository
{
    public class TaskRepo : ITaskRepo
    {
        private readonly WorkSphereDbContext _context;

        public TaskRepo(WorkSphereDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Tasks>> GetTasks(int projectId)
        {
            return await _context.tbl_Tasks
           .Where(task => task.ProjID == projectId)
            .ToListAsync();
        }

        public async Task<Tasks> GetTaskbyId(int id)
        {
            var task = await _context.tbl_Tasks.FirstOrDefaultAsync(e=>e.TaskID == id);
            return task;
        }

        public async Task<TaskDTO> AddTask(TaskCreateDTO task)
        {
            var newtask = new Tasks()
            {
                TaskTitle = task.TaskTitle,
                TaskDescr = task.TaskDescr,
                AssignedTo = task.AssignedTo,
                CreatedBy = task.CreatedBy,
                ProjID = task.ProjID,
                StatusId = task.Status,
                Progress = task.Progress,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false
            };
            _context.tbl_Tasks.Add(newtask);
            await _context.SaveChangesAsync();

            return new TaskDTO()
            {
                TaskTitle = newtask.TaskTitle,
                TaskDescr = newtask.TaskDescr,
                AssignedTo = newtask.AssignedTo,
                CreatedBy = newtask.CreatedBy,
                Status = newtask.StatusId,
               ProjID  =  newtask.ProjID,
                Progress = newtask.Progress,
                CreatedOn = newtask.CreatedOn,
                ModifiedOn = newtask.ModifiedOn,
                IsActive = true,
                IsCompleted = false
            };
        }

        public async Task EditTask(Tasks task)
        {
             _context.tbl_Tasks.Update(task);
            await _context.SaveChangesAsync();

        }

        public async Task CompleteTask(int id)
        {
            var deltask = await GetTaskbyId(id);
            if (deltask != null)
            {
                deltask.IsActive = true;
                deltask.IsCompleted = true;
                deltask.StatusId = 6;
            }

            _context.tbl_Tasks.Update(deltask); 
            await _context.SaveChangesAsync();

        }
    }
}
