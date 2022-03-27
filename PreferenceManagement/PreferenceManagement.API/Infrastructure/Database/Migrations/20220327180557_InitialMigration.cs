using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreferenceManagement.API.Infrastructure.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "preference_definitions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    solution = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_preference_definitions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_preferences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    value = table.Column<string>(type: "text", nullable: true),
                    preference_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_preferences", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_preferences_preference_definitions_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preference_definitions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "preference_definitions",
                columns: new[] { "id", "key", "level", "solution" },
                values: new object[,]
                {
                    { new Guid("fa2a0602-31b2-40ee-a622-490799bb81fb"), "DARK_MODE", "Solution", "ExampleSolution" },
                    { new Guid("e9f4ae48-2538-45f1-b052-85ef4b73f54a"), "EMAIL_NOTIFICATIONS", "Solution", "ExampleSolution" },
                    { new Guid("3f92b025-bd0f-4695-8aa3-a5bbfaa66031"), "ANALYTICS_CONSENT", "Universal", null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_preference_definitions_key_solution",
                table: "preference_definitions",
                columns: new[] { "key", "solution" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_preferences_preference_id",
                table: "user_preferences",
                column: "preference_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_preferences_user_id_preference_id",
                table: "user_preferences",
                columns: new[] { "user_id", "preference_id" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_preferences");

            migrationBuilder.DropTable(
                name: "preference_definitions");
        }
    }
}
