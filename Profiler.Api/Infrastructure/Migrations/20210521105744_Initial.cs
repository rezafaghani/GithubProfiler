using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Profiler.Api.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "profiling");

            migrationBuilder.CreateTable(
                name: "githubprofiles",
                schema: "profiling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Organization = table.Column<string>(type: "text", nullable: true),
                    GithubAccount = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_githubprofiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "requests",
                schema: "profiling",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profilerepos",
                schema: "profiling",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    GithubProfileId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profilerepos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profilerepos_githubprofiles_GithubProfileId",
                        column: x => x.GithubProfileId,
                        principalSchema: "profiling",
                        principalTable: "githubprofiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_githubprofiles_Email",
                schema: "profiling",
                table: "githubprofiles",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_githubprofiles_Name",
                schema: "profiling",
                table: "githubprofiles",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_profilerepos_GithubProfileId",
                schema: "profiling",
                table: "profilerepos",
                column: "GithubProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_profilerepos_Name",
                schema: "profiling",
                table: "profilerepos",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "profilerepos",
                schema: "profiling");

            migrationBuilder.DropTable(
                name: "requests",
                schema: "profiling");

            migrationBuilder.DropTable(
                name: "githubprofiles",
                schema: "profiling");
        }
    }
}
