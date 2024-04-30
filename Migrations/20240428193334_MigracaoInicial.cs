using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EsteticaEProcedimentos.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Telefone = table.Column<long>(type: "bigint", nullable: false),
                    Endereço = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PROCEDIMENTOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Descriçao = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ValorProcedimento = table.Column<double>(type: "float", nullable: false),
                    DataInicioProcedimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfissionalResponsavel = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROCEDIMENTOS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_CLIENTES",
                columns: new[] { "Id", "CPF", "Email", "Endereço", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "243.567.431-10", "amandasilva123@gmail.com", "Rua das Orquídeas, 295 - Morumbi", "Amanda da Silva", 11965843278L },
                    { 2, "189.298.674-23", "MaduOliveira@hotmail.com", "Rua Maria Cândida, 728 - Casa 2 - Vila Guilherme", "Maria Eduarda Oliveira", 11948291640L },
                    { 3, "368.583.783-79", "silvaelisa2297@gmail.com", "Rua Olavo Egídio, 469 - Santana", "Elisa de Souza Santos", 11987953869L },
                    { 4, "474.973.864-84", "lucianaalmeida9@hotmail.com", "Av. General Ataliba Leonel, 2034 - Parada Inglesa", "Luciana Almeida", 11938596036L },
                    { 5, "282.684.290-19", "fernanda23antunes@gmail.com", "Rua da Gávea, 55 - Vila Maria", "Fernanda Antunes", 11910384874L },
                    { 6, "173.183.286-57", "andressaferreira79@hotmail.com", "Rua Jacuna, 226 - Carandiru", "Andressa Ferreira", 11928462967L },
                    { 7, "372.293.480-48", "analulisboa1011@outlook.com", "Av. Coronel Sezefredo Fagundes, 2847, apto. 210 - Tremembé", "Ana Luiza Lisboa", 11949687931L }
                });

            migrationBuilder.InsertData(
                table: "TB_PROCEDIMENTOS",
                columns: new[] { "Id", "DataInicioProcedimento", "Descriçao", "Nome", "ProfissionalResponsavel", "ValorProcedimento" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Massagem local que pode ser realizada em diversas partes do corpo.", "Drenagem Linfática", "Sonia", 149.99000000000001 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpeza facial com utilização de produtos, retira impurezas da pele.", "Limpeza de Pele", "Solange", 119.98999999999999 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aparelho que utiliza da rádiofrequência para reduzir flacidez corporal.", "Rádio Frequência", "Sonia", 99.989999999999995 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aparelho de ultrassom utilizado para reduzir gordura localizada.", "Cavitação", "Solange", 89.989999999999995 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CLIENTES");

            migrationBuilder.DropTable(
                name: "TB_PROCEDIMENTOS");
        }
    }
}
