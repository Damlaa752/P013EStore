using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P013EStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class damla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 5, 8, 23, 3, 4, 454, DateTimeKind.Local).AddTicks(9014), new Guid("b13bd95e-232d-4697-999f-a7bbf4592505") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UserGuid" },
                values: new object[] { new DateTime(2023, 5, 2, 22, 44, 9, 508, DateTimeKind.Local).AddTicks(383), new Guid("08f4a092-a9cc-4ff9-bbe1-62923d635ced") });
        }
    }
}
