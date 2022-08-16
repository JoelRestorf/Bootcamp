using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dados.Migrations
{
    public partial class InitialCriate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fonte = table.Column<string>(type: "varchar(100)", nullable: false),
                    Autor = table.Column<string>(type: "varchar(100)", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(250)", nullable: false),
                    URL = table.Column<string>(type: "varchar(250)", nullable: false),
                    ImagemURL = table.Column<string>(type: "varchar(250)", nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(300)", nullable: false),
                    Positiva = table.Column<bool>(type: "bit", nullable: false),
                    Negativa = table.Column<bool>(type: "bit", nullable: false),
                    Neutra = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Noticias");
        }
    }
}
