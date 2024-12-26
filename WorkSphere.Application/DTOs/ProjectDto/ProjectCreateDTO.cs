using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.ProjectDto
{
    public class ProjectCreateDTO
    {


        public string? Title { get; set; }

        public string? ProjDescr { get; set; }


        public int Client { get; set; }

        public DateTime? StartDate { get; set; }

        public int Manager { get; set; }

        public string? ImagePath { get; set; }
        //public IFormFile? ImageFile { get; set; }


        public int Department { get; set; }

        public int TeamSize { get; set; }
        public DateTime? Deadline { get; set; }
        public int? Status { get; set; }

        public int SeverityLevel { get; set; }
    }
}
