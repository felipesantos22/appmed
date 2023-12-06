using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appmed.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_Doctor_Speciality2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Expertises_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialities_Expertises_SpecialityId",
                table: "DoctorSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expertises",
                table: "Expertises");

            migrationBuilder.RenameTable(
                name: "Expertises",
                newName: "Specialities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialities",
                table: "Specialities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialities_Specialities_SpecialityId",
                table: "DoctorSpecialities",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Specialities_SpecialityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_DoctorSpecialities_Specialities_SpecialityId",
                table: "DoctorSpecialities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialities",
                table: "Specialities");

            migrationBuilder.RenameTable(
                name: "Specialities",
                newName: "Expertises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expertises",
                table: "Expertises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Expertises_SpecialityId",
                table: "Doctors",
                column: "SpecialityId",
                principalTable: "Expertises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorSpecialities_Expertises_SpecialityId",
                table: "DoctorSpecialities",
                column: "SpecialityId",
                principalTable: "Expertises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
