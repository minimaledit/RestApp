using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationReviewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Tables",
                newName: "Tables",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Reviews",
                newName: "Reviews",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurants",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservations",
                newSchema: "dbo");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                schema: "dbo",
                table: "Tables",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                schema: "dbo",
                table: "Reviews",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                schema: "dbo",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                schema: "dbo",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                schema: "dbo",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                schema: "dbo",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Reservations",
                column: "RestaurantId",
                principalSchema: "dbo",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "dbo",
                table: "Reservations",
                column: "TableId",
                principalSchema: "dbo",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                schema: "dbo",
                table: "Reservations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Reviews",
                column: "RestaurantId",
                principalSchema: "dbo",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                schema: "dbo",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Tables",
                column: "RestaurantId",
                principalSchema: "dbo",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_TableId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_RestaurantId",
                schema: "dbo",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RestaurantId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_UserId",
                schema: "dbo",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Tables",
                schema: "dbo",
                newName: "Tables");

            migrationBuilder.RenameTable(
                name: "Reviews",
                schema: "dbo",
                newName: "Reviews");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                schema: "dbo",
                newName: "Restaurants");

            migrationBuilder.RenameTable(
                name: "Reservations",
                schema: "dbo",
                newName: "Reservations");
        }
    }
}
