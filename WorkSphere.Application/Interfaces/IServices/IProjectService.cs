using WorkSphere.Application.DTOs.ProjectDto;
using WorkSphere.Domain;

namespace WorkSphere.Application.Interfaces.IServices
{
    public interface IProjectService
    {
        Task<IEnumerable<Projects>> GetallProjAsync();

        Task<Projects> GetProjByIdAsync(int id);

        Task<Projects> UpdateProjAsync(Projects proj);

        Task<Projects> AddProjectAsync(ProjectCreateDTO proj);

        Task CompleteProjectAsync(int id);
    }
}
