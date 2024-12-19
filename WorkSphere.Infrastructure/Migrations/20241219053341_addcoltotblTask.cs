using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSphere.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addcoltotblTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "tbl_Task",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tbl_Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 550, DateTimeKind.Local).AddTicks(537));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 550, DateTimeKind.Local).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 550, DateTimeKind.Local).AddTicks(9607));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(475));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(486));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(952));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(1108));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(1128));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 19, 11, 3, 40, 551, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Task_Status",
                table: "tbl_Task",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Task_mst_Status_Status",
                table: "tbl_Task",
                column: "Status",
                principalTable: "mst_Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Task_mst_Status_Status",
                table: "tbl_Task");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Task_Status",
                table: "tbl_Task");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "tbl_Task");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbl_Task");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 951, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(2417));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(3581));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(3788));

            migrationBuilder.UpdateData(
                table: "mst_Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4649));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4674));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4687));

            migrationBuilder.UpdateData(
                table: "mst_Status",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2024, 12, 18, 17, 13, 21, 952, DateTimeKind.Local).AddTicks(4699));
        }
    }
}
