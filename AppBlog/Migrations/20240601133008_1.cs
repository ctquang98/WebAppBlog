using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppBlog.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("259ebb44-7d0b-4956-a2c3-f2ca218b1e82"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("38768891-20a8-49ed-b94d-a176b8967ae3"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("db206896-d38b-4bdf-99f2-fda058558f95"));

            migrationBuilder.DeleteData(
                table: "boxers",
                keyColumn: "Id",
                keyValue: new Guid("e2ffdf8f-1eb6-4ad8-bef8-3410a33e6a9a"));

            migrationBuilder.CreateTable(
                name: "UserFollowings",
                columns: table => new
                {
                    ObserverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TargetId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollowings", x => new { x.ObserverId, x.TargetId });
                    table.ForeignKey(
                        name: "FK_UserFollowings_AspNetUsers_ObserverId",
                        column: x => x.ObserverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFollowings_AspNetUsers_TargetId",
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
                    { new Guid("3f69a6d4-6ce1-4df9-81df-056ac37e959e"), "Yangby" },
                    { new Guid("5763b37f-4bbd-4c1d-921c-0d42a133157e"), "Decal" },
                    { new Guid("9412a41a-beaa-41ed-9eb8-8635cbe4c9c7"), "LongG" },
                    { new Guid("b269f015-a5f2-4ca1-9eb3-cbbcc8b1a990"), "J98" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollowings_TargetId",
                table: "UserFollowings",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollowings");

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

            migrationBuilder.InsertData(
                table: "boxers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("259ebb44-7d0b-4956-a2c3-f2ca218b1e82"), "LongG" },
                    { new Guid("38768891-20a8-49ed-b94d-a176b8967ae3"), "J98" },
                    { new Guid("db206896-d38b-4bdf-99f2-fda058558f95"), "Decal" },
                    { new Guid("e2ffdf8f-1eb6-4ad8-bef8-3410a33e6a9a"), "Yangby" }
                });
        }
    }
}
