using Microsoft.EntityFrameworkCore.Migrations;

namespace KFU.CinemaOnline.DAL.Cinema.Migrations
{
    public partial class AddCountryIdToMovieEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Movies");
        }
    }
}
