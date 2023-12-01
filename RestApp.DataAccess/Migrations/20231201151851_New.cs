﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_Reservations_RestaurantId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_TableId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                schema: "dbo",
                newName: "Restaurants");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                schema: "dbo",
                table: "Reservations",
                newName: "DateTimeOut");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeIn",
                schema: "dbo",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Tables_UserId",
                schema: "dbo",
                table: "Reservations",
                column: "UserId",
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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Reviews",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                schema: "dbo",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                schema: "dbo",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Tables_UserId",
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

            migrationBuilder.DropColumn(
                name: "DateTimeIn",
                schema: "dbo",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Restaurants",
                newName: "Restaurants",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "DateTimeOut",
                schema: "dbo",
                table: "Reservations",
                newName: "DateTime");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                schema: "dbo",
                table: "Reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                schema: "dbo",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
