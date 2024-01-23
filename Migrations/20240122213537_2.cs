using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeguridadInformatica.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenzas",
                columns: table => new
                {
                    AmenazasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amenaza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<float>(type: "real", nullable: false),
                    Control = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Impacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Riesgo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivosId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivosId1 = table.Column<int>(type: "int", nullable: true),
                    DimensionesId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimensionesActivosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenzas", x => x.AmenazasId);
                    table.ForeignKey(
                        name: "FK_Amenzas_Activos_ActivosId1",
                        column: x => x.ActivosId1,
                        principalTable: "Activos",
                        principalColumn: "ActivosId");
                    table.ForeignKey(
                        name: "FK_Amenzas_Activos_DimensionesActivosId",
                        column: x => x.DimensionesActivosId,
                        principalTable: "Activos",
                        principalColumn: "ActivosId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenzas_ActivosId1",
                table: "Amenzas",
                column: "ActivosId1");

            migrationBuilder.CreateIndex(
                name: "IX_Amenzas_DimensionesActivosId",
                table: "Amenzas",
                column: "DimensionesActivosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenzas");
        }
    }
}
