using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.ProjectDto
{
    public class ProjectsDTO
    {
        public int ProjID { get; set; }


        public string? Title { get; set; }

        public string? ProjDescr { get; set; }


        public int Client { get; set; }
        public string ClientName { get; set; }

        public DateTime? StartDate { get; set; }


        public bool IsActive { get; set; }


        public bool IsCompleted { get; set; }

        public int Manager { get; set; }
        public string ManagerName { get; set; }

        public DateTime? ModifiedOn { get; set; }


        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public string? ImagePath { get; set; }

        
        public int Department { get; set; }
        public string DepartmentName { get; set; }

        public int TeamSize { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Status { get; set; }
        public string? StatusName { get; set; }

        public int SeverityLevel { get; set; }
        public string SeverityLevelName { get; set; }
    }
}
