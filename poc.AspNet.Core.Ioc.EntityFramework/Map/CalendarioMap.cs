using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Ioc.EntityFramework.Map
{
    public class CalendarioMap : IEntityTypeConfiguration<Calendario>
    {
        public void Configure(EntityTypeBuilder<Calendario> builder)
        {
            builder.ToTable("calendario");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(c => c.Equipe)
                .WithMany(f => f.Calendarios)
                .HasForeignKey(f => f.IdEquipe);
        }
    }
}
