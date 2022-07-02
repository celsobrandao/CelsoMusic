using CelsoMusic.Application.Musica.Service;
using CelsoMusic.Application.Musica.Service.Interfaces;
using CelsoMusic.Application.Usuario.Service;
using CelsoMusic.Application.Usuario.Service.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CelsoMusic.Application
{
    public static class ConfigurationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ConfigurationModule).Assembly);
            services.AddMediatR(typeof(ConfigurationModule).Assembly);

            #region Musica
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IArtistaService, ArtistaService>();
            #endregion

            #region
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            #endregion

            return services;
        }
    }
}
