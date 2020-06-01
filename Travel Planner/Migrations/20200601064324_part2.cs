using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_Planner.Migrations
{
    public partial class part2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9155491c-845e-4bbc-a4fb-02f507b1b766");

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flights = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    VacationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Vacations_VacationId",
                        column: x => x.VacationId,
                        principalTable: "Vacations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf9571fd-728f-4473-ad18-9efcf1844112", "10fc0c37-d0cc-4b68-b590-e3ccdf419370", "Traveler", "TRAVELER" });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_VacationId",
                table: "Flights",
                column: "VacationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf9571fd-728f-4473-ad18-9efcf1844112");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9155491c-845e-4bbc-a4fb-02f507b1b766", "5f0f6ddb-b6e6-4faa-b666-c449adffd548", "Traveler", "TRAVELER" });
        }
    }
}
