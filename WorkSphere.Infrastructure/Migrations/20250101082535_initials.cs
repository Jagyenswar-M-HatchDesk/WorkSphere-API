using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "mst_SeverityLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Createdon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updatedon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_SeverityLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rollid = table.Column<int>(type: "int", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_Rollid",
                        column: x => x.Rollid,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_mst_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "mst_Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Projects",
                columns: table => new
                {
                    ProjID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjDescr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    TeamSize = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    SeverityLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Projects", x => x.ProjID);
                    table.ForeignKey(
                        name: "FK_tbl_Projects_AspNetUsers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Projects_mst_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "mst_Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Projects_mst_SeverityLevel_SeverityLevelId",
                        column: x => x.SeverityLevelId,
                        principalTable: "mst_SeverityLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Projects_mst_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "mst_Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Projects_tbl_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "tbl_Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tasks",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    AssignedTo = table.Column<int>(type: "int", nullable: false),
                    TaskDescr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tasks", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_tbl_Tasks_AspNetUsers_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Tasks_mst_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "mst_Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Tasks_tbl_Projects_ProjID",
                        column: x => x.ProjID,
                        principalTable: "tbl_Projects",
                        principalColumn: "ProjID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Discriminator", "IsActive", "IsDelete", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 1, 13, 55, 34, 676, DateTimeKind.Local).AddTicks(2903), "Roles", true, false, "Admin", "ADMIN" },
                    { 2, null, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(6977), "Roles", true, false, "Manager", "MANAGER" },
                    { 3, null, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(7165), "Roles", true, false, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "mst_Departments",
                columns: new[] { "DeptId", "CreatedBy", "CreatedOn", "DeptName", "IsActive", "IsDelete" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9403), "None", true, false },
                    { 2, 1, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9795), "Desktop App Development", true, false },
                    { 3, 1, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9822), "Mobile Development", true, false },
                    { 4, 1, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9842), "UI/UX Design", true, false },
                    { 5, 1, new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9862), "API Development", true, false }
                });

            migrationBuilder.InsertData(
                table: "mst_SeverityLevel",
                columns: new[] { "Id", "CreatedBy", "Createdon", "IsActive", "IsDeleted", "Updatedon", "level" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(2996), true, false, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3184), "High" },
                    { 2, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3495), true, false, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3497), "Medium" },
                    { 3, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3524), true, false, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3525), "Low" }
                });

            migrationBuilder.InsertData(
                table: "mst_Status",
                columns: new[] { "StatusId", "CreatedBy", "CreatedOn", "IsActive", "IsDelete", "StatusName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1312), true, false, "Accepted" },
                    { 2, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1656), true, false, "In Progress" },
                    { 3, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1680), true, false, "Pending" },
                    { 4, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1703), true, false, "Delayed" },
                    { 5, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1724), true, false, "At Risk" },
                    { 6, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1748), true, false, "Completed" },
                    { 7, 1, new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1769), true, false, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Clients",
                columns: new[] { "ClientID", "ClientName", "CreatedBy", "CreatedOn", "Email", "IsActive", "IsDelete", "ModifiedOn", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hatchdesk", 1, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(2565), "hatchdesk18@gmail.com", true, false, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(3072), "7723099993" },
                    { 2, "Congent", 1, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(4356), "cogent@gmail.com", true, false, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(4358), "374t4328234" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "DateOfJoining", "DeptId", "Email", "EmailConfirmed", "FirstName", "IsActive", "IsDeleted", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rollid", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "3d637e70-6d7d-4212-a0a8-2b87402eaa02", 1, new DateTime(2025, 1, 1, 13, 55, 34, 682, DateTimeKind.Local).AddTicks(3276), 1, "admin@gmail.com", false, "Admin", true, false, null, "Admin", false, null, new DateTime(2025, 1, 1, 13, 55, 34, 682, DateTimeKind.Local).AddTicks(3475), null, null, "AQAAAAIAAYagAAAAEPCj1tSrSEh2fov82waU05RqGPErlJiYoQb27V1JOP1J5Qy5XkzDiSccehp5t2kS2g==", "7723099993", false, 1, null, false, "admin@gmail.com" },
                    { 2, 0, "6c02d611-f649-413f-8fb0-654a438819ac", 1, new DateTime(2025, 1, 1, 13, 55, 34, 792, DateTimeKind.Local).AddTicks(8741), 3, "tapanmeher@gmail.com", false, "Tapan", true, false, null, "Meher", false, null, new DateTime(2025, 1, 1, 13, 55, 34, 792, DateTimeKind.Local).AddTicks(8767), null, null, "AQAAAAIAAYagAAAAENV6jI0ZFkJW4/wZpRJsk6oGr7JC/W7nS3ICt45zZdkRnPHh5Z0bCwbZj790MgE80Q==", "7723099993", false, 2, null, false, "tapanmeher@gmail.com" },
                    { 3, 0, "7b37cf34-91b4-48be-a80c-ca68c44e2dab", 1, new DateTime(2025, 1, 1, 13, 55, 34, 885, DateTimeKind.Local).AddTicks(7615), 3, "sakshiyadav@gmail.com", false, "Sakshi", true, false, null, "Yadav", false, null, new DateTime(2025, 1, 1, 13, 55, 34, 885, DateTimeKind.Local).AddTicks(7641), null, null, "AQAAAAIAAYagAAAAEAWn704kMUR9T9TckGH2aR4GVtdesislTeNtJQ0OWMB206JEGrNo4HQWNbfG7lM3dQ==", "2783682993", false, 3, null, false, "sakshiyadav@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Projects",
                columns: new[] { "ProjID", "ClientId", "CreatedBy", "CreatedOn", "Deadline", "DepartmentID", "ImagePath", "IsActive", "IsCompleted", "ManagerID", "ModifiedOn", "ProjDescr", "SeverityLevelId", "StartDate", "StatusId", "TeamSize", "Title" },
                values: new object[] { 1, 1, 1, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(5487), null, 1, "string.jpeg", true, false, 2, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(7041), "Project For test", 2, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(7384), null, 3, "Test Project" });

            migrationBuilder.InsertData(
                table: "tbl_Tasks",
                columns: new[] { "TaskID", "AssignedTo", "CreatedBy", "CreatedOn", "IsActive", "IsCompleted", "ModifiedOn", "Progress", "ProjID", "StatusId", "TaskDescr", "TaskTitle" },
                values: new object[] { 1, 3, 1, new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(9241), true, false, new DateTime(2025, 1, 1, 13, 55, 34, 981, DateTimeKind.Local).AddTicks(197), 25, 1, null, "Task For test", "Test TAsk" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeptId",
                table: "AspNetUsers",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Rollid",
                table: "AspNetUsers",
                column: "Rollid");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Projects_ClientId",
                table: "tbl_Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Projects_DepartmentID",
                table: "tbl_Projects",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Projects_ManagerID",
                table: "tbl_Projects",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Projects_SeverityLevelId",
                table: "tbl_Projects",
                column: "SeverityLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Projects_StatusId",
                table: "tbl_Projects",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_AssignedTo",
                table: "tbl_Tasks",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_ProjID",
                table: "tbl_Tasks",
                column: "ProjID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Tasks_StatusId",
                table: "tbl_Tasks",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "tbl_Tasks");

            migrationBuilder.DropTable(
                name: "tbl_Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "mst_SeverityLevel");

            migrationBuilder.DropTable(
                name: "mst_Status");

            migrationBuilder.DropTable(
                name: "tbl_Clients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "mst_Departments");
        }
    }
}
