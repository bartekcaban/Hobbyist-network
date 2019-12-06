using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hobbyist_Network.Domain.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "HobbyCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "HobbyCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
