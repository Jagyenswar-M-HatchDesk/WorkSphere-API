using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Domain
{
    public class SeverityLevel
    {
        public int Id { get; set; }
        public string level { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Createdon {  get; set; }
        public DateTime Updatedon { get; set; }
        public int CreatedBy { get; set; }

    }
}
