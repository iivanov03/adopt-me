using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptMe.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseEntities1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "PetLostAndFoundPosts");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "PetAdoptionPosts");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PetLostAndFoundPosts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PetAdoptionPosts",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PetLostAndFoundPosts",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PetAdoptionPosts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "PetLostAndFoundPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "PetAdoptionPosts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
