using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Ioc.EntityFramework.Map
{
    class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Apelido)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.Setor)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.DDD)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(9);

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(c => c.Equipe)
                .WithMany(f => f.Usuarios)
                .HasForeignKey(f => f.IdEquipe);
        }
    }
}

