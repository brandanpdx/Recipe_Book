using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBook.Migrations
{
  public partial class Initial : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Recipes",
          columns: table => new
          {
            RecipeId = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(nullable: true),
            Rating = table.Column<int>(nullable: false),
            Instructions = table.Column<string>(nullable: true),
            Ingredients = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Recipes", x => x.RecipeId);
          });

      migrationBuilder.CreateTable(
          name: "Tags",
          columns: table => new
          {
            TagId = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            Name = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Tags", x => x.TagId);
          });

      migrationBuilder.CreateTable(
          name: "RecipeTag",
          columns: table => new
          {
            RecipeTagId = table.Column<int>(nullable: false)
                  .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
            TagId = table.Column<int>(nullable: false),
            RecipeId = table.Column<int>(nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_RecipeTag", x => x.RecipeTagId);
            table.ForeignKey(
                      name: "FK_RecipeTag_Recipes_RecipeId",
                      column: x => x.RecipeId,
                      principalTable: "Recipes",
                      principalColumn: "RecipeId",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_RecipeTag_Tags_TagId",
                      column: x => x.TagId,
                      principalTable: "Tags",
                      principalColumn: "TagId",
                      onDelete: ReferentialAction.Cascade);
          });

      migrationBuilder.CreateIndex(
          name: "IX_RecipeTag_RecipeId",
          table: "RecipeTag",
          column: "RecipeId");

      migrationBuilder.CreateIndex(
          name: "IX_RecipeTag_TagId",
          table: "RecipeTag",
          column: "TagId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "RecipeTag");

      migrationBuilder.DropTable(
          name: "Recipes");

      migrationBuilder.DropTable(
          name: "Tags");
    }
  }
}
