using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmed.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Patiente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Patientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Patientes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Patientes");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Patientes");
        }
    }
}
