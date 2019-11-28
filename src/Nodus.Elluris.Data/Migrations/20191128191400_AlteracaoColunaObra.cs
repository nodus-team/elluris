using Microsoft.EntityFrameworkCore.Migrations;

namespace Nodus.Elluris.Data.Migrations
{
    public partial class AlteracaoColunaObra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
              name: "UrlFoto",
              table: "Obras",
              type: "varchar(max)",
              nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //not applied here
        }
    }
}
