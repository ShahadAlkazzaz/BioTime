using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioTime.Migrations
{
    /// <inheritdoc />
    public partial class AddShowtimeToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowtimeId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowtimeId",
                table: "Bookings",
                column: "ShowtimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Showtimes_ShowtimeId",
                table: "Bookings",
                column: "ShowtimeId",
                principalTable: "Showtimes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Showtimes_ShowtimeId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ShowtimeId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ShowtimeId",
                table: "Bookings");
        }
    }
}
