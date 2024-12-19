using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IServices
{
    public interface IProjectService
    {
        Task<IEnumerable<Projects>> GetallProjAsync();

        Task<Projects> GetProjByIdAsync(int id);

        Task UpdateProjAsync(Projects proj);

        Task AddProjectAsync(ProjectsDTO proj);

        Task CompleteProjectAsync(int id);
    }
}
