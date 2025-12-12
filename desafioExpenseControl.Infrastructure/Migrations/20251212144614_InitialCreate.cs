using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace desafioExpenseControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FINALIDADE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PESSOAS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IDADE = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PESSOAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRANSACOES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DESCRICAO = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    VALOR = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    TIPO = table.Column<int>(type: "INTEGER", nullable: false),
                    DATA_CRIACAO = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    PESSOA_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    CATEGORIA_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRANSACOES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACOES_TB_CATEGORIAS_CATEGORIA_ID",
                        column: x => x.CATEGORIA_ID,
                        principalTable: "TB_CATEGORIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_TRANSACOES_TB_PESSOAS_PESSOA_ID",
                        column: x => x.PESSOA_ID,
                        principalTable: "TB_PESSOAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACOES_CATEGORIA_ID",
                table: "TB_TRANSACOES",
                column: "CATEGORIA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TRANSACOES_PESSOA_ID",
                table: "TB_TRANSACOES",
                column: "PESSOA_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TRANSACOES");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIAS");

            migrationBuilder.DropTable(
                name: "TB_PESSOAS");
        }
    }
}
