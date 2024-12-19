using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IRepo
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Projects>> GetallProjects();

        Task<Projects> GetProjectById(int i);

        Task AddProjects(ProjectsDTO project);

        Task UpdateProjects(Projects proj);

        Task CompleteProject(int id);
    }
}
