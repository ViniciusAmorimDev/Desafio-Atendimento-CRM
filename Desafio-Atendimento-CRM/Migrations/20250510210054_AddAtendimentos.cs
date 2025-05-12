using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio_Atendimento_CRM.Migrations
{
    /// <inheritdoc />
    public partial class AddAtendimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ClientePF",
                newName: "ClientePfId");

            migrationBuilder.AddColumn<int>(
                name: "AtendimentosId",
                table: "ClientePF",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuariosId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuariosId);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    AtendimentosId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuariosId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.AtendimentosId);
                    table.ForeignKey(
                        name: "FK_Atendimentos_ClientePF_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "ClientePF",
                        principalColumn: "ClientePfId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pareceres",
                columns: table => new
                {
                    PareceresId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    AtendimentosId = table.Column<int>(type: "integer", nullable: false),
                    UsuariosId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pareceres", x => x.PareceresId);
                    table.ForeignKey(
                        name: "FK_Pareceres_Atendimentos_AtendimentosId",
                        column: x => x.AtendimentosId,
                        principalTable: "Atendimentos",
                        principalColumn: "AtendimentosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pareceres_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ClienteId",
                table: "Atendimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_UsuariosId",
                table: "Atendimentos",
                column: "UsuariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pareceres_AtendimentosId",
                table: "Pareceres",
                column: "AtendimentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Pareceres_UsuariosId",
                table: "Pareceres",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pareceres");

            migrationBuilder.DropTable(
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AtendimentosId",
                table: "ClientePF");

            migrationBuilder.RenameColumn(
                name: "ClientePfId",
                table: "ClientePF",
                newName: "Id");
        }
    }
}
