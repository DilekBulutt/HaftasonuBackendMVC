using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kutuphane.Data.Migrations
{
    /// <inheritdoc />
    public partial class YayinEviYazarKitapIliskileri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KitapYayinEvi",
                columns: table => new
                {
                    KitaplarId = table.Column<int>(type: "int", nullable: false),
                    YayinEvleriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYayinEvi", x => new { x.KitaplarId, x.YayinEvleriId });
                    table.ForeignKey(
                        name: "FK_KitapYayinEvi_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYayinEvi_YayinEvleri_YayinEvleriId",
                        column: x => x.YayinEvleriId,
                        principalTable: "YayinEvleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapYazar",
                columns: table => new
                {
                    KitaplarId = table.Column<int>(type: "int", nullable: false),
                    YazarlarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazar", x => new { x.KitaplarId, x.YazarlarId });
                    table.ForeignKey(
                        name: "FK_KitapYazar_Kitaplar_KitaplarId",
                        column: x => x.KitaplarId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Yazarlar_YazarlarId",
                        column: x => x.YazarlarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YayinEviYazar",
                columns: table => new
                {
                    YayinEvleriId = table.Column<int>(type: "int", nullable: false),
                    YazarlarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEviYazar", x => new { x.YayinEvleriId, x.YazarlarId });
                    table.ForeignKey(
                        name: "FK_YayinEviYazar_YayinEvleri_YayinEvleriId",
                        column: x => x.YayinEvleriId,
                        principalTable: "YayinEvleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YayinEviYazar_Yazarlar_YazarlarId",
                        column: x => x.YazarlarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitapYayinEvi_YayinEvleriId",
                table: "KitapYayinEvi",
                column: "YayinEvleriId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_YazarlarId",
                table: "KitapYazar",
                column: "YazarlarId");

            migrationBuilder.CreateIndex(
                name: "IX_YayinEviYazar_YazarlarId",
                table: "YayinEviYazar",
                column: "YazarlarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapYayinEvi");

            migrationBuilder.DropTable(
                name: "KitapYazar");

            migrationBuilder.DropTable(
                name: "YayinEviYazar");
        }
    }
}
