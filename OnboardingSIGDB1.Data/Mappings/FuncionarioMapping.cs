using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Utils;

namespace OnboardingSIGDB1.Data.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(Constantes.QuantidadeMaximaDeCaracteresParaNome);
            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasMaxLength(11);
            builder.HasOne(p => p.Empresa)
                .WithMany(p => p.Funcionarios)
                .HasForeignKey(p => p.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
           // builder.Ignore(p => p.ValidationResult);
           // builder.Ignore(p => p.CascadeMode);
        }
    }
}
