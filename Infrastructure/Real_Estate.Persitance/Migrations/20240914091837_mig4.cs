using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Real_Estate.Persitance.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Properties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfBathrooms",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PropertyType",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SquareFeet",
                table: "Properties",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfBathrooms",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropertyType",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "SquareFeet",
                table: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
