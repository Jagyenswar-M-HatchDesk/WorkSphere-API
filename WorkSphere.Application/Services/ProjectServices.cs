using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.Interfaces.IServices;
using WorkSphere.Domain;

namespace WorkSphere.Application.Services
{
    public class ProjectServices : IProjectService
    {
        private readonly IProjectRepo _repo;
        public ProjectServices(IProjectRepo repo) 
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Projects>> GetallProjAsync()
        {
            return await _repo.GetallProjects();
        }

        public async Task<Projects> GetProjByIdAsync(int id)
        {
            return await _repo.GetProjectById(id);

        }

        public async Task<Projects> UpdateProjAsync(Projects proj)
        {
             return await _repo.UpdateProjects(proj);
        }

        public async Task<Projects> AddProjectAsync(ProjectCreateDTO proj)
        {
            return await _repo.AddProjects(proj);
        }

        public async Task CompleteProjectAsync(int id)
        {
            await _repo.CompleteProject(id);
        }
    }
}
