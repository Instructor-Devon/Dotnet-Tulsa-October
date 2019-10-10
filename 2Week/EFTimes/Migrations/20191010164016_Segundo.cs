using Microsoft.EntityFrameworkCore.Migrations;

namespace DBTimes.Migrations
{
    public partial class Segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ninjas",
                table: "Ninjas");

            migrationBuilder.RenameTable(
                name: "Ninjas",
                newName: "ninjas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ninjas",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "NinjaId",
                table: "ninjas",
                newName: "ninja_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "ninjas",
                type: "VARCHAR(45)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ninjas",
                table: "ninjas",
                column: "ninja_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ninjas",
                table: "ninjas");

            migrationBuilder.RenameTable(
                name: "ninjas",
                newName: "Ninjas");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Ninjas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ninja_id",
                table: "Ninjas",
                newName: "NinjaId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ninjas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ninjas",
                table: "Ninjas",
                column: "NinjaId");
        }
    }
}
