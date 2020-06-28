using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiVeterinaria.Web.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    documento = table.Column<string>(maxLength: 30, nullable: false),
                    nombre = table.Column<string>(maxLength: 50, nullable: false),
                    apellido = table.Column<string>(maxLength: 50, nullable: false),
                    telFijo = table.Column<string>(maxLength: 20, nullable: true),
                    telCelular = table.Column<string>(maxLength: 20, nullable: false),
                    direccion = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
