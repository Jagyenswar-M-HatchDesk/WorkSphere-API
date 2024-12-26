using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WorkSphere.Domain
{
    public class Roles : IdentityRole<int>
    {
        //[Key] // Primary Key
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto Increment
        //public int Id { get; set; }

        //[Required]
        //public string RoleName { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }

}
