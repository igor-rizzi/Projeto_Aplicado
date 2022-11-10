using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(u => u.User).IsRequired();
            builder.Property(u => u.UserEmail).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.TipoUsuario).IsRequired();
        }
    }
}
