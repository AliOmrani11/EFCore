using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Sample.Migrations
{
    public partial class TPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Post_PostId",
                table: "PostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "PostId");

            migrationBuilder.CreateTable(
                name: "AuthorInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorInfo_Author_Id",
                        column: x => x.Id,
                        principalTable: "Author",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Posts_PostId",
                table: "PostCategory",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategory_Posts_PostId",
                table: "PostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTag_Posts_PostId",
                table: "PostTag");

            migrationBuilder.DropTable(
                name: "AuthorInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategory_Post_PostId",
                table: "PostCategory",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTag_Post_PostId",
                table: "PostTag",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
