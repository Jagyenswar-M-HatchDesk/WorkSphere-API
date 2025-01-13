using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere.Application.DTOs.TaskDTO
{
    public class TaskEditDTO : TaskCreateDTO
    {
        public int TaskID { get; set; }
    }
}
