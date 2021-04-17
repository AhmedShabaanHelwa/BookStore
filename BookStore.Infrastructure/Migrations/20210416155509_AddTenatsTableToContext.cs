using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Infrastructure.Migrations
{
    public partial class AddTenatsTableToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("42d3c3d0-4131-4744-99f6-dae8b041d9f4"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("bcecae43-f814-4d29-8319-31f6781c16c5"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("02c5162d-73c8-4881-a05f-2cf2aa4ea4d4"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("27fc8e45-c17e-45a2-9d1b-2b17637ec097"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("59c67919-2d8a-47de-a3ca-392b4a1f4e67"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d2c47e89-5a96-4f80-8526-c80b7605569f"));

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Authors",
                columns: new[] { "Id", "Name", "Nationality", "TenantId" },
                values: new object[,]
                {
                    { new Guid("79aa15d2-6789-4ad1-a713-758fb6c6fac3"), "Ahmed Shaban", "Egypt", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("d7c1ba0d-955f-4cb8-a9e8-7373d8c44d69"), "Omar Alfar", "Egypt", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") }
                });

            migrationBuilder.InsertData(
                schema: "BookStore",
                table: "Categories",
                columns: new[] { "Id", "Name", "TenantId" },
                values: new object[,]
                {
                    { new Guid("cf885a0f-1f16-41f3-9fe3-305749f3126d"), ".NET", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("61283201-b0a4-4f99-8dc3-7ba9e90d8894"), "Database", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("e14bfbe0-29cd-4688-b6ea-ee084d2c13dc"), "Web development", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") },
                    { new Guid("d0053953-3ba7-44b0-ae69-2b1398ec3ee3"), "Algorithms", new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416") }
                });

            migrationBuilder.UpdateData(
                schema: "BookStore",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 17, 55, 8, 776, DateTimeKind.Unspecified).AddTicks(6798), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 17, 55, 8, 776, DateTimeKind.Unspecified).AddTicks(7909), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("79aa15d2-6789-4ad1-a713-758fb6c6fac3"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d7c1ba0d-955f-4cb8-a9e8-7373d8c44d69"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("61283201-b0a4-4f99-8dc3-7ba9e90d8894"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cf885a0f-1f16-41f3-9fe3-305749f3126d"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d0053953-3ba7-44b0-ae69-2b1398ec3ee3"));

            migrationBuilder.DeleteData(
                schema: "BookStore",
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e14bfbe0-29cd-4688-b6ea-ee084d2c13dc"));

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

            migrationBuilder.UpdateData(
                schema: "BookStore",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("d704c4f3-0ea7-4b2f-8c58-d7d0f10e6416"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2021, 4, 16, 14, 15, 12, 959, DateTimeKind.Unspecified).AddTicks(8322), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2021, 4, 16, 14, 15, 12, 959, DateTimeKind.Unspecified).AddTicks(9362), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
