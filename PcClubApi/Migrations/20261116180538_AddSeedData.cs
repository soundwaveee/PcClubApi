using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcClubApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "Id", "IsVip", "Name", "PricePerHour" },
                values: new object[,]
                {
                    { 1, false, "Standard", 150m },
                    { 2, true, "VIP Room", 400m }
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "IpAddress", "Name", "Specs", "StatusId", "ZoneId" },
                values: new object[,]
                {
                    { 1, "192.168.1.10", "PC-01", "RTX 3060, i5-12400", 1, 1 },
                    { 2, "192.168.1.11", "PC-02", "RTX 3060, i5-12400", 2, 1 },
                    { 3, "192.168.1.50", "VIP-PC-01", "RTX 4090, i9-13900K", 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
