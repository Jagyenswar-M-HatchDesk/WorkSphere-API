using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addseveritylevels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeverityLevel",
                table: "tbl_Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.InsertData(
                table: "mst_SeverityLevels",
                columns: new[] { "Id", "CreatedBy", "Createdon", "IsActive", "IsDeleted", "Updatedon", "level" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7560), true, false, new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7656), "High" },
                    { 2, 1, new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7832), true, false, new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7832), "Medium" },
                    { 3, 1, new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7851), true, false, new DateTime(2024, 12, 21, 14, 32, 38, 671, DateTimeKind.Local).AddTicks(7851), "Low" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Project_SeverityLevel",
                table: "tbl_Project",
                column: "SeverityLevel");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Project_mst_SeverityLevels_SeverityLevel",
                table: "tbl_Project",
                column: "SeverityLevel",
                principalTable: "mst_SeverityLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Project_mst_SeverityLevels_SeverityLevel",
                table: "tbl_Project");

            migrationBuilder.DropTable(
                name: "mst_SeverityLevels");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Project_SeverityLevel",
                table: "tbl_Project");

            migrationBuilder.DropColumn(
                name: "SeverityLevel",
                table: "tbl_Project");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 483, DateTimeKind.Local).AddTicks(7048));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(1323));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "3a9a4e71-3800-41ce-b0aa-9bf0601179ac", new DateTime(2024, 12, 21, 13, 37, 5, 486, DateTimeKind.Local).AddTicks(3576), new DateTime(2024, 12, 21, 13, 37, 5, 486, DateTimeKind.Local).AddTicks(3712) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "DateOfJoining", "ModifiedOn" },
                values: new object[] { "2c74f737-a70a-4f3a-84ab-c74c790ece2e", new DateTime(2024, 12, 21, 13, 37, 5, 486, DateTimeKind.Local).AddTicks(4721), new DateTime(2024, 12, 21, 13, 37, 5, 486, DateTimeKind.Local).AddTicks(4722) });

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(2858));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3857));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3874));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 21, 13, 37, 5, 485, DateTimeKind.Local).AddTicks(3973));
        }
    }
}
