using Microsoft.EntityFrameworkCore;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Data.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
    }
}
