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

        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            var task = await _context.Tasks.ToListAsync();
            return task;
        }

        public async Task<Tasks> GetTaskbyId(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(e=>e.TaskID == id);
            return task;
        }

        public async Task AddTask(TaskCreateDTO task)
        {
            var newtask = new Tasks()
            {
                TaskTitle = task.TaskTitle,
                TaskDescr = task.TaskDescr,
                AssignedTo = task.AssignedTo,
                CreatedBy = task.CreatedBy,
                Status = task.Status,
                Progress = task.Progress,
                Project = task.Project,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false
            };
            _context.Tasks.Add(newtask);
            await _context.SaveChangesAsync();
        }

        public async Task EditTask(Tasks task)
        {
             _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

        }

        public async Task CompleteTask(int id)
        {
            var deltask = await GetTaskbyId(id);
            if (deltask != null)
            {
                deltask.IsActive = true;
                deltask.IsCompleted = true;
                deltask.Status = 6;
            }

            _context.Tasks.Update(deltask); 
            await _context.SaveChangesAsync();

        }
    }
}
