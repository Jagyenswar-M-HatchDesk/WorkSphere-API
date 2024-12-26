using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Domain
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int DeptId { get; set; }

        [Required]
        public string DeptName { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }
        public virtual ICollection<User>? Users { get; set; }

        public virtual ICollection<Projects>? Projects { get; set; }

        //public ICollection<User> Users { get; set; }
    }

}
