using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace poc.AspNet.Core.Ioc.EntityFramework.Migrations
{
    public partial class MigratioInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "calendario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calendario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calendario_equipe_IdEquipe",
                        column: x => x.IdEquipe,
                        principalTable: "equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apelido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DDD = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdEquipe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_equipe_IdEquipe",
                        column: x => x.IdEquipe,
                        principalTable: "equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "evento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOrganizador = table.Column<int>(type: "int", nullable: false),
                    IdCalendario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_evento_calendario_IdCalendario",
                        column: x => x.IdCalendario,
                        principalTable: "calendario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_evento_usuario_IdOrganizador",
                        column: x => x.IdOrganizador,
                        principalTable: "usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "confirmacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEvento = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_confirmacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_confirmacao_evento_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_confirmacao_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_calendario_IdEquipe",
                table: "calendario",
                column: "IdEquipe");

            migrationBuilder.CreateIndex(
                name: "IX_confirmacao_IdEvento",
                table: "confirmacao",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_confirmacao_IdUsuario",
                table: "confirmacao",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_evento_IdCalendario",
                table: "evento",
                column: "IdCalendario");

            migrationBuilder.CreateIndex(
                name: "IX_evento_IdOrganizador",
                table: "evento",
                column: "IdOrganizador");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdEquipe",
                table: "usuario",
                column: "IdEquipe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "confirmacao");

            migrationBuilder.DropTable(
                name: "evento");

            migrationBuilder.DropTable(
                name: "calendario");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "equipe");
        }
    }
}
