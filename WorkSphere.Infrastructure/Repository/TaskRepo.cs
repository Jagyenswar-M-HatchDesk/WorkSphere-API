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
           .Where(task => task.Id == projectId)
            .ToListAsync();
        }

        public async Task<TaskEditDTO> GetTaskbyId(int id)
        {
            var task = await _context.tbl_Tasks.FirstOrDefaultAsync(e=>e.TaskID == id);
            return new TaskEditDTO
            {
                TaskTitle = task.TaskTitle,
                TaskDescr = task.TaskDescr,
                AssignedTo = task.AssignedTo,
                SeverityLevel = task.SeverityLevelId,
                CreatedBy = task.CreatedBy,
                ImagePath = task.ImagePath,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                ProjID = task.Id,
                Status = task.StatusId,
                Progress = task.Progress,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false


            };
        }

        public async Task<TaskDTO> AddTask(TaskCreateDTO task)
        {
            var newtask = new Tasks()
            {
                TaskTitle = task.TaskTitle,
                TaskDescr = task.TaskDescr,
                AssignedTo = task.AssignedTo,
                SeverityLevelId = task.SeverityLevel,
                CreatedBy = task.CreatedBy,
                ImagePath = task.ImagePath,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Id = task.ProjID,
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
                SeverityLevel = newtask.SeverityLevelId,
                CreatedBy = newtask.CreatedBy,
                ImagePath = newtask.ImagePath,
                StartDate = newtask.StartDate,
                EndDate = newtask.EndDate,
                Status = newtask.StatusId,
               ProjID  =  newtask.Id,
                Progress = newtask.Progress,
                CreatedOn = newtask.CreatedOn,
                ModifiedOn = newtask.ModifiedOn,
                IsActive = true,
                IsCompleted = false
            };
        }

        public async Task<TaskDTO> EditTask(TaskEditDTO task)
        {
            var tasks = await _context.tbl_Tasks.FindAsync(task.TaskID);
            if (tasks != null)
            {

                tasks.TaskTitle = task.TaskTitle;
                tasks.TaskDescr = task.TaskDescr;
                tasks.AssignedTo = task.AssignedTo;
                tasks.CreatedBy = task.CreatedBy;
                tasks.StartDate = task.StartDate;
                tasks.EndDate = task.EndDate;
                tasks.SeverityLevelId = task.SeverityLevel;
                tasks.StatusId = task.Status;
                tasks.ImagePath = task.ImagePath;
                tasks.IsActive = true;
                tasks.IsCompleted = true;

                _context.tbl_Tasks.Update(tasks);
                await _context.SaveChangesAsync();

                return new TaskDTO
                {
                     TaskTitle = task.TaskTitle,
                     TaskDescr = task.TaskDescr,
                     AssignedTo = task.AssignedTo,
                     CreatedBy = task.CreatedBy,
                     StartDate = task.StartDate,
                     EndDate = task.EndDate,
                     SeverityLevel = task.SeverityLevel,
                     Status = task.Status,
                     ImagePath = task.ImagePath,
                     IsActive = true,
                     IsCompleted = true,

            };
            }
            return new TaskDTO();

        }

        //public async Task CompleteTask(int id)
        //{
        //    var deltask = await GetTaskbyId(id);
        //    if (deltask != null)
        //    {
        //        deltask.IsActive = true;
        //        deltask.IsCompleted = true;
        //        deltask.StatusId = 6;
        //    }

        //    _context.tbl_Tasks.Update(deltask); 
        //    await _context.SaveChangesAsync();

        //}
    }
}
