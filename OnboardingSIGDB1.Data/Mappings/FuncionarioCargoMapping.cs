using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioCargoMapping : IEntityTypeConfiguration<FuncionarioCargo>
    {
        public void Configure(EntityTypeBuilder<FuncionarioCargo> builder)
        {
            builder.HasKey(x => new { x.CargoId, x.FuncionarioId });
            builder.HasOne(x => x.Cargo)
                .WithMany(x => x.FuncionarioCargo)
                .HasForeignKey(x => x.CargoId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Funcionario)
                .WithMany(x => x.FuncionarioCargo)
                .HasForeignKey(x => x.FuncionarioId);
            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.CascadeMode);
        }
    }
}
