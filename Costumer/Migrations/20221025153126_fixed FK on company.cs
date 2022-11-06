using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Customer.Migrations
{
    public partial class fixedFKoncompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyCategoryViewModel_CompanyCategoryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyGroupViewModel_CompanyGroupId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "CompanyCategoryViewModel");

            migrationBuilder.DropTable(
                name: "CompanyGroupViewModel");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyCategories_CompanyCategoryId",
                table: "Companies",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyGroups_CompanyGroupId",
                table: "Companies",
                column: "CompanyGroupId",
                principalTable: "CompanyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyCategories_CompanyCategoryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyGroups_CompanyGroupId",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "CompanyCategoryViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCategoryViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGroupViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGroupViewModel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyCategoryViewModel_CompanyCategoryId",
                table: "Companies",
                column: "CompanyCategoryId",
                principalTable: "CompanyCategoryViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyGroupViewModel_CompanyGroupId",
                table: "Companies",
                column: "CompanyGroupId",
                principalTable: "CompanyGroupViewModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
