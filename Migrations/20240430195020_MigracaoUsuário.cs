using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EsteticaEProcedimentos.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUsuário : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_CLIENTES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Login = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 3,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 4,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 5,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 6,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_CLIENTES",
                keyColumn: "Id",
                keyValue: 7,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "DataAcesso", "Login", "Nome", "PasswordHash", "PasswordSalt", "TipoUsuario" },
                values: new object[] { 1, null, "UsuarioAdmin", "Usuário", new byte[] { 237, 103, 39, 168, 213, 221, 192, 161, 124, 116, 112, 178, 133, 198, 227, 27, 242, 100, 39, 242, 242, 8, 214, 23, 179, 254, 135, 149, 255, 219, 204, 225, 69, 159, 215, 95, 73, 91, 18, 191, 140, 130, 3, 107, 56, 155, 68, 205, 186, 122, 155, 169, 49, 250, 112, 168, 84, 197, 223, 200, 106, 216, 54, 148 }, new byte[] { 214, 3, 205, 206, 33, 201, 218, 115, 137, 22, 169, 97, 245, 96, 171, 245, 251, 52, 188, 200, 177, 2, 83, 46, 212, 104, 49, 7, 26, 150, 110, 254, 72, 74, 223, 193, 86, 24, 6, 207, 54, 210, 250, 227, 22, 70, 21, 122, 201, 56, 154, 148, 8, 201, 223, 206, 110, 251, 163, 241, 229, 209, 38, 12, 139, 151, 147, 249, 123, 195, 166, 191, 65, 40, 155, 62, 151, 183, 238, 138, 203, 180, 136, 74, 46, 142, 64, 223, 142, 244, 176, 244, 222, 145, 206, 146, 97, 249, 186, 79, 45, 252, 43, 101, 145, 52, 249, 161, 23, 18, 235, 198, 55, 126, 5, 57, 74, 250, 160, 71, 93, 238, 173, 55, 235, 212, 80, 49 }, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CLIENTES_UsuarioId",
                table: "TB_CLIENTES",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CLIENTES_TB_USUARIOS_UsuarioId",
                table: "TB_CLIENTES",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CLIENTES_TB_USUARIOS_UsuarioId",
                table: "TB_CLIENTES");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_CLIENTES_UsuarioId",
                table: "TB_CLIENTES");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_CLIENTES");
        }
    }
}
