using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioCargoMapping : IEntityTypeConfiguration<FuncionarioCargo>
    {
        public void Configure(EntityTypeBuilder<FuncionarioCargo> builder)
        {
            builder.HasKey(p => new { p.CargoId, p.FuncionarioId });
            builder.HasOne(p => p.Cargo)
                .WithMany(p => p.FuncionarioCargo)
                .HasForeignKey(p => p.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Funcionario)
                .WithMany(p => p.FuncionarioCargo)
                .HasForeignKey(p => p.FuncionarioId);
         //   builder.Ignore(p => p.ValidationResult);
         //   builder.Ignore(p => p.CascadeMode);
        }
    }
}
