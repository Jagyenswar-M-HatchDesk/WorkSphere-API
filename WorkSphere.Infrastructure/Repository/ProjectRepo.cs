using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Domain;
using WorkSphere.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using WorkSphere.Application.Interfaces.IRepo;

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

        public async Task AddProjects(ProjectsDTO project)
        {
            var newproj = new Projects()
            {
                Title = project.Title,
                ProjDescr = project.ProjDescr,
                Client = project.Client,
                Manager = project.Manager,
                CreatedBy = project.CreatedBy,
                Department = project.Department,
                TeamSize = project.TeamSize,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false,

                
                StartDate = project.StartDate,
                Deadline = project.Deadline,
                ImagePath = project.ImagePath,
                Status = project.Status

            };
            _workSphereDbContext.Projects.Add(newproj);
            await _workSphereDbContext.SaveChangesAsync();
        }

        public async Task UpdateProjects(Projects proj)
        {
            _workSphereDbContext.Projects.Update(proj);
            await _workSphereDbContext.SaveChangesAsync();
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
