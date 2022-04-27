using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS4290_App.Migrations
{
    public partial class UpdatedNewColumns1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardCsv",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CardExpDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreditCardNumber",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Csv",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpDate",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Csv",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ExpDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "CardCsv",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardExpDate",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreditCardNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
