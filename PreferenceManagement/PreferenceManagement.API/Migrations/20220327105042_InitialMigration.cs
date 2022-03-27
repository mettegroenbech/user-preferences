using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreferenceManagement.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "preferences",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    key = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    solution = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_preferences", x => x.id);
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
                        name: "fk_user_preferences_preferences_preference_id",
                        column: x => x.preference_id,
                        principalTable: "preferences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "preferences",
                columns: new[] { "id", "key", "level", "solution" },
                values: new object[,]
                {
                    { new Guid("042fc127-6690-4bbe-b6c7-7ad077f5c75f"), "DARK_MODE", "Solution", "ExampleSolution" },
                    { new Guid("40e5b4b2-19f4-4415-a9e2-509f39539e04"), "EMAIL_NOTIFICATIONS", "Solution", "ExampleSolution" },
                    { new Guid("2790c73d-3e15-4696-884d-c77e4e8d5d82"), "ANALYTICS_CONSENT", "Universal", null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_preferences_key_solution",
                table: "preferences",
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
                name: "preferences");
        }
    }
}
