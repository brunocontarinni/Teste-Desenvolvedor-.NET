using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inscricoes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Leads_CPF",
                table: "Leads",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_NumeroInscricao",
                table: "Inscricoes",
                column: "NumeroInscricao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Leads_CPF",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Inscricoes_NumeroInscricao",
                table: "Inscricoes");
        }
    }
}
