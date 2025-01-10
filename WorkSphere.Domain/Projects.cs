using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkSphere.Domain
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ProjID { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? ProjDescr { get; set; }

        [Required]
        public int ClientId { get; set; } 

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public int ManagerID { get; set; } 

        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }


        public string? ImagePath { get; set; }

        [Required]
        public int DepartmentID {  get; set; }

        public int TeamSize { get; set; }
        public DateTime? Deadline { get; set; }

        //[Required]
        public int? StatusId { get; set; }

        [Required]
        public int SeverityLevelId { get; set; }

        [ForeignKey("ClientId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual Client? ClientNavigation { get; set; }
        [ForeignKey("ManagerID")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual User? ManagerNavigation { get; set; }

        [ForeignKey("DepartmentID")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual Department? DepartmentNav { get; set; }
        [ForeignKey("StatusId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual Status? StatusNav { get; set; }
        [ForeignKey("SeverityLevelId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual SeverityLevel? SeverityLevelNav { get; set; }
        public virtual ICollection<Tasks>? Tasks { get; set; }

        public bool IsDeleted { get; set; }

        
    }

}
