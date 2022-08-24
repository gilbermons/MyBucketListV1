using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBucketList.Data.Migrations
{
    public partial class reviewmybucket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BucketId",
                table: "MyBucketListModel");

            migrationBuilder.AlterColumn<string>(
                name: "ItIsGonnaBe",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "BucketReview",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Where = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    With = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    How = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilearned = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItMadeMeFeel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WouldIDoIt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TheBestPart = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BucketReview", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BucketReview");

            migrationBuilder.AlterColumn<string>(
                name: "ItIsGonnaBe",
                table: "MyBucketListModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BucketId",
                table: "MyBucketListModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
