using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [ForeignKey("Client")]
        public int Client { get; set; } 

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Required]
        [ForeignKey("User")]
        public int Manager { get; set; } 

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public string? ImagePath { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int Department {  get; set; }

        public int TeamSize { get; set; }
        public DateTime? Deadline { get; set; }

        //[Required]
        [ForeignKey("Status")]
        public int? Status { get; set; }

        [Required]
        [ForeignKey("SeverityLevel")]
        public int SeverityLevel { get; set; }


        //public virtual Client? ClientNavigation { get; set; }
        //public virtual User? ManagerNavigation { get; set; }
    }

}
