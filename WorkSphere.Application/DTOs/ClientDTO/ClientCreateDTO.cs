using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.ClientDTO
{
    public class ClientCreateDTO
    {
        public string ClientName { get; set; } = string.Empty;

        public int? Contact { get; set; }

        
        public string Email { get; set; } = string.Empty;

    }
}
