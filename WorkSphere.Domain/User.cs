using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace WorkSphere.Domain
{
    public class User : IdentityUser<int> 
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        //public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        //[Required]
        //public string Password { get; set; } = string.Empty;

        //public int? Contact { get; set; }

        //[Required]
        //public string Email { get; set; } = string.Empty ;

        //[Required]
        
        public int? DeptId { get; set; } 

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        
        public int Rollid { get; set; } 

        public DateTime? LastLogin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }
        [ForeignKey("DeptId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Department? DepartmentNavigation { get; set; }
        [ForeignKey("Rollid")]
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public virtual Roles? RoleNavigation { get; set; }
        public virtual ICollection<Tasks>? AssignedTasks { get; set; }
        public virtual ICollection<Projects>? Projects { get; set; }
        //public ICollection<Tasks> Tasks { get; set; }
    }

}
