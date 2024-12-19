using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Domain
{
    public class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string StatusName { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int? CreatedBy { get; set; }
    }
}
