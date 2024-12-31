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
            var proj = await _workSphereDbContext.tbl_Projects.Include(e => e.StatusNav)
                                .Include(e => e.SeverityLevelNav)
                                .Include(e => e.ManagerNavigation)
                                .Include(e => e.DepartmentNav)
                                .Include(e => e.ClientNavigation).ToListAsync();
            return proj;
        }

        public async Task<Projects> GetProjectById(int i)
        {
            var projid = await _workSphereDbContext.tbl_Projects.Include(e => e.StatusNav)
                                .Include(e => e.SeverityLevelNav)
                                .Include(e => e.ManagerNavigation)
                                .Include(e => e.DepartmentNav)
                                .Include(e => e.ClientNavigation)

                .Where(e => e.ProjID == i && e.IsActive == true).FirstOrDefaultAsync();
            return projid;
        }

        public async Task<Projects> AddProjects(ProjectCreateDTO project)
        {
            var newproj = new Projects()
            {
                Title = project.Title,
                ProjDescr = project.ProjDescr,
                ClientId = project.Client,
                ManagerID = project.Manager,
                CreatedBy = 1,
                DepartmentID = project.Department,
                TeamSize = project.TeamSize,
                StartDate = project.StartDate,
                Deadline = project.Deadline,
                ImagePath = project.ImagePath,
                //StatusId = project.Status,
                SeverityLevelId = project.SeverityLevel,

                CreatedOn = DateTime.Now,
                IsActive = true,
                IsCompleted = false,
                ModifiedOn = DateTime.Now

            };
            _workSphereDbContext.tbl_Projects.Add(newproj);
            await _workSphereDbContext.SaveChangesAsync();

            return newproj;
        }

        public async Task<Projects> UpdateProjects(Projects proj)
        {
            _workSphereDbContext.tbl_Projects.Update(proj);
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
               proj.StatusId = 6;
            }
            _workSphereDbContext.tbl_Projects.Update(proj);
            await _workSphereDbContext.SaveChangesAsync();
        }

        public async Task DeleteProject(int id)
        {
            var proj = await GetProjectById(id);
            _workSphereDbContext.tbl_Projects.Remove(proj);
            await _workSphereDbContext.SaveChangesAsync();
        }

        public async Task ChangeStatus(ChangeStatusDto dto, int id)
        {
            var project = await GetProjectById(id);

            project.StatusId = dto.Status;
            _workSphereDbContext.tbl_Projects.Update(project);
            await _workSphereDbContext.SaveChangesAsync();
        }
    }
}
//