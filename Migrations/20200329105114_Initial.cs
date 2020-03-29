using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_RestApi_Sqlite.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    ItemId = table.Column<int>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    SubContent = table.Column<string>(nullable: true),
                    SubTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 1, "Author1", "Content1", new DateTime(2020, 3, 29, 19, 51, 14, 725, DateTimeKind.Local).AddTicks(5296), "Title1", null });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[] { 2, "Author2", "Content2", new DateTime(2020, 3, 29, 19, 51, 14, 726, DateTimeKind.Local).AddTicks(3407), "Title2", null });

            migrationBuilder.InsertData(
                table: "SubItems",
                columns: new[] { "Id", "Author", "CreatedAt", "ItemId", "SubContent", "SubTitle", "UpdatedAt" },
                values: new object[] { 1, "SubAuthor1", new DateTime(2020, 3, 29, 19, 51, 14, 727, DateTimeKind.Local).AddTicks(1359), 1, "SubContent1", "SubTitle1", null });

            migrationBuilder.InsertData(
                table: "SubItems",
                columns: new[] { "Id", "Author", "CreatedAt", "ItemId", "SubContent", "SubTitle", "UpdatedAt" },
                values: new object[] { 2, "SubAuthor2", new DateTime(2020, 3, 29, 19, 51, 14, 727, DateTimeKind.Local).AddTicks(2005), 2, "SubContent2", "SubTitle2", null });

            migrationBuilder.CreateIndex(
                name: "IX_SubItems_ItemId",
                table: "SubItems",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubItems");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
