using Microsoft.EntityFrameworkCore.Migrations;

namespace Vehiculos.API.Migrations
{
    public partial class addTableVeicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehiculoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculoTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehiculoTypes_Description",
                table: "VehiculoTypes",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehiculoTypes");
        }
    }
}
