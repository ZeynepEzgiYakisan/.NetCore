using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Udemy.WebApi.Migrations
{
    public partial class CategoryTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 1, new DateTime(2023, 4, 3, 9, 50, 19, 760, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 1, new DateTime(2023, 3, 7, 9, 50, 19, 760, DateTimeKind.Local).AddTicks(6878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { 1, new DateTime(2023, 2, 5, 9, 50, 19, 760, DateTimeKind.Local).AddTicks(6886) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { null, new DateTime(2023, 4, 2, 17, 45, 51, 920, DateTimeKind.Local).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { null, new DateTime(2023, 3, 6, 17, 45, 51, 920, DateTimeKind.Local).AddTicks(7211) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "CreatedDate" },
                values: new object[] { null, new DateTime(2023, 2, 4, 17, 45, 51, 920, DateTimeKind.Local).AddTicks(7221) });
        }
    }
}
