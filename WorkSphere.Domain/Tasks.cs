using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [ForeignKey("User")]
        public int AssignedTo { get; set; } 

        public string? TaskDescr { get; set; }

        [Required]
        [ForeignKey("Project")]
        public int Project { get; set; } 

        public int? CreatedBy { get; set; }


        [Required]
        [ForeignKey("Status")]
        public int Status { get; set; }

        public int? Progress { get; set; }
        //public virtual User? UserNavigation { get; set; }
        //public virtual Projects? ProjectNavigation { get; set; }
    }

}
