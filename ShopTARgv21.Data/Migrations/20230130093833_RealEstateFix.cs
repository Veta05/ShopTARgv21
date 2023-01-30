using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTARgv21.Data.Migrations
{
    public partial class RealEstateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MofiedAt",
                table: "RealEstate",
                newName: "ModifiedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "RealEstate",
                newName: "MofiedAt");
        }
    }
}
