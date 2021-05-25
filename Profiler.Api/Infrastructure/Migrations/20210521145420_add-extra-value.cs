using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Profiler.Api.Infrastructure.Migrations
{
    public partial class addextravalue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "profiling",
                table: "profilerepos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDateTime",
                schema: "profiling",
                table: "profilerepos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "profiling",
                table: "profilerepos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "profiling",
                table: "profilerepos",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "profiling",
                table: "githubprofiles",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDateTime",
                schema: "profiling",
                table: "githubprofiles",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "profiling",
                table: "githubprofiles",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                schema: "profiling",
                table: "githubprofiles",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "profiling",
                table: "profilerepos");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "profiling",
                table: "profilerepos");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "profiling",
                table: "profilerepos");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "profiling",
                table: "profilerepos");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "profiling",
                table: "githubprofiles");

            migrationBuilder.DropColumn(
                name: "DeleteDateTime",
                schema: "profiling",
                table: "githubprofiles");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "profiling",
                table: "githubprofiles");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                schema: "profiling",
                table: "githubprofiles");
        }
    }
}
