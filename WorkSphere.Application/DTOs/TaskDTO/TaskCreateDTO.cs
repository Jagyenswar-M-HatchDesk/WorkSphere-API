using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.TaskDTO
{
    public class TaskCreateDTO
    {
        //public int TaskID { get; set; }


        public string TaskTitle { get; set; } = string.Empty;


        //public DateTime CreatedOn { get; set; }

        //public DateTime? ModifiedOn { get; set; }


        //public bool IsActive { get; set; }


        //public bool IsCompleted { get; set; }


        public int AssignedTo { get; set; }

        public string? TaskDescr { get; set; }


        public int ProjID { get; set; }

        public int? CreatedBy { get; set; }



        public int Status { get; set; }

        public int? Progress { get; set; }
    }
}
