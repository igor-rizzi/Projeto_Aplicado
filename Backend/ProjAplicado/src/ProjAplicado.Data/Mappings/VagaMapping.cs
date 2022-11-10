using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Data.Mappings
{
    public class VagaMapping : IEntityTypeConfiguration<Vaga>
    {
        public void Configure(EntityTypeBuilder<Vaga> builder)
        {
            builder.Property(v => v.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(v => v.Descricao).IsRequired();
            builder.Property(v => v.Salario).IsRequired();
        }
    }
}