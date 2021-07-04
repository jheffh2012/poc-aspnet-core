using Microsoft.EntityFrameworkCore;
using poc.AspNet.Core.Ioc.Entities;
using Microsoft.Extensions.Configuration;
using poc.AspNet.Core.Ioc.EntityFramework.Map;

namespace poc.AspNet.Core.Ioc.EntityFramework.Context
{
    public class SqlServerDBContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        
        public SqlServerDBContext(DbContextOptions<SqlServerDBContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Calendario> Calendarios { get; set; }
        public DbSet<EventoConfirmacao> EventoConfirmacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.getConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new EquipeMap());
            modelBuilder.ApplyConfiguration(new CalendarioMap());
            modelBuilder.ApplyConfiguration(new EventoMap());
            modelBuilder.ApplyConfiguration(new EventoConfirmacaoMap());
        }

        internal string getConnectionString() {
            return this._configuration.GetConnectionString("ConexaoDB");
        }
    }
}
