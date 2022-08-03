using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelsoMusic.Repository.Migrations
{
    public partial class _20220802 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroMusica");

            migrationBuilder.DropTable(
                name: "Generos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GeneroMusica",
                columns: table => new
                {
                    GenerosID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicasID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroMusica", x => new { x.GenerosID, x.MusicasID });
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Generos_GenerosID",
                        column: x => x.GenerosID,
                        principalTable: "Generos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroMusica_Musicas_MusicasID",
                        column: x => x.MusicasID,
                        principalTable: "Musicas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroMusica_MusicasID",
                table: "GeneroMusica",
                column: "MusicasID");
        }
    }
}
