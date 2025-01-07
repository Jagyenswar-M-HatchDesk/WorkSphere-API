using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.RegisterDTO
{
    public class UserShowDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        //public string Password { get; set; } = string.Empty;

        public string? Phone { get; set; }

        
        public string Email { get; set; } = string.Empty ;

        //[Required]

        public int? DeptId { get; set; }

        public string? DeptName { get; set; }
        public DateTime DateOfJoining { get; set; }

        public string? RoleName { get; set; }

        public int Rollid { get; set; }

        public DateTime? LastLogin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Country { get; set; }
        public string? ProfileImgPath { get; set; }
    }
}
