using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KartAppBE.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Laptimes_SessionKarts_SessionKartId",
                table: "Laptimes");

            migrationBuilder.DropTable(
                name: "SessionKarts");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8eb549ce-9f7d-4ee4-a872-a5af1e8ab443");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8dd51ee-a8b1-4147-91d9-3717dff6f4fb");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "SessionKartId",
                table: "Laptimes",
                newName: "KartId");

            migrationBuilder.RenameIndex(
                name: "IX_Laptimes_SessionKartId",
                table: "Laptimes",
                newName: "IX_Laptimes_KartId");

            migrationBuilder.CreateTable(
                name: "BookingUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BookingId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingUsers_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookingUsers_Karts_KartId",
                        column: x => x.KartId,
                        principalTable: "Karts",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "598cf16b-1959-41cb-be74-b0c77c6c2ffc", null, "admin", "admin" },
                    { "6db8252a-a4fa-406b-911f-6573fa0b2478", null, "client", "client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingUsers_BookingId",
                table: "BookingUsers",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingUsers_KartId",
                table: "BookingUsers",
                column: "KartId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingUsers_UserId",
                table: "BookingUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptimes_Karts_KartId",
                table: "Laptimes",
                column: "KartId",
                principalTable: "Karts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Laptimes_Karts_KartId",
                table: "Laptimes");

            migrationBuilder.DropTable(
                name: "BookingUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "598cf16b-1959-41cb-be74-b0c77c6c2ffc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6db8252a-a4fa-406b-911f-6573fa0b2478");

            migrationBuilder.RenameColumn(
                name: "KartId",
                table: "Laptimes",
                newName: "SessionKartId");

            migrationBuilder.RenameIndex(
                name: "IX_Laptimes_KartId",
                table: "Laptimes",
                newName: "IX_Laptimes_SessionKartId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SessionKarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KartId = table.Column<int>(type: "int", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8eb549ce-9f7d-4ee4-a872-a5af1e8ab443", null, "admin", "admin" },
                    { "b8dd51ee-a8b1-4147-91d9-3717dff6f4fb", null, "client", "client" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionKarts_KartId",
                table: "SessionKarts",
                column: "KartId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionKarts_SessionId",
                table: "SessionKarts",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_AspNetUsers_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Laptimes_SessionKarts_SessionKartId",
                table: "Laptimes",
                column: "SessionKartId",
                principalTable: "SessionKarts",
                principalColumn: "Id");
        }
    }
}
