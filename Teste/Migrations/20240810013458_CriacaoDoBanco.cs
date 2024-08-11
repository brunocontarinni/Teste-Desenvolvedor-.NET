using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    IdLead = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.IdLead);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    IdOferta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.IdOferta);
                });

            migrationBuilder.CreateTable(
                name: "ProcessosSeletivos",
                columns: table => new
                {
                    IdProcessoSeletivo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeTermino = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessosSeletivos", x => x.IdProcessoSeletivo);
                });

            migrationBuilder.CreateTable(
                name: "Inscricoes",
                columns: table => new
                {
                    IdInscricao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdLead = table.Column<int>(type: "int", nullable: true),
                    IdOferta = table.Column<int>(type: "int", nullable: true),
                    IdProcessoSeletivo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscricoes", x => x.IdInscricao);
                    table.ForeignKey(
                        name: "FK_Inscricoes_Leads_IdLead",
                        column: x => x.IdLead,
                        principalTable: "Leads",
                        principalColumn: "IdLead");
                    table.ForeignKey(
                        name: "FK_Inscricoes_Ofertas_IdOferta",
                        column: x => x.IdOferta,
                        principalTable: "Ofertas",
                        principalColumn: "IdOferta");
                    table.ForeignKey(
                        name: "FK_Inscricoes_ProcessosSeletivos_IdProcessoSeletivo",
                        column: x => x.IdProcessoSeletivo,
                        principalTable: "ProcessosSeletivos",
                        principalColumn: "IdProcessoSeletivo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_IdLead",
                table: "Inscricoes",
                column: "IdLead");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_IdOferta",
                table: "Inscricoes",
                column: "IdOferta");

            migrationBuilder.CreateIndex(
                name: "IX_Inscricoes_IdProcessoSeletivo",
                table: "Inscricoes",
                column: "IdProcessoSeletivo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscricoes");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "ProcessosSeletivos");
        }
    }
}
