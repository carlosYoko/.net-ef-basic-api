﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_BeerStore.Migrations
{
    /// <inheritdoc />
    public partial class AlcoholPropInBeer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Alcohol",
                table: "Beers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alcohol",
                table: "Beers");
        }
    }
}
