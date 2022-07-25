using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {

        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.QuantidadeMaximaDeCaracteresParaNome);
            builder.Property(x => x.Cnpj)
                .IsRequired()
                .HasMaxLength(Constantes.QuantidadeMaximaDeCaracteresParaCNPJ);
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}
