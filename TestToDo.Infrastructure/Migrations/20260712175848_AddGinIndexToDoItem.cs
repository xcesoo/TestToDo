using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestToDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGinIndexToDoItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_todo_items_description",
                table: "todo_items",
                column: "description")
                .Annotation("Npgsql:IndexMethod", "gin")
                .Annotation("Npgsql:IndexOperators", new[] { "gin_trgm_ops" });

            migrationBuilder.CreateIndex(
                name: "IX_todo_items_title",
                table: "todo_items",
                column: "title")
                .Annotation("Npgsql:IndexMethod", "gin")
                .Annotation("Npgsql:IndexOperators", new[] { "gin_trgm_ops" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_todo_items_description",
                table: "todo_items");

            migrationBuilder.DropIndex(
                name: "IX_todo_items_title",
                table: "todo_items");
        }
    }
}
