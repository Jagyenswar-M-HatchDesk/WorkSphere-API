using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class taskiamgeadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "tbl_Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 487, DateTimeKind.Local).AddTicks(709));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 489, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 489, DateTimeKind.Local).AddTicks(9876));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "c3e691bf-0809-41fd-b909-f6ea870c57c6", new DateTime(2025, 1, 13, 12, 42, 1, 498, DateTimeKind.Local).AddTicks(7807), new DateTime(2025, 1, 13, 12, 42, 1, 498, DateTimeKind.Local).AddTicks(8263), "AQAAAAIAAYagAAAAEPR9vvmMUl+trTJmc8qxAqdhpnPWd2Y3v/dI7Tjtz+vVfU+AhXK57KqnRpyd4psZsg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "b2f60a86-9e58-4c5e-a448-c2f42ab79925", new DateTime(2025, 1, 13, 12, 42, 1, 665, DateTimeKind.Local).AddTicks(408), new DateTime(2025, 1, 13, 12, 42, 1, 665, DateTimeKind.Local).AddTicks(422), "AQAAAAIAAYagAAAAEDB6r8A/V37eQFwqx8rwlRnClbXpNI3QBMyNkapXOaeAEnoxt5MRDo2cx2HUDREHpQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "e739fc09-60c9-4c5c-9217-6db425c42d58", new DateTime(2025, 1, 13, 12, 42, 1, 807, DateTimeKind.Local).AddTicks(941), new DateTime(2025, 1, 13, 12, 42, 1, 807, DateTimeKind.Local).AddTicks(974), "AQAAAAIAAYagAAAAEIrFRIVUUIzRdFpJoU8CKF8rTJg05Hpqtb61WwEVI3HZiSskzjqbm4GYJojEelivyg==" });

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 490, DateTimeKind.Local).AddTicks(3824));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 490, DateTimeKind.Local).AddTicks(5466));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 490, DateTimeKind.Local).AddTicks(5531));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 490, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 490, DateTimeKind.Local).AddTicks(5590));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 492, DateTimeKind.Local).AddTicks(7131), new DateTime(2025, 1, 13, 12, 42, 1, 492, DateTimeKind.Local).AddTicks(7668) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 493, DateTimeKind.Local).AddTicks(676), new DateTime(2025, 1, 13, 12, 42, 1, 493, DateTimeKind.Local).AddTicks(688) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 493, DateTimeKind.Local).AddTicks(759), new DateTime(2025, 1, 13, 12, 42, 1, 493, DateTimeKind.Local).AddTicks(761) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(326));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(2334));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(2393));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(2460));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(2512));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 12, 42, 1, 491, DateTimeKind.Local).AddTicks(2542));

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 985, DateTimeKind.Local).AddTicks(3356), new DateTime(2025, 1, 13, 12, 42, 1, 985, DateTimeKind.Local).AddTicks(4449) });

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 985, DateTimeKind.Local).AddTicks(8444), new DateTime(2025, 1, 13, 12, 42, 1, 985, DateTimeKind.Local).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "tbl_Projects",
                keyColumn: "ProjID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 986, DateTimeKind.Local).AddTicks(2615), new DateTime(2025, 1, 13, 12, 42, 1, 986, DateTimeKind.Local).AddTicks(7039), new DateTime(2025, 1, 13, 12, 42, 1, 986, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "tbl_Tasks",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ImagePath", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 13, 12, 42, 1, 987, DateTimeKind.Local).AddTicks(4415), null, new DateTime(2025, 1, 13, 12, 42, 1, 987, DateTimeKind.Local).AddTicks(7261) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "tbl_Tasks");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 261, DateTimeKind.Local).AddTicks(1121));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(3687));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(4298));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "03eb799a-8f8b-4476-a7fb-9263285a9ca9", new DateTime(2025, 1, 13, 11, 39, 46, 272, DateTimeKind.Local).AddTicks(4299), new DateTime(2025, 1, 13, 11, 39, 46, 272, DateTimeKind.Local).AddTicks(4765), "AQAAAAIAAYagAAAAEEGZsvSHe9Tspz48VcYfDDHWnIyK03lQdlhu70+jT8n5vUM36WEDKMpmCqY/om4zWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "1e7a101d-d125-4118-90d1-edf67f4cefed", new DateTime(2025, 1, 13, 11, 39, 46, 417, DateTimeKind.Local).AddTicks(1316), new DateTime(2025, 1, 13, 11, 39, 46, 417, DateTimeKind.Local).AddTicks(1355), "AQAAAAIAAYagAAAAEGXs5W0ebKBo9+d4GJuobxsSqd+JPQAP+WSBzwRNZVYlgi3YqoN2kHKvIqChkNw5ww==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn", "PasswordHash" },
                values: new object[] { "1a9950eb-7e7b-406c-9b45-73f237d513a6", new DateTime(2025, 1, 13, 11, 39, 46, 523, DateTimeKind.Local).AddTicks(5532), new DateTime(2025, 1, 13, 11, 39, 46, 523, DateTimeKind.Local).AddTicks(5560), "AQAAAAIAAYagAAAAEP9LDxLfaAH7E9AaWAIpvqNbjs2Nn7XbaM2Yb/yTUgmsWM9FX1VhdpBJHhuNqrIw1A==" });

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(8418));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "mst_Departments",
                keyColumn: "DeptId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 265, DateTimeKind.Local).AddTicks(8465));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(4365), new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(4830) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(5959), new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(5962) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(5994), new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(5995) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(2156));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "StatusId",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2025, 1, 13, 11, 39, 46, 266, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 639, DateTimeKind.Local).AddTicks(4925), new DateTime(2025, 1, 13, 11, 39, 46, 639, DateTimeKind.Local).AddTicks(5746) });

            migrationBuilder.UpdateData(
                table: "tbl_Clients",
                keyColumn: "ClientID",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 639, DateTimeKind.Local).AddTicks(9001), new DateTime(2025, 1, 13, 11, 39, 46, 639, DateTimeKind.Local).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "tbl_Projects",
                keyColumn: "ProjID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 640, DateTimeKind.Local).AddTicks(1684), new DateTime(2025, 1, 13, 11, 39, 46, 640, DateTimeKind.Local).AddTicks(5072), new DateTime(2025, 1, 13, 11, 39, 46, 640, DateTimeKind.Local).AddTicks(5671) });

            migrationBuilder.UpdateData(
                table: "tbl_Tasks",
                keyColumn: "TaskID",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2025, 1, 13, 11, 39, 46, 641, DateTimeKind.Local).AddTicks(1766), new DateTime(2025, 1, 13, 11, 39, 46, 641, DateTimeKind.Local).AddTicks(3823) });
        }
    }
}
