using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CelsoMusic.Repository.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UltimaMusicaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaMusicaTempo = table.Column<int>(type: "int", nullable: false),
                    UltimaPlaylistID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Albuns",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtistaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albuns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Albuns_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalTable: "Artistas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Playlists_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Musicas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duracao = table.Column<int>(type: "int", nullable: true),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlaylistID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Musicas_Albuns_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albuns",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Musicas_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ArtistaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MusicaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Genero_Albuns_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albuns",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Genero_Artistas_ArtistaID",
                        column: x => x.ArtistaID,
                        principalTable: "Artistas",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Genero_Musicas_MusicaID",
                        column: x => x.MusicaID,
                        principalTable: "Musicas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albuns_ArtistaID",
                table: "Albuns",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_AlbumID",
                table: "Genero",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_ArtistaID",
                table: "Genero",
                column: "ArtistaID");

            migrationBuilder.CreateIndex(
                name: "IX_Genero_MusicaID",
                table: "Genero",
                column: "MusicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_AlbumID",
                table: "Musicas",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_Musicas_PlaylistID",
                table: "Musicas",
                column: "PlaylistID");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_UsuarioID",
                table: "Playlists",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Musicas");

            migrationBuilder.DropTable(
                name: "Albuns");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
