using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptMe.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Living",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VetClinic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomePets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PetAdoptionPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsAdopted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetAdoptionPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetAdoptionPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PetLostAndFoundPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Location = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    PetStatus = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    IsFound = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetLostAndFoundPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetLostAndFoundPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SuccessStories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuccessStories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuccessStories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PetAdoptionPostId = table.Column<int>(type: "int", nullable: true),
                    PetLostAndFoundPostId = table.Column<int>(type: "int", nullable: true),
                    SuccessStoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Replies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_PetAdoptionPosts_PetAdoptionPostId",
                        column: x => x.PetAdoptionPostId,
                        principalTable: "PetAdoptionPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_PetLostAndFoundPosts_PetLostAndFoundPostId",
                        column: x => x.PetLostAndFoundPostId,
                        principalTable: "PetLostAndFoundPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Replies_SuccessStories_SuccessStoryId",
                        column: x => x.SuccessStoryId,
                        principalTable: "SuccessStories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsCoverPicture = table.Column<bool>(type: "bit", nullable: false),
                    HomePetId = table.Column<int>(type: "int", nullable: true),
                    PetAdoptionPostId = table.Column<int>(type: "int", nullable: true),
                    PetLostAndFoundPostId = table.Column<int>(type: "int", nullable: true),
                    ReplyId = table.Column<int>(type: "int", nullable: true),
                    SuccessStoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_HomePets_HomePetId",
                        column: x => x.HomePetId,
                        principalTable: "HomePets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_PetAdoptionPosts_PetAdoptionPostId",
                        column: x => x.PetAdoptionPostId,
                        principalTable: "PetAdoptionPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_PetLostAndFoundPosts_PetLostAndFoundPostId",
                        column: x => x.PetLostAndFoundPostId,
                        principalTable: "PetLostAndFoundPosts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_Replies_ReplyId",
                        column: x => x.ReplyId,
                        principalTable: "Replies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pictures_SuccessStories_SuccessStoryId",
                        column: x => x.SuccessStoryId,
                        principalTable: "SuccessStories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_IsDeleted",
                table: "BankAccounts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_HomePets_IsDeleted",
                table: "HomePets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_HomePets_UserId",
                table: "HomePets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetAdoptionPosts_IsDeleted",
                table: "PetAdoptionPosts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetAdoptionPosts_UserId",
                table: "PetAdoptionPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PetLostAndFoundPosts_IsDeleted",
                table: "PetLostAndFoundPosts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_PetLostAndFoundPosts_UserId",
                table: "PetLostAndFoundPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_HomePetId",
                table: "Pictures",
                column: "HomePetId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_IsDeleted",
                table: "Pictures",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PetAdoptionPostId",
                table: "Pictures",
                column: "PetAdoptionPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PetLostAndFoundPostId",
                table: "Pictures",
                column: "PetLostAndFoundPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ReplyId",
                table: "Pictures",
                column: "ReplyId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_SuccessStoryId",
                table: "Pictures",
                column: "SuccessStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_UserId",
                table: "Pictures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_IsDeleted",
                table: "Replies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PetAdoptionPostId",
                table: "Replies",
                column: "PetAdoptionPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_PetLostAndFoundPostId",
                table: "Replies",
                column: "PetLostAndFoundPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_SuccessStoryId",
                table: "Replies",
                column: "SuccessStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_UserId",
                table: "Replies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuccessStories_IsDeleted",
                table: "SuccessStories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SuccessStories_UserId",
                table: "SuccessStories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "HomePets");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "PetAdoptionPosts");

            migrationBuilder.DropTable(
                name: "PetLostAndFoundPosts");

            migrationBuilder.DropTable(
                name: "SuccessStories");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Living",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");
        }
    }
}
