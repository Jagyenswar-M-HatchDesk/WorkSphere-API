
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data;
using WorkSphere.Domain;

namespace WorkSphere.Infrastructure
{
    public class WorkSphereDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public WorkSphereDbContext(DbContextOptions<WorkSphereDbContext> options) : base(options)
        {
        }

        public DbSet<Department> mst_Departments { get; set; }
        public DbSet<Roles> mst_Roles { get; set; }
        public DbSet<Tasks> tbl_Tasks { get; set; }
        public DbSet<Projects> tbl_Projects { get; set; }
        public DbSet<Client> tbl_Clients { get; set; }
        public DbSet<Status> mst_Status { get; set; }
        public DbSet<SeverityLevel> mst_SeverityLevel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
     .HasOne(u => u.DepartmentNavigation) // User ka ek Department hoga
     .WithMany(d => d.Users)    // Department ke multiple Users ho sakte hain
     .HasForeignKey(u => u.DeptId) // Foreign key DeptId hai
     .OnDelete(DeleteBehavior.Restrict);

        

            // Required for Identity tables

            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 1, Name = "Admin", NormalizedName = "Admin".ToUpper(), IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 2, Name = "Manager", NormalizedName = "Manager".ToUpper(), IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 3, Name = "Employee", NormalizedName = "Employee".ToUpper(), IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });

            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 1, DeptName = "None", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 2, DeptName = "Desktop App Development", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 3, DeptName = "Mobile Development", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 4, DeptName = "UI/UX Design", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { DeptId = 5, DeptName = "API Development", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });

            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 1, StatusName = "Accepted", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 2, StatusName = "In Progress", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 3, StatusName = "Pending", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 4, StatusName = "Delayed", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 5, StatusName = "At Risk", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 6, StatusName = "Completed", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { StatusId = 7, StatusName = "Rejected", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });

            modelBuilder.Entity<SeverityLevel>().HasData(new SeverityLevel { Id = 1, level = "High", CreatedBy = 1, IsActive = true, IsDeleted = false, Createdon = DateTime.Now, Updatedon= DateTime.Now });
            modelBuilder.Entity<SeverityLevel>().HasData(new SeverityLevel { Id = 2, level = "Medium", CreatedBy = 1, IsActive = true, IsDeleted = false, Createdon = DateTime.Now, Updatedon= DateTime.Now });
            modelBuilder.Entity<SeverityLevel>().HasData(new SeverityLevel { Id = 3, level = "Low", CreatedBy = 1, IsActive = true, IsDeleted = false, Createdon = DateTime.Now, Updatedon= DateTime.Now });


            //modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "Admin", LastName = "Admin",UserName = "admin@gmail.com",PasswordHash = "Admin@123", Email="admin@gmail.com", Rollid= 1, Department=1, DateOfJoining=DateTime.Now , ModifiedOn=DateTime.Now, PhoneNumber="7723099993" ,CreatedBy = 1, IsActive = true, IsDeleted = false });
            //modelBuilder.Entity<User>().HasData(new User { Id = 2, FirstName = "Tapan", LastName = "Meher",UserName = "tapanmeher@gmail.com",PasswordHash = "Tapan@123", Email="tapanmeher@gmail.com", Rollid= 2, Department=3, DateOfJoining=DateTime.Now , ModifiedOn=DateTime.Now, PhoneNumber="7723099993" ,CreatedBy = 1, IsActive = true, IsDeleted = false });
            //modelBuilder.Entity<User>().HasData(new User { Id = 3, FirstName = "Sakshi", LastName = "Yadav",UserName = "sakshiyadav@gmail.com",PasswordHash = "Tapan@123", Email="sakshiyadav@gmail.com", Rollid= 3, Department=3, DateOfJoining=DateTime.Now , ModifiedOn=DateTime.Now, PhoneNumber="2783682993" ,CreatedBy = 1, IsActive = true, IsDeleted = false });
            var passwordHasher = new PasswordHasher<User>();

            var adminUser = new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Rollid = 1,
                DeptId = 1,
                DateOfJoining = DateTime.Now,
                ModifiedOn = DateTime.Now,
                PhoneNumber = "7723099993",
                CreatedBy = 1,
                IsActive = true,
                IsDeleted = false
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");

            var managerUser = new User
            {
                Id = 2,
                FirstName = "Tapan",
                LastName = "Meher",
                UserName = "tapanmeher@gmail.com",
                Email = "tapanmeher@gmail.com",
                Rollid = 2,
                DeptId = 3,
                DateOfJoining = DateTime.Now,
                ModifiedOn = DateTime.Now,
                PhoneNumber = "7723099993",
                CreatedBy = 1,
                IsActive = true,
                IsDeleted = false
            };
            managerUser.PasswordHash = passwordHasher.HashPassword(managerUser, "Tapan@123");

            var employeeUser = new User
            {
                Id = 3,
                FirstName = "Sakshi",
                LastName = "Yadav",
                UserName = "sakshiyadav@gmail.com",
                Email = "sakshiyadav@gmail.com",
                Rollid = 3,
                DeptId = 3,
                DateOfJoining = DateTime.Now,
                ModifiedOn = DateTime.Now,
                PhoneNumber = "2783682993",
                CreatedBy = 1,
                IsActive = true,
                IsDeleted = false
            };
            employeeUser.PasswordHash = passwordHasher.HashPassword(employeeUser, "Sakshi@123");

            modelBuilder.Entity<User>().HasData(adminUser, managerUser, employeeUser);


            modelBuilder.Entity<Client>().HasData(new Client { ClientID = 1, ClientName = "Hatchdesk", CreatedOn = DateTime.Now, Email = "hatchdesk18@gmail.com", ModifiedOn = DateTime.Now, PhoneNumber = "7723099993", CreatedBy = 1, IsActive = true, IsDelete = false });
            modelBuilder.Entity<Client>().HasData(new Client { ClientID = 2, ClientName = "Congent", CreatedOn = DateTime.Now, Email = "cogent@gmail.com", ModifiedOn = DateTime.Now, PhoneNumber = "374t4328234", CreatedBy = 1, IsActive = true, IsDelete = false });


            modelBuilder.Entity<Projects>().HasData(new Projects { ProjID = 1, ProjDescr = "Project For test", Title = "Test Project", ClientId = 1, CreatedOn = DateTime.Now, Deadline = null, DepartmentID= 1, ImagePath="string.jpeg",  CreatedBy=1, IsActive= true, IsCompleted=false, ManagerID=2, ModifiedOn=DateTime.Now, SeverityLevelId = 2, StartDate= DateTime.Now, TeamSize = 3, StatusId =null});
            
            modelBuilder.Entity<Tasks>().HasData(new Tasks { TaskID = 1, TaskDescr = "Task For test", TaskTitle = "Test TAsk", AssignedTo = 3, CreatedOn = DateTime.Now, Progress= 25, ProjID= 1,   CreatedBy=1, IsActive= true, IsCompleted=false,  ModifiedOn=DateTime.Now, StatusId =null});

            base.OnModelCreating(modelBuilder);
        }
    }
}


