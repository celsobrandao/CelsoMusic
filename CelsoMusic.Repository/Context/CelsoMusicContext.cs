using Microsoft.EntityFrameworkCore;

namespace CelsoMusic.Repository.Context
{
    public class CelsoMusicContext : DbContext
    {
        public CelsoMusicContext(DbContextOptions<CelsoMusicContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CelsoMusicContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
