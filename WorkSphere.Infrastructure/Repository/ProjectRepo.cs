using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Domain;
using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.Interfaces.IRepo;
using WorkSphere.Application.DTOs.ProjectDto;

namespace WorkSphere.Infrastructure.Repository
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly WorkSphereDbContext _workSphereDbContext;

        public ProjectRepo(WorkSphereDbContext workSphereDbContext)
        {
            this._workSphereDbContext = workSphereDbContext;    
        }

        public async Task<IEnumerable<Projects>> GetallProjects()
        {
            var proj = await _workSphereDbContext.Projects.ToListAsync();
            return proj;
        }

        public async Task<Projects> GetProjectById(int i)
        {
            var projid = await _workSphereDbContext.Projects.FindAsync(i);
            return projid;
        }

        public async Task<Projects> AddProjects(ProjectCreateDTO project)
        {
            var newproj = new Projects()
            {
                Title = project.Title,
                ProjDescr = project.ProjDescr,
                Client = project.Client,
                Manager = project.Manager,
                CreatedBy = 1,
                Department = project.Department,
                TeamSize = project.TeamSize,
                StartDate = project.StartDate,
                Deadline = project.Deadline,
                ImagePath = project.ImagePath,
                Status = project.Status,
                SeverityLevel = project.SeverityLevel,

                CreatedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false,
                ModifiedOn = DateTime.Now

            };
            _workSphereDbContext.Projects.Add(newproj);
            await _workSphereDbContext.SaveChangesAsync();

            return newproj;
        }

        public async Task<Projects> UpdateProjects(Projects proj)
        {
            _workSphereDbContext.Projects.Update(proj);
            await _workSphereDbContext.SaveChangesAsync();

            return proj;
        }

        public async Task CompleteProject(int id)
        {
            var proj = await GetProjectById(id);
            if(proj != null)
            {
                proj.IsActive = false;
                proj.IsCompleted = true;
               
            }
            _workSphereDbContext.Projects.Update(proj);
            await _workSphereDbContext.SaveChangesAsync();
        }
    }
}
