using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestToDo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_todo_items_categories_category_id",
                table: "todo_items");

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                table: "todo_items",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "todo_items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_todo_items_user_id_category_id",
                table: "todo_items",
                columns: new[] { "user_id", "category_id" });

            migrationBuilder.CreateIndex(
                name: "IX_categories_user_id_name",
                table: "categories",
                columns: new[] { "user_id", "name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_users_user_id",
                table: "categories",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_todo_items_categories_category_id",
                table: "todo_items",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_todo_items_users_user_id",
                table: "todo_items",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_users_user_id",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_todo_items_categories_category_id",
                table: "todo_items");

            migrationBuilder.DropForeignKey(
                name: "FK_todo_items_users_user_id",
                table: "todo_items");

            migrationBuilder.DropIndex(
                name: "IX_todo_items_user_id_category_id",
                table: "todo_items");

            migrationBuilder.DropIndex(
                name: "IX_categories_user_id_name",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "todo_items");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "categories");

            migrationBuilder.AlterColumn<Guid>(
                name: "category_id",
                table: "todo_items",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "Default" });

            migrationBuilder.AddForeignKey(
                name: "FK_todo_items_categories_category_id",
                table: "todo_items",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
