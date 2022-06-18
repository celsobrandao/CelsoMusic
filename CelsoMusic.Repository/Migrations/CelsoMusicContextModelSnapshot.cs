﻿// <auto-generated />
using System;
using CelsoMusic.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CelsoMusic.Repository.Migrations
{
    [DbContext(typeof(CelsoMusicContext))]
    partial class CelsoMusicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Album", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ArtistaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("ArtistaID");

                    b.ToTable("Albuns", (string)null);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Artista", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Artistas", (string)null);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Genero", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Generos", (string)null);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Musica", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Audio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.HasIndex("AlbumID");

                    b.ToTable("Musicas", (string)null);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Usuario.Playlist", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("UsuarioID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Playlists", (string)null);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Usuario.Usuario", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UltimaMusicaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UltimaMusicaTempo")
                        .HasColumnType("int");

                    b.Property<Guid>("UltimaPlaylistID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("GeneroMusica", b =>
                {
                    b.Property<Guid>("GenerosID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicasID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenerosID", "MusicasID");

                    b.HasIndex("MusicasID");

                    b.ToTable("GeneroMusica");
                });

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.Property<Guid>("MusicasID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaylistsID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MusicasID", "PlaylistsID");

                    b.HasIndex("PlaylistsID");

                    b.ToTable("MusicaPlaylist");
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Album", b =>
                {
                    b.HasOne("CelsoMusic.Domain.Musica.Artista", null)
                        .WithMany("Albuns")
                        .HasForeignKey("ArtistaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Musica", b =>
                {
                    b.HasOne("CelsoMusic.Domain.Musica.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("CelsoMusic.Domain.Musica.ValueObject.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("Duracao");

                            b1.HasKey("MusicaID");

                            b1.ToTable("Musicas");

                            b1.WithOwner()
                                .HasForeignKey("MusicaID");
                        });

                    b.Navigation("Duracao");
                });

            modelBuilder.Entity("CelsoMusic.Domain.Usuario.Playlist", b =>
                {
                    b.HasOne("CelsoMusic.Domain.Usuario.Usuario", null)
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CelsoMusic.Domain.Usuario.Usuario", b =>
                {
                    b.OwnsOne("CelsoMusic.Domain.Usuario.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioID");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioID");
                        });

                    b.OwnsOne("CelsoMusic.Domain.Usuario.ValueObject.Senha", "Senha", b1 =>
                        {
                            b1.Property<Guid>("UsuarioID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Senha");

                            b1.HasKey("UsuarioID");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioID");
                        });

                    b.Navigation("Email");

                    b.Navigation("Senha");
                });

            modelBuilder.Entity("GeneroMusica", b =>
                {
                    b.HasOne("CelsoMusic.Domain.Musica.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CelsoMusic.Domain.Musica.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.HasOne("CelsoMusic.Domain.Musica.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CelsoMusic.Domain.Usuario.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("CelsoMusic.Domain.Musica.Artista", b =>
                {
                    b.Navigation("Albuns");
                });

            modelBuilder.Entity("CelsoMusic.Domain.Usuario.Usuario", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
