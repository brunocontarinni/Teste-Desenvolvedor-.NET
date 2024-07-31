using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vestibular_info.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Leads",
                columns: new[] { "Id", "CPF", "Email", "Nome", "Telefone" },
                values: new object[] { 1, "12345678901", "joao.silva@example.com", "João Silva", "123456789" });

            migrationBuilder.InsertData(
                table: "Ofertas",
                columns: new[] { "Id", "Descricao", "Nome", "VagasDisponiveis" },
                values: new object[] { 1, "Curso de Engenharia de Software", "Engenharia de Software", 50 });

            migrationBuilder.InsertData(
                table: "ProcessosSeletivos",
                columns: new[] { "Id", "DataInicio", "DataTermino", "Nome" },
                values: new object[] { 1, new DateTime(2024, 7, 30, 22, 0, 54, 892, DateTimeKind.Local).AddTicks(72), new DateTime(2024, 8, 30, 22, 0, 54, 892, DateTimeKind.Local).AddTicks(93), "Vestibular 2024" });

            migrationBuilder.InsertData(
                table: "Inscricoes",
                columns: new[] { "Id", "Data", "LeadId", "NumeroInscricao", "OfertaId", "ProcessoSeletivoId", "Status" },
                values: new object[] { 1, new DateTime(2024, 7, 30, 22, 0, 54, 892, DateTimeKind.Local).AddTicks(731), 1, "20240001", 1, 1, "Pendente" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inscricoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leads",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ofertas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProcessosSeletivos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
