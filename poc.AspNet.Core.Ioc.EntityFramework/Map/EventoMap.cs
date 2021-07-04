using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Ioc.EntityFramework.Map
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("evento");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.DataInicio)
                .IsRequired();

            builder.Property(c => c.DataFinal)
                .IsRequired();

            builder.HasOne(c => c.Calendario)
                .WithMany(f => f.Eventos)
                .HasForeignKey(f => f.IdCalendario)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Organizador)
                .WithMany(f => f.EventosOrganizados)
                .HasForeignKey(f => f.IdOrganizador)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
