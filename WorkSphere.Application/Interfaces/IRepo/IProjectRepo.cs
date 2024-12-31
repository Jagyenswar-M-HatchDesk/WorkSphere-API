using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IRepo
{
    public interface IProjectRepo
    {
        Task<IEnumerable<Projects>> GetallProjects();

        Task<Projects> GetProjectById(int i);

        Task<Projects> AddProjects(ProjectCreateDTO project);

        Task<Projects> UpdateProjects(Projects proj);

        Task CompleteProject(int id);
        Task DeleteProject(int id);

        Task ChangeStatus(ChangeStatusDto dto, int id);
    }
}
