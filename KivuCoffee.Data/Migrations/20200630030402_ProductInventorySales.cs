using Microsoft.EntityFrameworkCore.Migrations;

namespace KivuCoffee.Data.Migrations
{
    public partial class ProductInventorySales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine3",
                table: "CustomerAddresses");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "CustomerAddresses",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "CustomerAddresses");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine3",
                table: "CustomerAddresses",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
