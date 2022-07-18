

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class CargoMapping : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(Constantes.QuantidadeMaximaDeCaracteresParaDescricao);
            builder.Ignore(p => p.ValidationResult);
            builder.Ignore(p => p.CascadeMode);
        }
    }
}
