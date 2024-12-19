using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.RegisterDTO
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Department { get; set; }
        public int Rollid { get; set; }
    }
}
