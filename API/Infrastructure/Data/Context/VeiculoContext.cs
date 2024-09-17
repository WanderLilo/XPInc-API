using API.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using API.ApplicationCore.DTOs;
using API.ApplicationCore.Enums;

namespace API.Infrastructure.Data.Context
{
    public class VeiculoContext: DbContext
    {
        public VeiculoContext(DbContextOptions<VeiculoContext> options): base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Administrador> Administradores { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VeiculoContext).Assembly);

            modelBuilder.Entity<Administrador>().HasData(
                new Administrador()
                {
                    Id = -1,
                    Email = "adminstrador@teste.com.br",
                    Senha = "123456",
                    Perfil = Perfil.adm
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
