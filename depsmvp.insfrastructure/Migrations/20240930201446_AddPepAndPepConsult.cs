using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace depsmvp.insfrastructure.Migrations
{
    public partial class AddPepAndPepConsult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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
                name: "PepConsults",
                columns: table => new
                {
                    PepId = table.Column<int>(type: "integer", nullable: false),
                    ConsultId = table.Column<int>(type: "integer", nullable: false),
                    AssociatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PepConsults", x => new { x.PepId, x.ConsultId });
                    table.ForeignKey(
                        name: "FK_PepConsults_Consults_ConsultId",
                        column: x => x.ConsultId,
                        principalTable: "Consults",
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
                name: "IX_PepConsults_ConsultId",
                table: "PepConsults",
                column: "ConsultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PepConsults");

            migrationBuilder.DropTable(
                name: "Peps");
        }
    }
}
