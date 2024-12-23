using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 912, DateTimeKind.Local).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(3196));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Name", "NormalizedName" },
                values: new object[] { new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(3351), "Employee", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "7ba849f9-cee1-481f-8072-33e25886e9a4", new DateTime(2024, 12, 23, 18, 2, 19, 914, DateTimeKind.Local).AddTicks(4815), new DateTime(2024, 12, 23, 18, 2, 19, 914, DateTimeKind.Local).AddTicks(4900) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "13d9f6a3-a671-493d-84c0-38d0a240a3ed", new DateTime(2024, 12, 23, 18, 2, 19, 914, DateTimeKind.Local).AddTicks(5646), new DateTime(2024, 12, 23, 18, 2, 19, 914, DateTimeKind.Local).AddTicks(5647) });

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(4485));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(4695));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(4705));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(4715));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(6103), new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(6315), new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(6315) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(6328), new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(6329) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5565));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5576));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5587));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5598));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 18, 2, 19, 913, DateTimeKind.Local).AddTicks(5608));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 321, DateTimeKind.Local).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(4624));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Name", "NormalizedName" },
                values: new object[] { new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(4708), "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "a80d19ae-f3b6-435a-a02c-9525445b6eba", new DateTime(2024, 12, 23, 17, 53, 3, 323, DateTimeKind.Local).AddTicks(4871), new DateTime(2024, 12, 23, 17, 53, 3, 323, DateTimeKind.Local).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "82a0faab-a3e5-4244-b78e-2943bf7f7414", new DateTime(2024, 12, 23, 17, 53, 3, 323, DateTimeKind.Local).AddTicks(5591), new DateTime(2024, 12, 23, 17, 53, 3, 323, DateTimeKind.Local).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(5732));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(5918));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(7086), new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(7309), new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(7310) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(7321), new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(7321) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6592));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6615));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 17, 53, 3, 322, DateTimeKind.Local).AddTicks(6636));
        }
    }
}
