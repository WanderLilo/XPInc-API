using API.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Infrastructure.Data.Mappings
{
    public class AdministradorMapping : IEntityTypeConfiguration<Administrador>
    {
        public void Configure(EntityTypeBuilder<Administrador> builder)
        {
            builder.ToTable("Adminstradores");
            builder.HasKey(p => p.Id);
            builder.Property( p => p.Email).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Senha).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Perfil).HasMaxLength(10).IsRequired();
        }
    }
}
