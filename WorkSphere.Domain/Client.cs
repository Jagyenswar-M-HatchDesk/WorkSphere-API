using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Domain
{
    public class Client
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ClientID { get; set; }

        [Required]
        public string ClientName { get; set; } = string.Empty;

        public int? Contact { get; set; }

        [Required]
        public string Email { get; set; } = string.Empty ;

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        public int? CreatedBy { get; set; }
    }

}
