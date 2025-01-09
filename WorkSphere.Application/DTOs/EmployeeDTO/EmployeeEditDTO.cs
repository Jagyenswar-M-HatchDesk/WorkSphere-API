using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.EmployeeDTO
{
    public class EmployeeEditDTO : EmployeeCreateDTO
    {
        public int empId { get; set; }
    }
}
