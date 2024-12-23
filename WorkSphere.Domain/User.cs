using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


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
        [ForeignKey("Department")]
        public int? Department { get; set; } 

        [Required]
        public DateTime DateOfJoining { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int Rollid { get; set; } 

        public DateTime? LastLogin { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        //public virtual Department? DepartmentNavigation { get; set; }
        //public virtual Roles? RoleNavigation { get; set; }
    }

}
