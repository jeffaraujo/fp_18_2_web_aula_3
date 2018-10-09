using Microsoft.EntityFrameworkCore.Migrations;

namespace fp_stack.core.Migrations
{
    public partial class addRequiredTexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Perguntas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Perguntas",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
