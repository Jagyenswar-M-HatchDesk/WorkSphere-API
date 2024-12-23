using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.ClientDTO
{
    public class ClientShowDTO
    {
        public int ClientID { get; set; }

        
        public string ClientName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string Email { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int? CreatedBy { get; set; }
    }
}
