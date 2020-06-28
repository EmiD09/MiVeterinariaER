using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiVeterinaria.Web.Migrations
{
    public partial class CompleteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telFijo",
                table: "Propietarios",
                newName: "TelFijo");

            migrationBuilder.RenameColumn(
                name: "telCelular",
                table: "Propietarios",
                newName: "TelCelular");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Propietarios",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "documento",
                table: "Propietarios",
                newName: "Documento");

            migrationBuilder.RenameColumn(
                name: "direccion",
                table: "Propietarios",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "apellido",
                table: "Propietarios",
                newName: "Apellido");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Propietarios",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "TipoMascotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMascotas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoServicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoServicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    ImagenUrl = table.Column<string>(nullable: true),
                    Raza = table.Column<string>(maxLength: 50, nullable: true),
                    Nacimiento = table.Column<DateTime>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    TipoMascotaId = table.Column<int>(nullable: true),
                    PropietarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_TipoMascotas_TipoMascotaId",
                        column: x => x.TipoMascotaId,
                        principalTable: "TipoMascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    EstaDisponible = table.Column<bool>(nullable: false),
                    PropietarioId = table.Column<int>(nullable: true),
                    MascotaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agendas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Agendas_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<int>(maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    TipoServicioId = table.Column<int>(nullable: true),
                    MascotaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Historias_TipoServicios_TipoServicioId",
                        column: x => x.TipoServicioId,
                        principalTable: "TipoServicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_MascotaId",
                table: "Agendas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendas_PropietarioId",
                table: "Agendas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_MascotaId",
                table: "Historias",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_TipoServicioId",
                table: "Historias",
                column: "TipoServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_PropietarioId",
                table: "Mascotas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_TipoMascotaId",
                table: "Mascotas",
                column: "TipoMascotaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "TipoServicios");

            migrationBuilder.DropTable(
                name: "TipoMascotas");

            migrationBuilder.RenameColumn(
                name: "TelFijo",
                table: "Propietarios",
                newName: "telFijo");

            migrationBuilder.RenameColumn(
                name: "TelCelular",
                table: "Propietarios",
                newName: "telCelular");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Propietarios",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Propietarios",
                newName: "documento");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Propietarios",
                newName: "direccion");

            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Propietarios",
                newName: "apellido");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Propietarios",
                newName: "id");
        }
    }
}
