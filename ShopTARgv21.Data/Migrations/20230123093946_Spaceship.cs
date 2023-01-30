using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopTARgv21.Data.Migrations
{
    public partial class Spaceship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spaceship",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpaceshipBuilder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfBuild = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnginePower = table.Column<int>(type: "int", nullable: false),
                    LiftUpToSpaceByTonn = table.Column<int>(type: "int", nullable: false),
                    Crew = table.Column<int>(type: "int", nullable: false),
                    Passengers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BuildOfDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileToDatabase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SpaceshipId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileToDatabase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileToDatabase_Spaceship_SpaceshipId",
                        column: x => x.SpaceshipId,
                        principalTable: "Spaceship",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileToDatabase_SpaceshipId",
                table: "FileToDatabase",
                column: "SpaceshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileToDatabase");

            migrationBuilder.DropTable(
                name: "Spaceship");
        }
    }
}
