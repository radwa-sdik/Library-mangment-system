using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class removeisAvailablefrombookstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAvaliable",
                table: "Books");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAvaliable",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN001",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN002",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN003",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN004",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN005",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN006",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN007",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN008",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN009",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN010",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN011",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN012",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN013",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN014",
                column: "isAvaliable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN015",
                column: "isAvaliable",
                value: true);
        }
    }
}
