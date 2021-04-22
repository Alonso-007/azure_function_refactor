using Microsoft.EntityFrameworkCore.Migrations;

namespace azure_function_refactor.dados.Migrations
{
    public partial class ArrumandoChaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetadataDtoId",
                table: "Content");

            migrationBuilder.AddColumn<int>(
                name: "ContentModelDtoId",
                table: "Metadata",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_ContentModelDtoId",
                table: "Metadata",
                column: "ContentModelDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Metadata_Content_ContentModelDtoId",
                table: "Metadata",
                column: "ContentModelDtoId",
                principalTable: "Content",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metadata_Content_ContentModelDtoId",
                table: "Metadata");

            migrationBuilder.DropIndex(
                name: "IX_Metadata_ContentModelDtoId",
                table: "Metadata");

            migrationBuilder.DropColumn(
                name: "ContentModelDtoId",
                table: "Metadata");

            migrationBuilder.AddColumn<int>(
                name: "MetadataDtoId",
                table: "Content",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
