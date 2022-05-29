using Microsoft.EntityFrameworkCore.Migrations;

namespace KFU.CinemaOnline.DAL.Cinema.Migrations
{
    public partial class AddCountryIdToActorAndDirector : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Directors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Actors",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Actors");
        }
    }
}
