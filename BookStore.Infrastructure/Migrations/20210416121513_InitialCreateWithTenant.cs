using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Migrations
{
    public partial class InitialCreateWithTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BookStore");

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Domain = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "BookStore",
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "BookStore",
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsInactive = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "BookStore",
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BookStore",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "BookStore",
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                schema: "BookStore",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "BookStore",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "BookStore",
                        principalTable: "Tenants",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Tenants",
                columns: new[] { "Id", "CreatedAt", "Description", "Domain", "Name", "UpdatedAt" },
                values: new object[] { new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416"), new DateTimeOffset(new DateTime(2021, 4, 16, 14, 15, 12, 959, DateTimeKind.Unspecified).AddTicks(8322), new TimeSpan(0, 0, 0, 0, 0)), "This is the default landing domain for Ahmed bookstores.", "default.ahmedbookstores.net", "Default landing", new DateTimeOffset(new DateTime(2021, 4, 16, 14, 15, 12, 959, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Authors",
                columns: new[] { "Id", "Name", "Nationality", "TenantId" },
                values: new object[,]
                {
                    { new Guid("bcecae43-f814-4d29-8319-31f6781c16c5"), "Ahmed Shaban", "Egypt", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("42d3c3d0-4131-4744-99f6-dae8b041d9f4"), "Omar Alfar", "Egypt", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") }
                });

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Categories",
                columns: new[] { "Id", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("27fc8e45-c17e-45a2-9d1b-2b17637ec097"), ".NET", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("d2c47e89-5a96-4f80-8526-c80b7605569f"), "Database", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("59c67919-2d8a-47de-a3ca-392b4a1f4e67"), "Web development", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("02c5162d-73c8-4881-a05f-2cf2aa4ea4d4"), "Algorithms", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_TenantId",
                schema: "BookStore",
                table: "Authors",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                schema: "BookStore",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                schema: "BookStore",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_TenantId",
                schema: "BookStore",
                table: "Books",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TenantId",
                schema: "BookStore",
                table: "Categories",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                schema: "BookStore",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_TenantId",
                schema: "BookStore",
                table: "Reviews",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Authors",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "BookStore");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "BookStore");
        }
    }
}
