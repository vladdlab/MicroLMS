using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroLMS.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Hours = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ContentLinkId = table.Column<Guid>(type: "uuid", nullable: true),
                    DisciplineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_ContentLinks_ContentLinkId",
                        column: x => x.ContentLinkId,
                        principalTable: "ContentLinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sessions_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseBlocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Subtype = table.Column<int>(type: "integer", nullable: false),
                    Guidance = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentLinkId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseBlocks_ContentLinks_ContentLinkId",
                        column: x => x.ContentLinkId,
                        principalTable: "ContentLinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExerciseBlocks_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Complexity = table.Column<float>(type: "real", nullable: false),
                    ExerciseBlockId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentLinkId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_ContentLinks_ContentLinkId",
                        column: x => x.ContentLinkId,
                        principalTable: "ContentLinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exercises_ExerciseBlocks_ExerciseBlockId",
                        column: x => x.ExerciseBlockId,
                        principalTable: "ExerciseBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseVariants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Complexity = table.Column<float>(type: "real", nullable: false),
                    ContentLinkId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseVariants_ContentLinks_ContentLinkId",
                        column: x => x.ContentLinkId,
                        principalTable: "ContentLinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExerciseVariants_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UploadType = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseBlocks_ContentLinkId",
                table: "ExerciseBlocks",
                column: "ContentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseBlocks_SessionId",
                table: "ExerciseBlocks",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ContentLinkId",
                table: "Exercises",
                column: "ContentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseBlockId",
                table: "Exercises",
                column: "ExerciseBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseVariants_ContentLinkId",
                table: "ExerciseVariants",
                column: "ContentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseVariants_ExerciseId",
                table: "ExerciseVariants",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ExerciseId",
                table: "Options",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ContentLinkId",
                table: "Sessions",
                column: "ContentLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_DisciplineId",
                table: "Sessions",
                column: "DisciplineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseVariants");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "ExerciseBlocks");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ContentLinks");

            migrationBuilder.DropTable(
                name: "Disciplines");
        }
    }
}
