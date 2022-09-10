using CelsoMusic.Application;
using CelsoMusic.Domain.Musica.Repository;
using CelsoMusic.Domain.Usuario.Repository;
using CelsoMusic.Infra.Repository;
using CelsoMusic.Infra.Storage;
using CelsoMusic.Infra.Storage.Interfaces;
using CelsoMusic.Repository;
using CelsoMusic.Repository.Context;
using CelsoMusic.Repository.Database;
using CelsoMusic.Repository.Repository.Musica;
using CelsoMusic.Repository.Repository.Usuario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("CelsoMusic"));

builder.Services.AddDbContext<CelsoMusicContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("CelsoMusic"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

#region Musica
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistaRepository, ArtistaRepository>();
builder.Services.AddScoped<IMusicaRepository, MusicaRepository>();
#endregion

#region Usuario
builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion

builder.Services.AddScoped<IStorage, Storage>();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
