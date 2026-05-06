using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BioTime.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookingNumber",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BookingId",
                table: "Seats",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_BookingId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingNumber",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Seats_SeatId",
                table: "Bookings",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
