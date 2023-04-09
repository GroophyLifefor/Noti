using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noti.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VirtualProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VirtualProfileId = table.Column<int>(type: "int", nullable: false),
                    CommentMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubComments_VirtualProfile_VirtualProfileId",
                        column: x => x.VirtualProfileId,
                        principalTable: "VirtualProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VirtualProfileId = table.Column<int>(type: "int", nullable: false),
                    CommentMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    SubCommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_SubComments_SubCommentId",
                        column: x => x.SubCommentId,
                        principalTable: "SubComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Comments_VirtualProfile_VirtualProfileId",
                        column: x => x.VirtualProfileId,
                        principalTable: "VirtualProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostOwnerId = table.Column<int>(type: "int", nullable: false),
                    PostShareDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Posts_VirtualProfile_PostOwnerId",
                        column: x => x.PostOwnerId,
                        principalTable: "VirtualProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VirtualProfileId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FollowersId = table.Column<int>(type: "int", nullable: false),
                    FollowingId = table.Column<int>(type: "int", nullable: false),
                    PostsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Profiles_VirtualProfile_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "VirtualProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Profiles_VirtualProfile_FollowingId",
                        column: x => x.FollowingId,
                        principalTable: "VirtualProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Profiles_VirtualProfile_VirtualProfileId",
                        column: x => x.VirtualProfileId,
                        principalTable: "VirtualProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SubCommentId",
                table: "Comments",
                column: "SubCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_VirtualProfileId",
                table: "Comments",
                column: "VirtualProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CommentId",
                table: "Posts",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostOwnerId",
                table: "Posts",
                column: "PostOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_FollowersId",
                table: "Profiles",
                column: "FollowersId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_FollowingId",
                table: "Profiles",
                column: "FollowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_PostsId",
                table: "Profiles",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_VirtualProfileId",
                table: "Profiles",
                column: "VirtualProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_VirtualProfileId",
                table: "SubComments",
                column: "VirtualProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SubComments");

            migrationBuilder.DropTable(
                name: "VirtualProfile");
        }
    }
}
