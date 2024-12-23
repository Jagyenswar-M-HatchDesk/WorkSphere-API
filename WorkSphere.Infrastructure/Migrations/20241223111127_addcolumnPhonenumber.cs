using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnPhonenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contact",
                table: "tbl_Client");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "tbl_Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 270, DateTimeKind.Local).AddTicks(8375));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(226));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "c03d1ead-754c-446a-9cca-bc7bd56c24d3", new DateTime(2024, 12, 23, 16, 41, 27, 273, DateTimeKind.Local).AddTicks(2026), new DateTime(2024, 12, 23, 16, 41, 27, 273, DateTimeKind.Local).AddTicks(2141) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "98b0c99e-e549-475d-babe-e7f46e46b48d", new DateTime(2024, 12, 23, 16, 41, 27, 273, DateTimeKind.Local).AddTicks(2972), new DateTime(2024, 12, 23, 16, 41, 27, 273, DateTimeKind.Local).AddTicks(2973) });

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(1489));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(3065), new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(3208) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(3369), new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(3383), new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(3383) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2381));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2395));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 23, 16, 41, 27, 272, DateTimeKind.Local).AddTicks(2438));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "tbl_Client");

            migrationBuilder.AddColumn<int>(
                name: "Contact",
                table: "tbl_Client",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 670, DateTimeKind.Local).AddTicks(887));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(4233));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "c05bf028-02d8-4191-ae3d-6b46f8f35505", new DateTime(2024, 12, 21, 14, 32, 38, 672, DateTimeKind.Local).AddTicks(7696), new DateTime(2024, 12, 21, 14, 32, 38, 672, DateTimeKind.Local).AddTicks(7823) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "d3940428-d6d7-4abc-bc7e-d981097110e2", new DateTime(2024, 12, 21, 14, 32, 38, 672, DateTimeKind.Local).AddTicks(8734), new DateTime(2024, 12, 21, 14, 32, 38, 672, DateTimeKind.Local).AddTicks(8735) });

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(5433));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(5924));

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7560), new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7656) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7832), new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "mst_SeverityLevels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Createdon", "Updatedon" },
                values: new object[] { new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7851), new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7851) });

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6855));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6888));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(6936));
        }
    }
}
