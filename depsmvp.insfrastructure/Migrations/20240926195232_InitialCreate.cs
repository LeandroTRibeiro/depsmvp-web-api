using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace depsmvp.insfrastructure.Migrations
{
    public partial class InitialCreate : Migration
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
                    OpcaoPeloSimples = table.Column<bool>(type: "boolean", nullable: false),
                    DataOpcaoPeloSimples = table.Column<string>(type: "text", nullable: true),
                    DataExclusaoDoSimples = table.Column<string>(type: "text", nullable: true),
                    OpcaoPeloMei = table.Column<bool>(type: "boolean", nullable: false),
                    SituacaoEspecial = table.Column<string>(type: "text", nullable: true),
                    DataSituacaoEspecial = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_CnaesSecundarios_CompanyId",
                table: "CnaesSecundarios",
                column: "CompanyId");

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
                name: "Qsas");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
