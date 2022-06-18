using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Usuario.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using CelsoMusic.Repository.Repository.Musica;
using CelsoMusic.Repository.Repository.Usuario;
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
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IMusicaRepository, MusicaRepository>();
            #endregion

            #region Usuario
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            #endregion

            return services;
        }
    }
}
