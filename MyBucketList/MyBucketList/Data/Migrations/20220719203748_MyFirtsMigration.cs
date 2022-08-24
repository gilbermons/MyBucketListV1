using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBucketList.Data.Migrations
{
    public partial class MyFirtsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyBucketListModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BucketType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IWantIt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToMakeiT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatSopped = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IWantWith = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItIsGonnaBe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyBucketListModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyBucketListModel");
        }
    }
}
