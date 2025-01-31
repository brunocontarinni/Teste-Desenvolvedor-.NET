using Microsoft.EntityFrameworkCore.Migrations;

namespace VestTest.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_OfertasCursos_OfertaCursoId",
                table: "Inscricoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfertasCursos",
                table: "OfertasCursos");

            migrationBuilder.RenameTable(
                name: "OfertasCursos",
                newName: "OfertaCursos");

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Inscricoes",
                type: "tinyint(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfertaCursos",
                table: "OfertaCursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_OfertaCursos_OfertaCursoId",
                table: "Inscricoes",
                column: "OfertaCursoId",
                principalTable: "OfertaCursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscricoes_OfertaCursos_OfertaCursoId",
                table: "Inscricoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfertaCursos",
                table: "OfertaCursos");

            migrationBuilder.RenameTable(
                name: "OfertaCursos",
                newName: "OfertasCursos");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Inscricoes",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfertasCursos",
                table: "OfertasCursos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscricoes_OfertasCursos_OfertaCursoId",
                table: "Inscricoes",
                column: "OfertaCursoId",
                principalTable: "OfertasCursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
