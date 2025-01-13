using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcoltotblProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tbl_Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 285, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(2163));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(2247));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "bc80850d-af69-4bac-8c12-bc94cf7f20cb", new DateTime(2025, 1, 10, 14, 57, 3, 287, DateTimeKind.Local).AddTicks(7656), new DateTime(2025, 1, 10, 14, 57, 3, 287, DateTimeKind.Local).AddTicks(7735), "AQAAAAIAAYagAAAAEK1Phc6PHvaOa4FuuGPmIOaDdjz6NQloPSu8ys9VK//asHzQObXhTNln1FEQsT6r/w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "35d39e84-3df7-45c7-a99b-f3990181ccd5", new DateTime(2025, 1, 10, 14, 57, 3, 330, DateTimeKind.Local).AddTicks(2173), new DateTime(2025, 1, 10, 14, 57, 3, 330, DateTimeKind.Local).AddTicks(2184), "AQAAAAIAAYagAAAAEOB6xgX+SAWaxu0HmOecAxZ4hjw9O7ZqaSWvARHrJg3MQiFbkLkQSCQXD9LF6T1sHA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "226d5dce-60fe-4817-a1ea-96a34c9155de", new DateTime(2025, 1, 10, 14, 57, 3, 368, DateTimeKind.Local).AddTicks(1123), new DateTime(2025, 1, 10, 14, 57, 3, 368, DateTimeKind.Local).AddTicks(1132), "AQAAAAIAAYagAAAAEC5Q5tZHZRXS0/DkUTELNJgQjQ1sVd+vicMw15xPCm2a59dBqkZ9Jlt5Q2YUxJpvAA==" });

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(3317));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4808), new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4879) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(5016), new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(5017) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(5030), new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4026));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4208));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 10, 14, 57, 3, 286, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(3714), new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(4004) });

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(4622), new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "tbl_Projects",
                keyColumn: "ProjID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "IsDeleted", "ModifiedOn", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(5144), false, new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(5737), new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(5891) });

            migrationBuilder.UpdateData(
                table: "tbl_Tasks",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(6754), new DateTime(2025, 1, 10, 14, 57, 3, 406, DateTimeKind.Local).AddTicks(7160) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tbl_Projects");

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
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "01d6231b-a328-4a43-bd86-192e1ab981af", new DateTime(2025, 1, 3, 17, 37, 47, 806, DateTimeKind.Local).AddTicks(9705), new DateTime(2025, 1, 3, 17, 37, 47, 806, DateTimeKind.Local).AddTicks(9815), "AQAAAAIAAYagAAAAEFV4/cJClswGCH+94M9rD3z7YBxrOpGZti0iNZu8dNPDh1Y7T7t04hNc6+hZ2zuXgw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "a667ada9-9fb0-4ce5-9b03-5074ceca112f", new DateTime(2025, 1, 3, 17, 37, 47, 891, DateTimeKind.Local).AddTicks(2352), new DateTime(2025, 1, 3, 17, 37, 47, 891, DateTimeKind.Local).AddTicks(2367), "AQAAAAIAAYagAAAAEH+OLpMYjQ10hUpxCNyzF+0mIdyQNq8nQDkHKNncmf2IGhuzGj+S/VXAr+gYQb0FXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "b180db63-b158-48b6-b232-254616482d56", new DateTime(2025, 1, 3, 17, 37, 47, 948, DateTimeKind.Local).AddTicks(7978), new DateTime(2025, 1, 3, 17, 37, 47, 948, DateTimeKind.Local).AddTicks(7994), "AQAAAAIAAYagAAAAEAzr0lSWHIaldkdyagON+hl9rULqfydXqr4CUUEOocfeQnH8gDbZ6gsQZDIWJSQn6Q==" });

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
    }
}
