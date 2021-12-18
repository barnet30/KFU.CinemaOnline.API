using Microsoft.EntityFrameworkCore.Migrations;

namespace KFU.CinemaOnline.DAL.Cinema.Migrations
{
    public partial class Rename_EstimateToEstimation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estimate",
                table: "Estimations",
                newName: "Estimation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estimation",
                table: "Estimations",
                newName: "Estimate");
        }
    }
}
