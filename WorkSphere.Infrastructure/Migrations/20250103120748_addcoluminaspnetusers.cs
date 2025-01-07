using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcoluminaspnetusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImgPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 801, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(4507));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(4622));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Country", "DateOfBirth", "DateOfJoining", "Gender", "ModifiedOn", "PasswordHash", "ProfileImgPath" },
                values: new object[] { "01d6231b-a328-4a43-bd86-192e1ab981af", null, null, new DateTime(2025, 1, 3, 17, 37, 47, 806, DateTimeKind.Local).AddTicks(9705), null, new DateTime(2025, 1, 3, 17, 37, 47, 806, DateTimeKind.Local).AddTicks(9815), "AQAAAAIAAYagAAAAEFV4/cJClswGCH+94M9rD3z7YBxrOpGZti0iNZu8dNPDh1Y7T7t04hNc6+hZ2zuXgw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Country", "DateOfBirth", "DateOfJoining", "Gender", "ModifiedOn", "PasswordHash", "ProfileImgPath" },
                values: new object[] { "a667ada9-9fb0-4ce5-9b03-5074ceca112f", null, null, new DateTime(2025, 1, 3, 17, 37, 47, 891, DateTimeKind.Local).AddTicks(2352), null, new DateTime(2025, 1, 3, 17, 37, 47, 891, DateTimeKind.Local).AddTicks(2367), "AQAAAAIAAYagAAAAEH+OLpMYjQ10hUpxCNyzF+0mIdyQNq8nQDkHKNncmf2IGhuzGj+S/VXAr+gYQb0FXQ==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Country", "DateOfBirth", "DateOfJoining", "Gender", "ModifiedOn", "PasswordHash", "ProfileImgPath" },
                values: new object[] { "b180db63-b158-48b6-b232-254616482d56", null, null, new DateTime(2025, 1, 3, 17, 37, 47, 948, DateTimeKind.Local).AddTicks(7978), null, new DateTime(2025, 1, 3, 17, 37, 47, 948, DateTimeKind.Local).AddTicks(7994), "AQAAAAIAAYagAAAAEAzr0lSWHIaldkdyagON+hl9rULqfydXqr4CUUEOocfeQnH8gDbZ6gsQZDIWJSQn6Q==", null });

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(6147));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7839), new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7935) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(8099), new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(8100) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(8117), new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(8118) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(6931));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7185));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 3, 17, 37, 47, 802, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(4119), new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(5426), new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(5428) });

            migrationBuilder.UpdateData(
                table: "tbl_Projects",
                keyColumn: "ProjID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(6121), new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(6928), new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(7128) });

            migrationBuilder.UpdateData(
                table: "tbl_Tasks",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(8260), new DateTime(2025, 1, 3, 17, 37, 48, 7, DateTimeKind.Local).AddTicks(8817) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileImgPath",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 676, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(6977));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "3d637e70-6d7d-4212-a0a8-2b87402eaa02", new DateTime(2025, 1, 1, 13, 55, 34, 682, DateTimeKind.Local).AddTicks(3276), new DateTime(2025, 1, 1, 13, 55, 34, 682, DateTimeKind.Local).AddTicks(3475), "AQAAAAIAAYagAAAAEPCj1tSrSEh2fov82waU05RqGPErlJiYoQb27V1JOP1J5Qy5XkzDiSccehp5t2kS2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "6c02d611-f649-413f-8fb0-654a438819ac", new DateTime(2025, 1, 1, 13, 55, 34, 792, DateTimeKind.Local).AddTicks(8741), new DateTime(2025, 1, 1, 13, 55, 34, 792, DateTimeKind.Local).AddTicks(8767), "AQAAAAIAAYagAAAAENV6jI0ZFkJW4/wZpRJsk6oGr7JC/W7nS3ICt45zZdkRnPHh5Z0bCwbZj790MgE80Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "7b37cf34-91b4-48be-a80c-ca68c44e2dab", new DateTime(2025, 1, 1, 13, 55, 34, 885, DateTimeKind.Local).AddTicks(7615), new DateTime(2025, 1, 1, 13, 55, 34, 885, DateTimeKind.Local).AddTicks(7641), "AQAAAAIAAYagAAAAEAWn704kMUR9T9TckGH2aR4GVtdesislTeNtJQ0OWMB206JEGrNo4HQWNbfG7lM3dQ==" });

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9403));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9795));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9822));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9842));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 678, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(2996), new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3184) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3495), new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3497) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3524), new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(3525) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1748));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 1, 13, 55, 34, 679, DateTimeKind.Local).AddTicks(1769));

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(2565), new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(3072) });

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(4356), new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(4358) });

            migrationBuilder.UpdateData(
                table: "tbl_Projects",
                keyColumn: "ProjID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(5487), new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(7041), new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(7384) });

            migrationBuilder.UpdateData(
                table: "tbl_Tasks",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 55, 34, 980, DateTimeKind.Local).AddTicks(9241), new DateTime(2025, 1, 1, 13, 55, 34, 981, DateTimeKind.Local).AddTicks(197) });
        }
    }
}
