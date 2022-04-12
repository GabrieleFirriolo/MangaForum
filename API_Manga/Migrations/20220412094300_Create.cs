using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Manga.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    id_Manga = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titolo = table.Column<string>(type: "TEXT", nullable: false),
                    Creator = table.Column<string>(type: "TEXT", nullable: false),
                    AnnoPubblicazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.id_Manga);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_User = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", nullable: false),
                    DataDiNascita = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nazione = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_User);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    id_Topic = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Mangaid_Manga = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.id_Topic);
                    table.ForeignKey(
                        name: "FK_Topics_Mangas_Mangaid_Manga",
                        column: x => x.Mangaid_Manga,
                        principalTable: "Mangas",
                        principalColumn: "id_Manga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id_Post = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Creatorid_User = table.Column<int>(type: "INTEGER", nullable: true),
                    Topicid_Topic = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id_Post);
                    table.ForeignKey(
                        name: "FK_Posts_Topics_Topicid_Topic",
                        column: x => x.Topicid_Topic,
                        principalTable: "Topics",
                        principalColumn: "id_Topic",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_Creatorid_User",
                        column: x => x.Creatorid_User,
                        principalTable: "Users",
                        principalColumn: "id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    id_Reply = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Creatorid_User = table.Column<int>(type: "INTEGER", nullable: true),
                    Reply = table.Column<string>(type: "TEXT", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ForumPostid_Post = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.id_Reply);
                    table.ForeignKey(
                        name: "FK_Replies_Posts_ForumPostid_Post",
                        column: x => x.ForumPostid_Post,
                        principalTable: "Posts",
                        principalColumn: "id_Post",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Replies_Users_Creatorid_User",
                        column: x => x.Creatorid_User,
                        principalTable: "Users",
                        principalColumn: "id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Creatorid_User",
                table: "Posts",
                column: "Creatorid_User");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Topicid_Topic",
                table: "Posts",
                column: "Topicid_Topic");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_Creatorid_User",
                table: "Replies",
                column: "Creatorid_User");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_ForumPostid_Post",
                table: "Replies",
                column: "ForumPostid_Post");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_Mangaid_Manga",
                table: "Topics",
                column: "Mangaid_Manga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Mangas");
        }
    }
}
