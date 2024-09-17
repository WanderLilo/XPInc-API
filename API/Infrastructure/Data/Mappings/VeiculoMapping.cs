using API.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Data.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculos");
            builder.HasKey(e => e.Id);
            builder.Property( p => p.Nome).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Marca).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Ano).IsRequired();
        }
    }
}
