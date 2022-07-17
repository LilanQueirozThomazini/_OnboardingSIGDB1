﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnboardingSIGDB1.Data;

namespace OnboardingSIGDB1.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataFundacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataContratacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.FuncionarioCargo", b =>
                {
                    b.Property<int>("CargoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataVinculo")
                        .HasColumnType("TEXT");

                    b.HasKey("CargoId", "FuncionarioId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FuncionariosCargos");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("OnboardingSIGDB1.Domain.Entities.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.FuncionarioCargo", b =>
                {
                    b.HasOne("OnboardingSIGDB1.Domain.Entities.Cargo", "Cargo")
                        .WithMany("FuncionarioCargo")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnboardingSIGDB1.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("FuncionarioCargo")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Cargo", b =>
                {
                    b.Navigation("FuncionarioCargo");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Empresa", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("OnboardingSIGDB1.Domain.Entities.Funcionario", b =>
                {
                    b.Navigation("FuncionarioCargo");
                });
#pragma warning restore 612, 618
        }
    }
}
