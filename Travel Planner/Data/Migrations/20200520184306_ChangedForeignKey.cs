using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_Planner.Migrations
{
    public partial class ChangedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_Travelers_TravelerId",
                table: "Excursions");

            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_Vacations_VacationId",
                table: "Excursions");

            migrationBuilder.DropIndex(
                name: "IX_Excursions_TravelerId",
                table: "Excursions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7bb9b12-7cdf-4f7f-9dd0-b276a039dc30");

            migrationBuilder.DropColumn(
                name: "TravelerId",
                table: "Excursions");

            migrationBuilder.AlterColumn<int>(
                name: "VacationId",
                table: "Excursions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5413d32-4163-40e7-b1bd-d8041f3d5c17", "7c873594-54bd-4b22-9343-80717554fda5", "Traveler", "TRAVELER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_Vacations_VacationId",
                table: "Excursions",
                column: "VacationId",
                principalTable: "Vacations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excursions_Vacations_VacationId",
                table: "Excursions");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5413d32-4163-40e7-b1bd-d8041f3d5c17");

            migrationBuilder.AlterColumn<int>(
                name: "VacationId",
                table: "Excursions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TravelerId",
                table: "Excursions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7bb9b12-7cdf-4f7f-9dd0-b276a039dc30", "90764d53-edd6-4738-8d5f-ebfa639a77ca", "Traveler", "TRAVELER" });

            migrationBuilder.CreateIndex(
                name: "IX_Excursions_TravelerId",
                table: "Excursions",
                column: "TravelerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_Travelers_TravelerId",
                table: "Excursions",
                column: "TravelerId",
                principalTable: "Travelers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Excursions_Vacations_VacationId",
                table: "Excursions",
                column: "VacationId",
                principalTable: "Vacations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
