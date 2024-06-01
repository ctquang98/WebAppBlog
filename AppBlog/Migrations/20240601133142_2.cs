using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppBlog.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("3f69a6d4-6ce1-4df9-81df-056ac37e959e"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("5763b37f-4bbd-4c1d-921c-0d42a133157e"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("9412a41a-beaa-41ed-9eb8-8635cbe4c9c7"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("b269f015-a5f2-4ca1-9eb3-cbbcc8b1a990"));

            migrationBuilder.CreateTable(
                name: "UserFollowers",
                columns: table => new
                {
                    ObserverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowers", x => new { x.ObserverId, x.TargetId });
                    table.ForeignKey(
                        name: "FK_UserFollowers_AspNetUsers_ObserverId",
                        column: x => x.ObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFollowers_AspNetUsers_TargetId",
                        column: x => x.TargetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "boxers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7eec21f6-20ac-410f-8d87-2b6ebc36298c"), "Yangby" },
                    { new Guid("a2844cc0-e454-460b-8c19-29fd0db52dff"), "LongG" },
                    { new Guid("e3eab46a-2209-4188-b305-c03e2ff67d34"), "Decal" },
                    { new Guid("e945a0c9-0aa0-4bb9-a017-a3c55dafa4c5"), "J98" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowers_TargetId",
                table: "UserFollowers",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollowers");

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("7eec21f6-20ac-410f-8d87-2b6ebc36298c"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("a2844cc0-e454-460b-8c19-29fd0db52dff"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("e3eab46a-2209-4188-b305-c03e2ff67d34"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("e945a0c9-0aa0-4bb9-a017-a3c55dafa4c5"));

            migrationBuilder.InsertData(
                table: "boxers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3f69a6d4-6ce1-4df9-81df-056ac37e959e"), "Yangby" },
                    { new Guid("5763b37f-4bbd-4c1d-921c-0d42a133157e"), "Decal" },
                    { new Guid("9412a41a-beaa-41ed-9eb8-8635cbe4c9c7"), "LongG" },
                    { new Guid("b269f015-a5f2-4ca1-9eb3-cbbcc8b1a990"), "J98" }
                });
        }
    }
}
