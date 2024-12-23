
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

        public DbSet<Department> Departments { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<SeverityLevel> SeverityLevel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for Identity tables

            // Identity User Configuration
            //modelBuilder.Entity<User>(b =>
            //{
            //    b.ToTable("tbl_User");
            //    b.HasKey(u => u.Id);
            //    b.Property(u => u.Id).HasColumnName("ID").ValueGeneratedOnAdd();

            //    // Foreign key relationships
            //    b.HasOne<Department>()
            //        .WithMany()
            //        .HasForeignKey(u => u.Department)
            //        .IsRequired()
            //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            //    b.HasOne<Roles>()
            //        .WithMany()
            //        .HasForeignKey(u => u.Rollid)
            //        .IsRequired()
            //        .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
            //});
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("tbl_User");
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).ValueGeneratedOnAdd();

                entity.HasOne<Department>()
                      .WithMany()
                      .HasForeignKey(u => u.Department)
                      //.IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Roles>()
                      .WithMany()
                      .HasForeignKey(u => u.Rollid)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });


            // Identity Role Configuration
            modelBuilder.Entity<IdentityRole<int>>(b =>
            {
                b.ToTable("mst_Roles");
                b.HasKey(r => r.Id);
                b.Property(r => r.Id).ValueGeneratedOnAdd();
            });

            // Configure AspNetUserRoles to avoid multiple cascade paths
            modelBuilder.Entity<IdentityUserRole<int>>(b =>
            {
                b.ToTable("AspNetUserRoles");
                b.HasKey(ur => new { ur.UserId, ur.RoleId });

                b.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete

                b.HasOne<IdentityRole<int>>()
                    .WithMany()
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Restrict); // Disable cascade delete
            });

            // mst_Department Configuration
            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("mst_Department");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<SeverityLevel>(entity =>
            {
                entity.ToTable("mst_SeverityLevels");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // tbl_Task Configuration
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("tbl_Task");
                entity.HasKey(e => e.TaskID);
                entity.Property(e => e.TaskID).ValueGeneratedOnAdd();

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.AssignedTo)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                entity.HasOne<Projects>()
                    .WithMany()
                    .HasForeignKey(e => e.Project)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                entity.HasOne<Status>()
                   .WithMany()
                   .HasForeignKey(e => e.Status)
                   //.IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
            });

            // tbl_Project Configuration
            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("tbl_Project");
                entity.HasKey(e => e.ProjID);
                entity.Property(e => e.ProjID).ValueGeneratedOnAdd();

                entity.HasOne<Client>()
                    .WithMany()
                    .HasForeignKey(e => e.Client)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                entity.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(e => e.Manager)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

                entity.HasOne<Department>()
                    .WithMany()
                    .HasForeignKey(e => e.Department)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Status>()
                    .WithMany()
                    .HasForeignKey(e => e.Status)
                    //.IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<SeverityLevel>()
                    .WithMany()
                    .HasForeignKey(e => e.SeverityLevel)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // tbl_Client Configuration
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("tbl_Client");
                entity.HasKey(e => e.ClientID);
                entity.Property(e => e.ClientID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("mst_Status");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 1, Name = "Admin", NormalizedName = "Admin".ToUpper(), IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 2, Name = "Manager", NormalizedName = "Manager".ToUpper(), IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Roles>().HasData(new Roles { Id = 3, Name = "User", NormalizedName = "User".ToUpper(), IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });

            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, DeptName = "None", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, DeptName = "Desktop App Development", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, DeptName = "Mobile Development", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 4, DeptName = "UI/UX Design", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 5, DeptName = "API Development", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });

            modelBuilder.Entity<Status>().HasData(new Status { Id = 1, StatusName = "Accepted", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { Id = 2, StatusName = "In Progress", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { Id = 3, StatusName = "Pending", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { Id = 4, StatusName = "Delayed", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { Id = 5, StatusName = "At Risk", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { Id = 6, StatusName = "Completed", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });
            modelBuilder.Entity<Status>().HasData(new Status { Id = 7, StatusName = "Rejected", CreatedBy = 1, IsActive = true, IsDelete = false, CreatedOn = DateTime.Now });

            modelBuilder.Entity<SeverityLevel>().HasData(new SeverityLevel { Id = 1, level = "High", CreatedBy = 1, IsActive = true, IsDeleted = false, Createdon = DateTime.Now, Updatedon= DateTime.Now });
            modelBuilder.Entity<SeverityLevel>().HasData(new SeverityLevel { Id = 2, level = "Medium", CreatedBy = 1, IsActive = true, IsDeleted = false, Createdon = DateTime.Now, Updatedon= DateTime.Now });
            modelBuilder.Entity<SeverityLevel>().HasData(new SeverityLevel { Id = 3, level = "Low", CreatedBy = 1, IsActive = true, IsDeleted = false, Createdon = DateTime.Now, Updatedon= DateTime.Now });


            modelBuilder.Entity<User>().HasData(new User { Id = 1, FirstName = "Admin", LastName = "Admin",UserName = "admin@gmail.com",PasswordHash = "Admin@123", Email="admin@gmail.com", Rollid= 1, Department=1, DateOfJoining=DateTime.Now , ModifiedOn=DateTime.Now, PhoneNumber="7723099993" ,CreatedBy = 1, IsActive = true, IsDeleted = false });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, FirstName = "Tapan", LastName = "Meher",UserName = "tapanmeher@gmail.com",PasswordHash = "Tapan@123", Email="tapanmeher@gmail.com", Rollid= 2, Department=3, DateOfJoining=DateTime.Now , ModifiedOn=DateTime.Now, PhoneNumber="7723099993" ,CreatedBy = 1, IsActive = true, IsDeleted = false });

            base.OnModelCreating(modelBuilder);
        }
    }
}


