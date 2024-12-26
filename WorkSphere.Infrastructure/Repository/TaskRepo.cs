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
            var task = await _context.tbl_Tasks.ToListAsync();
            return task;
        }

        public async Task<Tasks> GetTaskbyId(int id)
        {
            var task = await _context.tbl_Tasks.FirstOrDefaultAsync(e=>e.TaskID == id);
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
                StatusId = task.Status,
                Progress = task.Progress,
                ProjID = task.Project,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false
            };
            _context.tbl_Tasks.Add(newtask);
            await _context.SaveChangesAsync();
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
