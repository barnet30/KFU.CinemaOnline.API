using Microsoft.EntityFrameworkCore.Migrations;

namespace KFU.CinemaOnline.DAL.Cinema.Migrations
{
    public partial class AddCategoryToMovieEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Movies",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Movies");
        }
    }
}
