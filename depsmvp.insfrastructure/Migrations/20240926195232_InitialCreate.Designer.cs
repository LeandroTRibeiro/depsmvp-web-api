﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using depsmvp.insfrastructure.DB;

#nullable disable

namespace depsmvp.insfrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240926195232_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("depsmvp.domain.Entities.Company.CnaesSecundario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Codigo")
                        .HasColumnType("integer");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("CnaesSecundarios");
                });

            modelBuilder.Entity("depsmvp.domain.Entities.Company.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .HasColumnType("text");

                    b.Property<int?>("CapitalSocial")
                        .HasColumnType("integer");

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<int?>("CnaeFiscal")
                        .HasColumnType("integer");

                    b.Property<string>("CnaeFiscalDescricao")
                        .HasColumnType("text");

                    b.Property<string>("Cnpj")
                        .HasColumnType("text");

                    b.Property<int?>("CodigoMunicipio")
                        .HasColumnType("integer");

                    b.Property<int?>("CodigoNaturezaJuridica")
                        .HasColumnType("integer");

                    b.Property<string>("Complemento")
                        .HasColumnType("text");

                    b.Property<string>("DataExclusaoDoSimples")
                        .HasColumnType("text");

                    b.Property<string>("DataInicioAtividade")
                        .HasColumnType("text");

                    b.Property<string>("DataOpcaoPeloSimples")
                        .HasColumnType("text");

                    b.Property<string>("DataSituacaoCadastral")
                        .HasColumnType("text");

                    b.Property<string>("DataSituacaoEspecial")
                        .HasColumnType("text");

                    b.Property<string>("DddFax")
                        .HasColumnType("text");

                    b.Property<string>("DddTelefone1")
                        .HasColumnType("text");

                    b.Property<string>("DddTelefone2")
                        .HasColumnType("text");

                    b.Property<string>("DescricaoMatrizFilial")
                        .HasColumnType("text");

                    b.Property<string>("DescricaoPorte")
                        .HasColumnType("text");

                    b.Property<string>("DescricaoSituacaoCadastral")
                        .HasColumnType("text");

                    b.Property<string>("DescricaoTipoDeLogradouro")
                        .HasColumnType("text");

                    b.Property<int?>("IdentificadorMatrizFilial")
                        .HasColumnType("integer");

                    b.Property<string>("Logradouro")
                        .HasColumnType("text");

                    b.Property<int?>("MotivoSituacaoCadastral")
                        .HasColumnType("integer");

                    b.Property<string>("Municipio")
                        .HasColumnType("text");

                    b.Property<string>("NomeCidadeExterior")
                        .HasColumnType("text");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<bool>("OpcaoPeloMei")
                        .HasColumnType("boolean");

                    b.Property<bool>("OpcaoPeloSimples")
                        .HasColumnType("boolean");

                    b.Property<string>("Porte")
                        .HasColumnType("text");

                    b.Property<int?>("QualificacaoDoResponsavel")
                        .HasColumnType("integer");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text");

                    b.Property<DateTime>("SearchDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("SituacaoCadastral")
                        .HasColumnType("integer");

                    b.Property<string>("SituacaoEspecial")
                        .HasColumnType("text");

                    b.Property<string>("Uf")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("depsmvp.domain.Entities.Company.Qsa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CnpjCpfDoSocio")
                        .HasColumnType("text");

                    b.Property<int?>("CodigoQualificacaoRepresentanteLegal")
                        .HasColumnType("integer");

                    b.Property<int?>("CodigoQualificacaoSocio")
                        .HasColumnType("integer");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("CpfRepresentanteLegal")
                        .HasColumnType("text");

                    b.Property<string>("DataEntradaSociedade")
                        .HasColumnType("text");

                    b.Property<int?>("IdentificadorDeSocio")
                        .HasColumnType("integer");

                    b.Property<string>("NomeRepresentanteLegal")
                        .HasColumnType("text");

                    b.Property<string>("NomeSocio")
                        .HasColumnType("text");

                    b.Property<int?>("PercentualCapitalSocial")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Qsas");
                });

            modelBuilder.Entity("depsmvp.domain.Entities.Company.CnaesSecundario", b =>
                {
                    b.HasOne("depsmvp.domain.Entities.Company.Company", "Company")
                        .WithMany("CnaesSecundarios")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("depsmvp.domain.Entities.Company.Qsa", b =>
                {
                    b.HasOne("depsmvp.domain.Entities.Company.Company", "Company")
                        .WithMany("Qsa")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("depsmvp.domain.Entities.Company.Company", b =>
                {
                    b.Navigation("CnaesSecundarios");

                    b.Navigation("Qsa");
                });
#pragma warning restore 612, 618
        }
    }
}
