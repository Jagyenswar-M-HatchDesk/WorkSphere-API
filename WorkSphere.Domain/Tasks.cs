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
    public class Tasks
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int TaskID { get; set; }

        [Required]
        public string TaskTitle { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        public int AssignedTo { get; set; }
        [ForeignKey("AssignedTo")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual User? AssignedEmployee { get; set; } 

        public string? TaskDescr { get; set; }

        [Required]
        public int Id { get; set; }
        [ForeignKey("ProjID")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual Projects? ProjectNav { get; set; } 

        public int? CreatedBy { get; set; }


        //[Required]
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        [DeleteBehavior(DeleteBehavior.Restrict)]

        public virtual Status? StatusNav { get; set; }

        public int? Progress { get; set; }
        //public virtual User? UserNavigation { get; set; }
        //public virtual Projects? ProjectNavigation { get; set; }
    }

}
