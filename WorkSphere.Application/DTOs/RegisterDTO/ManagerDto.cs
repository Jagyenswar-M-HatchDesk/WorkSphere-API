using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkSphere.Domain;

namespace WorkSphere.Application.DTOs.RegisterDTO
{
    public class ManagerDto
    {
        public int Id { get; set; }
        public string FullName {  get; set; }
        public DateTime DateOfJoining { get; set; }
        public List<ProjectsName>? projects { get; set; }
    }

    public class ProjectsName
    {
        public string Title { get; set; } = string.Empty;
    }
}
