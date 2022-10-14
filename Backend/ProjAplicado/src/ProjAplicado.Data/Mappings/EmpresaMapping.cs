using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.RazaoSocial).IsRequired();
            builder.Property(e => e.Visoes);
            builder.Property(e => e.Valores);
            builder.Property(e => e.Missoes);
            builder.Property(e => e.Descricao);
            builder.Property(e => e.CNPJ).IsRequired();
        }
    }
}
