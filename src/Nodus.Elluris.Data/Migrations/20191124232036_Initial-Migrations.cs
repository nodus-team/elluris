using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nodus.Elluris.Data.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beacons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    BeaconCode = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beacons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    DataInicial = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPaciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObraEventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    Id_Obra = table.Column<int>(nullable: false),
                    Id_Evento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObraEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    Observacao = table.Column<string>(type: "varchar(100)", nullable: true),
                    UrlFoto = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    EventoPeriodoId = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: false),
                    Observacao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evento_EstadoPaciente_EventoPeriodoId",
                        column: x => x.EventoPeriodoId,
                        principalTable: "EstadoPaciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BeaconObras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    BeaconId = table.Column<Guid>(nullable: true),
                    ObraId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeaconObras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeaconObras_Beacons_BeaconId",
                        column: x => x.BeaconId,
                        principalTable: "Beacons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BeaconObras_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeaconObras_BeaconId",
                table: "BeaconObras",
                column: "BeaconId");

            migrationBuilder.CreateIndex(
                name: "IX_BeaconObras_ObraId",
                table: "BeaconObras",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Evento_EventoPeriodoId",
                table: "Evento",
                column: "EventoPeriodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeaconObras");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "ObraEventos");

            migrationBuilder.DropTable(
                name: "Beacons");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "EstadoPaciente");
        }
    }
}
