using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Playlist.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using CelsoMusic.Repository.Repository.Musica;
using CelsoMusic.Repository.Repository.Playlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CelsoMusic.Repository
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CelsoMusicContext>(c =>
            {
                c.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(Repository<>));

            #region Musica
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IArtistaRepository, ArtistaRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            #endregion

            #region Playlist
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            #endregion

            return services;
        }
    }
}
