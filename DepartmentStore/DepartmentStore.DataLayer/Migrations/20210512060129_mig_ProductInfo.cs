using Microsoft.EntityFrameworkCore.Migrations;

namespace DepartmentStore.DataLayer.Migrations
{
    public partial class mig_ProductInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryMades",
                columns: table => new
                {
                    MadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MadeTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMades", x => x.MadeId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    SubGroupId = table.Column<int>(type: "int", nullable: true),
                    ProductTitle = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ProductImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_SubGroupId",
                        column: x => x.SubGroupId,
                        principalTable: "ProductGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubProducts",
                columns: table => new
                {
                    SubProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MadeId = table.Column<int>(type: "int", nullable: false),
                    SubProductTitle = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    SubProductImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsDeleteInOrder = table.Column<bool>(type: "bit", nullable: false),
                    CountryMadeMadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProducts", x => x.SubProductId);
                    table.ForeignKey(
                        name: "FK_SubProducts_CountryMades_CountryMadeMadeId",
                        column: x => x.CountryMadeMadeId,
                        principalTable: "CountryMades",
                        principalColumn: "MadeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubGroupId",
                table: "Products",
                column: "SubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubProducts_CountryMadeMadeId",
                table: "SubProducts",
                column: "CountryMadeMadeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubProducts_ProductId",
                table: "SubProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProducts");

            migrationBuilder.DropTable(
                name: "CountryMades");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
