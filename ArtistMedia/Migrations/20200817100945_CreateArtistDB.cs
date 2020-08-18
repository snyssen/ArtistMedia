using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArtistMedia.Migrations
{
    public partial class CreateArtistDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Begin_date_year = table.Column<int>(nullable: false),
                    Begin_date_month = table.Column<int>(nullable: false),
                    Begin_date_day = table.Column<int>(nullable: false),
                    End_date_year = table.Column<int>(nullable: false),
                    End_date_month = table.Column<int>(nullable: false),
                    End_date_day = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Edits_pending = table.Column<int>(nullable: false),
                    Last_updated = table.Column<DateTime>(nullable: false),
                    Ended = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artist_Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Parent = table.Column<int>(nullable: false),
                    Child_order = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    Gid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sort_name = table.Column<string>(nullable: true),
                    Begin_date_year = table.Column<int>(nullable: false),
                    Begin_date_month = table.Column<int>(nullable: false),
                    Begin_date_day = table.Column<int>(nullable: false),
                    End_date_year = table.Column<int>(nullable: false),
                    End_date_month = table.Column<int>(nullable: false),
                    End_date_day = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Area = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Edits_pending = table.Column<int>(nullable: false),
                    Last_updated = table.Column<DateTime>(nullable: false),
                    Ended = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Parent = table.Column<int>(nullable: false),
                    Child_order = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    Gid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Artist_Types");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
