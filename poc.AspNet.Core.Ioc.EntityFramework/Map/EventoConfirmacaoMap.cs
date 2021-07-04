using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Ioc.EntityFramework.Map
{
    public class EventoConfirmacaoMap : IEntityTypeConfiguration<EventoConfirmacao>
    {
        public void Configure(EntityTypeBuilder<EventoConfirmacao> builder)
        {
            builder.ToTable("confirmacao");
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Evento)
                .WithMany(f => f.Confirmacoes)
                .HasForeignKey(f => f.IdEvento);

            builder.HasOne(c => c.Usuario)
                .WithMany(f => f.Confirmacoes)
                .HasForeignKey(f => f.IdUsuario);
        }
    }
}
