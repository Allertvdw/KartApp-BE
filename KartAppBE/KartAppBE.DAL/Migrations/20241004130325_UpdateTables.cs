using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartAppBE.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1255dba0-7e0b-4519-96a9-c78e69aa8d30");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "adbabf54-f2f4-49e3-89f8-e40355590dca");

            migrationBuilder.CreateTable(
                name: "SessionKarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    KartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionKarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionKarts_Karts_KartId",
                        column: x => x.KartId,
                        principalTable: "Karts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SessionKarts_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Laptimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SessionKartId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LapTimeInSeconds = table.Column<float>(type: "float", nullable: false),
                    LapNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptimes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Laptimes_SessionKarts_SessionKartId",
                        column: x => x.SessionKartId,
                        principalTable: "SessionKarts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8eb549ce-9f7d-4ee4-a872-a5af1e8ab443", null, "admin", "admin" },
                    { "b8dd51ee-a8b1-4147-91d9-3717dff6f4fb", null, "client", "client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Laptimes_SessionKartId",
                table: "Laptimes",
                column: "SessionKartId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptimes_UserId",
                table: "Laptimes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionKarts_KartId",
                table: "SessionKarts",
                column: "KartId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionKarts_SessionId",
                table: "SessionKarts",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Laptimes");

            migrationBuilder.DropTable(
                name: "SessionKarts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eb549ce-9f7d-4ee4-a872-a5af1e8ab443");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8dd51ee-a8b1-4147-91d9-3717dff6f4fb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1255dba0-7e0b-4519-96a9-c78e69aa8d30", null, "admin", "admin" },
                    { "adbabf54-f2f4-49e3-89f8-e40355590dca", null, "client", "client" }
                });
        }
    }
}
