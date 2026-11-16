using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PcClubApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingsAndSpecs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingTime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Specs",
                value: "RTX 3060, i5-12400, 16GB RAM | Периферия: Монитор 144Hz, Мышь Logitech G102, Наушники HyperX");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Specs",
                value: "RTX 3060, i5-12400, 16GB RAM | Периферия: Монитор 144Hz, Мышь Razer DeathAdder, Клавиатура Redragon");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Specs",
                value: "RTX 4090, i9-13900K, 32GB RAM | Периферия: Монитор 240Hz 4K, Мышь Logitech G Pro X, Клавиатура Wooting 60HE, Наушники Audeze");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ComputerId",
                table: "Bookings",
                column: "ComputerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Specs",
                value: "RTX 3060, i5-12400");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Specs",
                value: "RTX 3060, i5-12400");

            migrationBuilder.UpdateData(
                table: "Computers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Specs",
                value: "RTX 4090, i9-13900K");
        }
    }
}
