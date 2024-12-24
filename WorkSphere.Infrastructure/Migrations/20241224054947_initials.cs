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
                name: "mst_Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_SeverityLevels",
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
                    table.PrimaryKey("PK_mst_SeverityLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mst_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mst_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Client",
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
                    table.PrimaryKey("PK_tbl_Client", x => x.ClientID);
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
                    Department = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_AspNetUsers_mst_Department_Department",
                        column: x => x.Department,
                        principalTable: "mst_Department",
                        principalColumn: "Id",
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "tbl_Project",
                columns: table => new
                {
                    ProjID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjDescr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Client = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Manager = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<int>(type: "int", nullable: false),
                    TeamSize = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Project", x => x.ProjID);
                    table.ForeignKey(
                        name: "FK_tbl_Project_AspNetUsers_Manager",
                        column: x => x.Manager,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Project_mst_Department_Department",
                        column: x => x.Department,
                        principalTable: "mst_Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Project_mst_SeverityLevels_SeverityLevel",
                        column: x => x.SeverityLevel,
                        principalTable: "mst_SeverityLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Project_mst_Status_Status",
                        column: x => x.Status,
                        principalTable: "mst_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Project_tbl_Client_Client",
                        column: x => x.Client,
                        principalTable: "tbl_Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Task",
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
                    Project = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Task", x => x.TaskID);
                    table.ForeignKey(
                        name: "FK_tbl_Task_AspNetUsers_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Task_mst_Status_Status",
                        column: x => x.Status,
                        principalTable: "mst_Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Task_tbl_Project_Project",
                        column: x => x.Project,
                        principalTable: "tbl_Project",
                        principalColumn: "ProjID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Discriminator", "IsActive", "IsDelete", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 12, 24, 11, 19, 46, 527, DateTimeKind.Local).AddTicks(9438), "Roles", true, false, "Admin", "ADMIN" },
                    { 2, null, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(1862), "Roles", true, false, "Manager", "MANAGER" },
                    { 3, null, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(2008), "Roles", true, false, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "mst_Department",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeptName", "IsActive", "IsDelete" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3117), "None", true, false },
                    { 2, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3357), "Desktop App Development", true, false },
                    { 3, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3373), "Mobile Development", true, false },
                    { 4, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3386), "UI/UX Design", true, false },
                    { 5, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(3398), "API Development", true, false }
                });

            migrationBuilder.InsertData(
                table: "mst_SeverityLevels",
                columns: new[] { "Id", "CreatedBy", "Createdon", "IsActive", "IsDeleted", "Updatedon", "level" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5070), true, false, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5171), "High" },
                    { 2, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5340), true, false, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5340), "Medium" },
                    { 3, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5357), true, false, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(5357), "Low" }
                });

            migrationBuilder.InsertData(
                table: "mst_Status",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "IsActive", "IsDelete", "StatusName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4093), true, false, "Accepted" },
                    { 2, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4265), true, false, "In Progress" },
                    { 3, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4281), true, false, "Pending" },
                    { 4, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4374), true, false, "Delayed" },
                    { 5, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4390), true, false, "At Risk" },
                    { 6, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4425), true, false, "Completed" },
                    { 7, 1, new DateTime(2024, 12, 24, 11, 19, 46, 529, DateTimeKind.Local).AddTicks(4439), true, false, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Client",
                columns: new[] { "ClientID", "ClientName", "CreatedBy", "CreatedOn", "Email", "IsActive", "IsDelete", "ModifiedOn", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hatchdesk", 1, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(4238), "hatchdesk18@gmail.com", true, false, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(4664), "7723099993" },
                    { 2, "Congent", 1, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(5439), "cogent@gmail.com", true, false, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(5440), "374t4328234" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "DateOfJoining", "Department", "Email", "EmailConfirmed", "FirstName", "IsActive", "IsDeleted", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rollid", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "b38839c0-80d5-40ab-a485-a1fbafeb77b0", 1, new DateTime(2024, 12, 24, 11, 19, 46, 531, DateTimeKind.Local).AddTicks(2197), 1, "admin@gmail.com", false, "Admin", true, false, null, "Admin", false, null, new DateTime(2024, 12, 24, 11, 19, 46, 531, DateTimeKind.Local).AddTicks(2302), null, null, "AQAAAAIAAYagAAAAEJdicrG3voD0n8TywxstbcmEOdGCRgM2m1m879oyGIo9KD3UMEXzsmcQC4m1/Yltzg==", "7723099993", false, 1, null, false, "admin@gmail.com" },
                    { 2, 0, "45a1cb75-9eaf-45b4-9203-526199f3edbc", 1, new DateTime(2024, 12, 24, 11, 19, 46, 592, DateTimeKind.Local).AddTicks(8772), 3, "tapanmeher@gmail.com", false, "Tapan", true, false, null, "Meher", false, null, new DateTime(2024, 12, 24, 11, 19, 46, 592, DateTimeKind.Local).AddTicks(8793), null, null, "AQAAAAIAAYagAAAAENgHOS8wSyPGgjQfQPeTwgRfBuFblJ0XkOrFnA1fXZsgxjrBRCrmEephow31iMzaQA==", "7723099993", false, 2, null, false, "tapanmeher@gmail.com" },
                    { 3, 0, "92642f61-f6ed-480e-8c8f-a41397186e03", 1, new DateTime(2024, 12, 24, 11, 19, 46, 649, DateTimeKind.Local).AddTicks(3309), 3, "sakshiyadav@gmail.com", false, "Sakshi", true, false, null, "Yadav", false, null, new DateTime(2024, 12, 24, 11, 19, 46, 649, DateTimeKind.Local).AddTicks(3321), null, null, "AQAAAAIAAYagAAAAEHpmGFDQyaS+ejd2TkdHaFpyxvpukHAaDPBIEmqHETbtGRyjPuR5fwnAR+p/72Mblw==", "2783682993", false, 3, null, false, "sakshiyadav@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "tbl_Project",
                columns: new[] { "ProjID", "Client", "CreatedBy", "CreatedOn", "Deadline", "Department", "ImagePath", "IsActive", "IsCompleted", "Manager", "ModifiedOn", "ProjDescr", "SeverityLevel", "StartDate", "Status", "TeamSize", "Title" },
                values: new object[] { 1, 1, 1, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(6028), null, 1, "string.jpeg", true, false, 2, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(6802), "Project For test", 2, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(7290), null, 3, "Test Project" });

            migrationBuilder.InsertData(
                table: "tbl_Task",
                columns: new[] { "TaskID", "AssignedTo", "CreatedBy", "CreatedOn", "IsActive", "IsCompleted", "ModifiedOn", "Progress", "Project", "Status", "TaskDescr", "TaskTitle" },
                values: new object[] { 1, 3, 1, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(8333), true, false, new DateTime(2024, 12, 24, 11, 19, 46, 705, DateTimeKind.Local).AddTicks(8884), 25, 1, null, "Task For test", "Test TAsk" });

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
                name: "IX_AspNetUsers_Department",
                table: "AspNetUsers",
                column: "Department");

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
                name: "IX_tbl_Project_Client",
                table: "tbl_Project",
                column: "Client");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_Department",
                table: "tbl_Project",
                column: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_Manager",
                table: "tbl_Project",
                column: "Manager");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_SeverityLevel",
                table: "tbl_Project",
                column: "SeverityLevel");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_Status",
                table: "tbl_Project",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Task_AssignedTo",
                table: "tbl_Task",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Task_Project",
                table: "tbl_Task",
                column: "Project");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Task_Status",
                table: "tbl_Task",
                column: "Status");
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
                name: "tbl_Task");

            migrationBuilder.DropTable(
                name: "tbl_Project");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "mst_SeverityLevels");

            migrationBuilder.DropTable(
                name: "mst_Status");

            migrationBuilder.DropTable(
                name: "tbl_Client");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "mst_Department");
        }
    }
}
