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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.QuantidadeMaximaDeCaracteresParaNome);
            builder.Property(p => p.Cnpj)
                .IsRequired()
                .HasMaxLength(Constantes.QuantidadeMaximaDeCaracteresParaCNPJ);
            //builder.Ignore(p => p.ValidationResult);
            //builder.Ignore(p => p.CascadeMode);
        }
    }
}
