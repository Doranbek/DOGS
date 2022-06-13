using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBDOG.Migrations
{
    public partial class deogviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogKarooModel");

            migrationBuilder.DropTable(
                name: "DogModel");

            migrationBuilder.DropTable(
                name: "DrugModel");

            migrationBuilder.DropTable(
                name: "OrgUsers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropColumn(
                name: "Disease",
                table: "DogKaroos");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "DogKaroos");

            migrationBuilder.DropColumn(
                name: "Disease",
                table: "DogDaarys");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "DogDaarys");

            migrationBuilder.AddColumn<string>(
                name: "Disease",
                table: "Drugs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ViewCampCategories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoatoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAlive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCampCategories", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_CoatoId",
                table: "Dogs",
                column: "CoatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OrganizationId",
                table: "Dogs",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Coats_CoatoId",
                table: "Dogs",
                column: "CoatoId",
                principalTable: "Coats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Organizations_OrganizationId",
                table: "Dogs",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Coats_CoatoId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Organizations_OrganizationId",
                table: "Dogs");

            migrationBuilder.DropTable(
                name: "ViewCampCategories");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_CoatoId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_OrganizationId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Disease",
                table: "Drugs");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Disease",
                table: "DogKaroos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "DogKaroos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Disease",
                table: "DogDaarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "DogDaarys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DogKarooModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disease = table.Column<int>(type: "int", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuantityDrug = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogKarooModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogModel",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoatoId = table.Column<int>(type: "int", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsAlive = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DrugModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrgUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrgUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoatoId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IssuingOrg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Coats_CoatoId",
                        column: x => x.CoatoId,
                        principalTable: "Coats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CoatoId",
                table: "Persons",
                column: "CoatoId");
        }
    }
}
