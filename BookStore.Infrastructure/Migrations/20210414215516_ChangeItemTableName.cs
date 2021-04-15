using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Migrations
{
    public partial class ChangeItemTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Authors_AuthorId",
                schema: "BookStore",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                schema: "BookStore",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Items_BookId",
                schema: "BookStore",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                schema: "BookStore",
                table: "Items");

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("94bc5180-dd6b-4652-af92-75f8bb58a194"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("cdaf45f8-cfd2-417d-b1e0-b6cf1634498f"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2374b18c-fac9-4392-a03f-788136f44f2a"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5241da1f-a2e7-4317-89a6-30f669209f01"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc361689-a8e5-4cca-b1f9-22f14bfef606"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd95e815-f507-4696-bf8c-e6fec0b50cb2"));

            migrationBuilder.RenameTable(
                name: "Items",
                schema: "BookStore",
                newName: "Books",
                newSchema: "BookStore");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategoryId",
                schema: "BookStore",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_AuthorId",
                schema: "BookStore",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "BookStore",
                table: "Books",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Authors",
                columns: new[] { "Id", "Name", "Nationality" },
                values: new object[,]
                {
                    { new Guid("543afeac-e500-4d2b-a4ce-3490570c47b9"), "Ahmed Shaban", "Egypt" },
                    { new Guid("4b78f43e-e6fc-445b-b64e-33891219e17f"), "Omar Alfar", "Egypt" }
                });

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("aeda5bfe-2d4f-42df-ada8-fd910f7e671c"), ".NET" },
                    { new Guid("30d7d246-9881-4b5a-9f75-fe3653912ad3"), "Database" },
                    { new Guid("76f2fa04-ff9c-42f2-8678-b334680ca598"), "Web development" },
                    { new Guid("b5ba199c-a106-4f62-bb68-ec08950c4258"), "Algorithms" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                schema: "BookStore",
                table: "Books",
                column: "AuthorId",
                principalSchema: "BookStore",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                schema: "BookStore",
                table: "Books",
                column: "CategoryId",
                principalSchema: "BookStore",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "BookStore",
                table: "Reviews",
                column: "BookId",
                principalSchema: "BookStore",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                schema: "BookStore",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                schema: "BookStore",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Books_BookId",
                schema: "BookStore",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "BookStore",
                table: "Books");

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("4b78f43e-e6fc-445b-b64e-33891219e17f"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("543afeac-e500-4d2b-a4ce-3490570c47b9"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("30d7d246-9881-4b5a-9f75-fe3653912ad3"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("76f2fa04-ff9c-42f2-8678-b334680ca598"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aeda5bfe-2d4f-42df-ada8-fd910f7e671c"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b5ba199c-a106-4f62-bb68-ec08950c4258"));

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "BookStore",
                newName: "Items",
                newSchema: "BookStore");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                schema: "BookStore",
                table: "Items",
                newName: "IX_Items_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                schema: "BookStore",
                table: "Items",
                newName: "IX_Items_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                schema: "BookStore",
                table: "Items",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Authors",
                columns: new[] { "Id", "Name", "Nationality" },
                values: new object[,]
                {
                    { new Guid("cdaf45f8-cfd2-417d-b1e0-b6cf1634498f"), "Ahmed Shaban", "Egypt" },
                    { new Guid("94bc5180-dd6b-4652-af92-75f8bb58a194"), "Omar Alfar", "Egypt" }
                });

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5241da1f-a2e7-4317-89a6-30f669209f01"), ".NET" },
                    { new Guid("cd95e815-f507-4696-bf8c-e6fec0b50cb2"), "Database" },
                    { new Guid("bc361689-a8e5-4cca-b1f9-22f14bfef606"), "Web development" },
                    { new Guid("2374b18c-fac9-4392-a03f-788136f44f2a"), "Algorithms" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Authors_AuthorId",
                schema: "BookStore",
                table: "Items",
                column: "AuthorId",
                principalSchema: "BookStore",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                schema: "BookStore",
                table: "Items",
                column: "CategoryId",
                principalSchema: "BookStore",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Items_BookId",
                schema: "BookStore",
                table: "Reviews",
                column: "BookId",
                principalSchema: "BookStore",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
