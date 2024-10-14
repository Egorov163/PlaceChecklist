using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaceChecklist.Migrations
{
    /// <inheritdoc />
    public partial class addLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Establishments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstablishmentTag",
                columns: table => new
                {
                    EstablishmentsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstablishmentTag", x => new { x.EstablishmentsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_EstablishmentTag_Establishments_EstablishmentsId",
                        column: x => x.EstablishmentsId,
                        principalTable: "Establishments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstablishmentTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establishments_CategoryId",
                table: "Establishments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EstablishmentTag_TagsId",
                table: "EstablishmentTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Establishments_Categories_CategoryId",
                table: "Establishments",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establishments_Categories_CategoryId",
                table: "Establishments");

            migrationBuilder.DropTable(
                name: "EstablishmentTag");

            migrationBuilder.DropIndex(
                name: "IX_Establishments_CategoryId",
                table: "Establishments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Establishments");
        }
    }
}
