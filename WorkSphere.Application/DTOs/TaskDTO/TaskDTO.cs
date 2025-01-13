namespace WorkSphere.Application.DTOs.TaskDTO
{
    public class TaskDTO
    {
       
            
            public int TaskID { get; set; }

            
            public string TaskTitle { get; set; } = string.Empty;

           
            public DateTime CreatedOn { get; set; }

            public DateTime? ModifiedOn { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public bool IsActive { get; set; }

            
            public bool IsCompleted { get; set; }

            
            public int AssignedTo { get; set; }

            public string? TaskDescr { get; set; }

            
            public int ProjID { get; set; }

            public int? CreatedBy { get; set; }

        public string? ImagePath { get; set; }
        public int ?SeverityLevel { get; set; }

        public int? Status { get; set; }

            public int? Progress { get; set; }
            //public virtual User? UserNavigation { get; set; }
            //public virtual Projects? ProjectNavigation { get; set; }
    }

}



