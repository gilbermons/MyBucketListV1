using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBucketList.Data.Migrations
{
    public partial class MyFirtsMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BucketId",
                table: "MyBucketListModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BucketId",
                table: "MyBucketListModel");
        }
    }
}
