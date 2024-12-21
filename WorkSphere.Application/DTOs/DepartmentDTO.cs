using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs
{
    public class DepartmentDTO
    {
       
        //public int Id { get; set; }

        public string DeptName { get; set; } = string.Empty;

        //public bool IsActive { get; set; }

        //public bool IsDelete { get; set; }

        //public DateTime CreatedOn { get; set; }

        //public int? CreatedBy { get; set; }
    
    }
}
