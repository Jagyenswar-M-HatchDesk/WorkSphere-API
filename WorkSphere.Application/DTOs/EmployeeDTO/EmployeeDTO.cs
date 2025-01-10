using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.EmployeeDTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string ?DepartmentName { get; set; }
        public string? Email { get; set; }
        public string ?MobileNo  {get; set;}
        public int RoleId { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentNav { get; set; }
        public bool ?IsActive { get; set; }
        public bool? IsDeleted { get; set;}
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
    

    }
}
