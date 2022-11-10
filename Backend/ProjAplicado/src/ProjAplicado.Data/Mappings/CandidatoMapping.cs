using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAplicado.Business.Models;

namespace ProjAplicado.Data.Mappings
{
    public class CandidatoMapping : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.Property(c => c.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Sobrenome).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.DataNascimento).IsRequired();
            builder.Property(c => c.Telefone).IsRequired();
            builder.Property(c => c.Habilidades).IsRequired();
            builder.Property(c => c.Objetivo).IsRequired();
            builder.Property(c => c.TipoFormacao).IsRequired();
            builder.Property(c => c.Idiomas).IsRequired();
            builder.Property(c => c.AnosExperiencia).IsRequired();
        }
    }
}
