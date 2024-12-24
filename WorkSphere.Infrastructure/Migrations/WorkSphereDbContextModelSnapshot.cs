﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkSphere.Infrastructure;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    [DbContext(typeof(WorkSphereDbContext))]
    partial class WorkSphereDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasDiscriminator().HasValue("IdentityRole<int>");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WorkSphere.Domain.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("tbl_Client", (string)null);

                    b.HasData(
                        new
                        {
                            ClientID = 1,
                            ClientName = "Hatchdesk",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(4238),
                            Email = "hatchdesk18@gmail.com",
                            IsActive = true,
                            IsDelete = false,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(4664),
                            PhoneNumber = "7723099993"
                        },
                        new
                        {
                            ClientID = 2,
                            ClientName = "Congent",
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(5439),
                            Email = "cogent@gmail.com",
                            IsActive = true,
                            IsDelete = false,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(5440),
                            PhoneNumber = "374t4328234"
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("mst_Department", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3117),
                            DeptName = "None",
                            IsActive = true,
                            IsDelete = false
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3357),
                            DeptName = "Desktop App Development",
                            IsActive = true,
                            IsDelete = false
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3373),
                            DeptName = "Mobile Development",
                            IsActive = true,
                            IsDelete = false
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3386),
                            DeptName = "UI/UX Design",
                            IsActive = true,
                            IsDelete = false
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3398),
                            DeptName = "API Development",
                            IsActive = true,
                            IsDelete = false
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.Projects", b =>
                {
                    b.Property<int>("ProjID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjID"));

                    b.Property<int>("Client")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("Manager")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjDescr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeverityLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TeamSize")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjID");

                    b.HasIndex("Client");

                    b.HasIndex("Department");

                    b.HasIndex("Manager");

                    b.HasIndex("SeverityLevel");

                    b.HasIndex("Status");

                    b.ToTable("tbl_Project", (string)null);

                    b.HasData(
                        new
                        {
                            ProjID = 1,
                            Client = 1,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(6028),
                            Department = 1,
                            ImagePath = "string.jpeg",
                            IsActive = true,
                            IsCompleted = false,
                            Manager = 2,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(6802),
                            ProjDescr = "Project For test",
                            SeverityLevel = 2,
                            StartDate = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(7290),
                            TeamSize = 3,
                            Title = "Test Project"
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.SeverityLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("Createdon")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Updatedon")
                        .HasColumnType("datetime2");

                    b.Property<string>("level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mst_SeverityLevels", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            Createdon = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5070),
                            IsActive = true,
                            IsDeleted = false,
                            Updatedon = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5171),
                            level = "High"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            Createdon = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5340),
                            IsActive = true,
                            IsDeleted = false,
                            Updatedon = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5340),
                            level = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            Createdon = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5357),
                            IsActive = true,
                            IsDeleted = false,
                            Updatedon = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5357),
                            level = "Low"
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("mst_Status", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4093),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "Accepted"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4265),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "In Progress"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4281),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "Pending"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4374),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "Delayed"
                        },
                        new
                        {
                            Id = 5,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4390),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "At Risk"
                        },
                        new
                        {
                            Id = 6,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4425),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "Completed"
                        },
                        new
                        {
                            Id = 7,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4439),
                            IsActive = true,
                            IsDelete = false,
                            StatusName = "Rejected"
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.Tasks", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"));

                    b.Property<int>("AssignedTo")
                        .HasColumnType("int");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Progress")
                        .HasColumnType("int");

                    b.Property<int>("Project")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaskTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskID");

                    b.HasIndex("AssignedTo");

                    b.HasIndex("Project");

                    b.HasIndex("Status");

                    b.ToTable("tbl_Task", (string)null);

                    b.HasData(
                        new
                        {
                            TaskID = 1,
                            AssignedTo = 3,
                            CreatedBy = 1,
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(8333),
                            IsActive = true,
                            IsCompleted = false,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(8884),
                            Progress = 25,
                            Project = 1,
                            TaskDescr = "Task For test",
                            TaskTitle = "Test TAsk"
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Rollid")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Department");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("Rollid");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b38839c0-80d5-40ab-a485-a1fbafeb77b0",
                            CreatedBy = 1,
                            DateOfJoining = new DateTime(2024, 12, 24, 11, 19, 46, 531, DateTimeKind.Local).AddTicks(2197),
                            Department = 1,
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Admin",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Admin",
                            LockoutEnabled = false,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 531, DateTimeKind.Local).AddTicks(2302),
                            PasswordHash = "AQAAAAIAAYagAAAAEJdicrG3voD0n8TywxstbcmEOdGCRgM2m1m879oyGIo9KD3UMEXzsmcQC4m1/Yltzg==",
                            PhoneNumber = "7723099993",
                            PhoneNumberConfirmed = false,
                            Rollid = 1,
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "45a1cb75-9eaf-45b4-9203-526199f3edbc",
                            CreatedBy = 1,
                            DateOfJoining = new DateTime(2024, 12, 24, 11, 19, 46, 592, DateTimeKind.Local).AddTicks(8772),
                            Department = 3,
                            Email = "tapanmeher@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Tapan",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Meher",
                            LockoutEnabled = false,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 592, DateTimeKind.Local).AddTicks(8793),
                            PasswordHash = "AQAAAAIAAYagAAAAENgHOS8wSyPGgjQfQPeTwgRfBuFblJ0XkOrFnA1fXZsgxjrBRCrmEephow31iMzaQA==",
                            PhoneNumber = "7723099993",
                            PhoneNumberConfirmed = false,
                            Rollid = 2,
                            TwoFactorEnabled = false,
                            UserName = "tapanmeher@gmail.com"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "92642f61-f6ed-480e-8c8f-a41397186e03",
                            CreatedBy = 1,
                            DateOfJoining = new DateTime(2024, 12, 24, 11, 19, 46, 649, DateTimeKind.Local).AddTicks(3309),
                            Department = 3,
                            Email = "sakshiyadav@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Sakshi",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Yadav",
                            LockoutEnabled = false,
                            ModifiedOn = new DateTime(2024, 12, 24, 11, 19, 46, 649, DateTimeKind.Local).AddTicks(3321),
                            PasswordHash = "AQAAAAIAAYagAAAAEHpmGFDQyaS+ejd2TkdHaFpyxvpukHAaDPBIEmqHETbtGRyjPuR5fwnAR+p/72Mblw==",
                            PhoneNumber = "2783682993",
                            PhoneNumberConfirmed = false,
                            Rollid = 3,
                            TwoFactorEnabled = false,
                            UserName = "sakshiyadav@gmail.com"
                        });
                });

            modelBuilder.Entity("WorkSphere.Domain.Roles", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole<int>");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            NormalizedName = "ADMIN",
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 527, DateTimeKind.Local).AddTicks(9438),
                            IsActive = true,
                            IsDelete = false
                        },
                        new
                        {
                            Id = 2,
                            Name = "Manager",
                            NormalizedName = "MANAGER",
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(1862),
                            IsActive = true,
                            IsDelete = false
                        },
                        new
                        {
                            Id = 3,
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE",
                            CreatedOn = new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(2008),
                            IsActive = true,
                            IsDelete = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WorkSphere.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WorkSphere.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("WorkSphere.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WorkSphere.Domain.Projects", b =>
                {
                    b.HasOne("WorkSphere.Domain.Client", null)
                        .WithMany()
                        .HasForeignKey("Client")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.Department", null)
                        .WithMany()
                        .HasForeignKey("Department")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("Manager")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.SeverityLevel", null)
                        .WithMany()
                        .HasForeignKey("SeverityLevel")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.Status", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WorkSphere.Domain.Tasks", b =>
                {
                    b.HasOne("WorkSphere.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("AssignedTo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.Projects", null)
                        .WithMany()
                        .HasForeignKey("Project")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorkSphere.Domain.Status", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WorkSphere.Domain.User", b =>
                {
                    b.HasOne("WorkSphere.Domain.Department", null)
                        .WithMany()
                        .HasForeignKey("Department")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WorkSphere.Domain.Roles", null)
                        .WithMany()
                        .HasForeignKey("Rollid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
