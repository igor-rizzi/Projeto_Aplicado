using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Data.Mappings
{
    public class UsuarioEmpresaMapping : IEntityTypeConfiguration<UsuarioEmpresa>
    {
        public void Configure(EntityTypeBuilder<UsuarioEmpresa> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Senha).IsRequired();
            builder.Property(u => u.CNPJ).IsRequired();
            builder.Property(u => u.TipoUsuario).IsRequired();
        }
    }
}
