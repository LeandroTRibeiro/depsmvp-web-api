using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace depsmvp.insfrastructure.Migrations
{
    public partial class ChangePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Peps",
                newName: "SearchDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SearchDate",
                table: "Peps",
                newName: "Date");
        }
    }
}
