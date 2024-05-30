using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppBlog.Migrations
{
    /// <inheritdoc />
    public partial class addboxertb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "boxers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boxers", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boxers");
        }
    }
}
