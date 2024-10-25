using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace depsmvp.insfrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SearchDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cnpj = table.Column<string>(type: "text", nullable: true),
                    IdentificadorMatrizFilial = table.Column<int>(type: "integer", nullable: true),
                    DescricaoMatrizFilial = table.Column<string>(type: "text", nullable: true),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    NomeFantasia = table.Column<string>(type: "text", nullable: true),
                    SituacaoCadastral = table.Column<int>(type: "integer", nullable: true),
                    DescricaoSituacaoCadastral = table.Column<string>(type: "text", nullable: true),
                    DataSituacaoCadastral = table.Column<string>(type: "text", nullable: true),
                    MotivoSituacaoCadastral = table.Column<int>(type: "integer", nullable: true),
                    NomeCidadeExterior = table.Column<string>(type: "text", nullable: true),
                    CodigoNaturezaJuridica = table.Column<int>(type: "integer", nullable: true),
                    DataInicioAtividade = table.Column<string>(type: "text", nullable: true),
                    CnaeFiscal = table.Column<int>(type: "integer", nullable: true),
                    CnaeFiscalDescricao = table.Column<string>(type: "text", nullable: true),
                    DescricaoTipoDeLogradouro = table.Column<string>(type: "text", nullable: true),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Uf = table.Column<string>(type: "text", nullable: true),
                    CodigoMunicipio = table.Column<int>(type: "integer", nullable: true),
                    Municipio = table.Column<string>(type: "text", nullable: true),
                    DddTelefone1 = table.Column<string>(type: "text", nullable: true),
                    DddTelefone2 = table.Column<string>(type: "text", nullable: true),
                    DddFax = table.Column<string>(type: "text", nullable: true),
                    QualificacaoDoResponsavel = table.Column<int>(type: "integer", nullable: true),
                    CapitalSocial = table.Column<int>(type: "integer", nullable: true),
                    Porte = table.Column<string>(type: "text", nullable: true),
                    DescricaoPorte = table.Column<string>(type: "text", nullable: true),
                    OpcaoPeloSimples = table.Column<bool>(type: "boolean", nullable: true),
                    DataOpcaoPeloSimples = table.Column<string>(type: "text", nullable: true),
                    DataExclusaoDoSimples = table.Column<string>(type: "text", nullable: true),
                    OpcaoPeloMei = table.Column<bool>(type: "boolean", nullable: true),
                    SituacaoEspecial = table.Column<string>(type: "text", nullable: true),
                    DataSituacaoEspecial = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SearchDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    SiglaFuncao = table.Column<string>(type: "text", nullable: true),
                    DescricaoFuncao = table.Column<string>(type: "text", nullable: true),
                    NivelFuncao = table.Column<string>(type: "text", nullable: true),
                    CodOrgao = table.Column<string>(type: "text", nullable: true),
                    NomeOrgao = table.Column<string>(type: "text", nullable: true),
                    DtInicioExercicio = table.Column<string>(type: "text", nullable: true),
                    DtFimExercicio = table.Column<string>(type: "text", nullable: true),
                    DtFimCarencia = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CnaesSecundarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<int>(type: "integer", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CnaesSecundarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CnaesSecundarios_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qsas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentificadorDeSocio = table.Column<int>(type: "integer", nullable: true),
                    NomeSocio = table.Column<string>(type: "text", nullable: true),
                    CnpjCpfDoSocio = table.Column<string>(type: "text", nullable: true),
                    CodigoQualificacaoSocio = table.Column<int>(type: "integer", nullable: true),
                    PercentualCapitalSocial = table.Column<int>(type: "integer", nullable: true),
                    DataEntradaSociedade = table.Column<string>(type: "text", nullable: true),
                    CpfRepresentanteLegal = table.Column<string>(type: "text", nullable: true),
                    NomeRepresentanteLegal = table.Column<string>(type: "text", nullable: true),
                    CodigoQualificacaoRepresentanteLegal = table.Column<int>(type: "integer", nullable: true),
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qsas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qsas_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ConsultationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConsultationType = table.Column<string>(type: "text", nullable: true),
                    ConsultationCode = table.Column<string>(type: "text", nullable: true),
                    ConsultationDateReference = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ConsultationInterval = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyConsults",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    ConsultationId = table.Column<int>(type: "integer", nullable: false),
                    AssociatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyConsults", x => new { x.CompanyId, x.ConsultationId });
                    table.ForeignKey(
                        name: "FK_CompanyConsults_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyConsults_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PepConsults",
                columns: table => new
                {
                    PepId = table.Column<int>(type: "integer", nullable: false),
                    ConsultationId = table.Column<int>(type: "integer", nullable: false),
                    AssociatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PepConsults", x => new { x.PepId, x.ConsultationId });
                    table.ForeignKey(
                        name: "FK_PepConsults_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PepConsults_Peps_PepId",
                        column: x => x.PepId,
                        principalTable: "Peps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CnaesSecundarios_CompanyId",
                table: "CnaesSecundarios",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyConsults_ConsultationId",
                table: "CompanyConsults",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_UserId",
                table: "Consultations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PepConsults_ConsultationId",
                table: "PepConsults",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Qsas_CompanyId",
                table: "Qsas",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CnaesSecundarios");

            migrationBuilder.DropTable(
                name: "CompanyConsults");

            migrationBuilder.DropTable(
                name: "PepConsults");

            migrationBuilder.DropTable(
                name: "Qsas");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Peps");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
