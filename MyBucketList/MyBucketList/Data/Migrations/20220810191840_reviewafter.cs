using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBucketList.Data.Migrations
{
    public partial class reviewafter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HowAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IlearnedAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItMadeMeFeelAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TheBestPartAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhenAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhereAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WithAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WouldIDoItAfter",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "IlearnedAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "ItMadeMeFeelAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "TheBestPartAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "WhenAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "WhereAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "WithAfter",
                table: "MyBucketListModel");

            migrationBuilder.DropColumn(
                name: "WouldIDoItAfter",
                table: "MyBucketListModel");
        }
    }
}
