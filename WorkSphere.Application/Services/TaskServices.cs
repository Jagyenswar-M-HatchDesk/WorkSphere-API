using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.TaskDTO;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;


namespace WorkSphere.Application.Services
{
    public class TaskServices : ITaskService
    {
        private readonly ITaskRepo _repo;

        public TaskServices(ITaskRepo repo)
        {
            this._repo = repo;
        }

        public async Task<IEnumerable<Tasks>> GetTasksAsync(int projectId)
        {
            return await _repo.GetTasks(projectId);
        }

        public async Task<TaskEditDTO> GetTaskByIdSaync(int id)
        {
            return await _repo.GetTaskbyId(id);
        }

        public async Task<TaskDTO> UpdateTaskasync(TaskEditDTO task)
        {
           return  await _repo.EditTask(task);
        }

        public async Task<TaskDTO> AddTaskAsync(TaskCreateDTO task)
        {
            return await _repo.AddTask(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _repo.DeleteTask(id);
        }

        //public async Task completeTaskAsync(int id)
        //{
        //    await _repo.CompleteTask(id);
        //}
    }
}
