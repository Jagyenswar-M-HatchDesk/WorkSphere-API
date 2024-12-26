using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.UserDTO
{
    public class UserDTO
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int UserID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        //[Required]
        //public string Password { get; set; } = string.Empty;

        //public int? Contact { get; set; }

        public string Email { get; set; } = string.Empty ;

        public int? Department { get; set; }

        public DateTime DateOfJoining { get; set; }

        public int Rollid { get; set; }

        public DateTime? LastLogin { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        //public virtual Department? DepartmentNavigation { get; set; }
        public List<string> Roles { get; set; }
    }

}

