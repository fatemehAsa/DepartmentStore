using Microsoft.EntityFrameworkCore.Migrations;

namespace DepartmentStore.DataLayer.Migrations
{
    public partial class mig_Dimention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dimention",
                table: "SubProducts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimention",
                table: "SubProducts");
        }
    }
}
