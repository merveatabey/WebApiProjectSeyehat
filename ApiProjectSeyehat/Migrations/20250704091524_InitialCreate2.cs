using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjectSeyehat.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Transportations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Trips",
                newName: "TransportationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransportationId",
                table: "Trips",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Transportations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
