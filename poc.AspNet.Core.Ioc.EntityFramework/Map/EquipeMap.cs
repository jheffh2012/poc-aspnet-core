using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poc.AspNet.Core.Ioc.Entities;

namespace poc.AspNet.Core.Ioc.EntityFramework.Map
{
    public class EquipeMap : IEntityTypeConfiguration<Equipe>
    {

        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("equipe");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
