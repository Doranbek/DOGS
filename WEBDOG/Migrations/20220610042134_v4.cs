using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBDOG.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogDaarys_Dogs_DogId",
                table: "DogDaarys");

            migrationBuilder.DropForeignKey(
                name: "FK_DogKaroos_Dogs_DogId",
                table: "DogKaroos");

            migrationBuilder.DropForeignKey(
                name: "FK_DogKaroos_Drugs_DrugId",
                table: "DogKaroos");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Coats_CoatoId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Organizations_OrganizationId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_CoatoId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_OrganizationId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_DogKaroos_DogId",
                table: "DogKaroos");

            migrationBuilder.DropIndex(
                name: "IX_DogKaroos_DrugId",
                table: "DogKaroos");

            migrationBuilder.DropIndex(
                name: "IX_DogDaarys_DogId",
                table: "DogDaarys");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "DogDaarys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Dose",
                table: "DogDaarys",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DogKarooModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    Disease = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    QuantityDrug = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CoatoId = table.Column<int>(type: "int", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthYear = table.Column<int>(type: "int", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAlive = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogKarooModel");

            migrationBuilder.DropTable(
                name: "DogModel");

            migrationBuilder.DropTable(
                name: "DrugModel");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "DogDaarys",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Dose",
                table: "DogDaarys",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_CoatoId",
                table: "Dogs",
                column: "CoatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OrganizationId",
                table: "Dogs",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DogKaroos_DogId",
                table: "DogKaroos",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogKaroos_DrugId",
                table: "DogKaroos",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_DogDaarys_DogId",
                table: "DogDaarys",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogDaarys_Dogs_DogId",
                table: "DogDaarys",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DogKaroos_Dogs_DogId",
                table: "DogKaroos",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DogKaroos_Drugs_DrugId",
                table: "DogKaroos",
                column: "DrugId",
                principalTable: "Drugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
