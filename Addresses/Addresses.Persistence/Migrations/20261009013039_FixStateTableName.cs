using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Addresses.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixStateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_City_States_StateId",
                table: "Addresses_City");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Addresses_Country_CountryId",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                table: "States");

            migrationBuilder.RenameTable(
                name: "States",
                newName: "Addresses_State");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                table: "Addresses_State",
                newName: "IX_Addresses_State_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses_State",
                table: "Addresses_State",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_City_Addresses_State_StateId",
                table: "Addresses_City",
                column: "StateId",
                principalTable: "Addresses_State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_State_Addresses_Country_CountryId",
                table: "Addresses_State",
                column: "CountryId",
                principalTable: "Addresses_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_City_Addresses_State_StateId",
                table: "Addresses_City");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_State_Addresses_Country_CountryId",
                table: "Addresses_State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses_State",
                table: "Addresses_State");

            migrationBuilder.RenameTable(
                name: "Addresses_State",
                newName: "States");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_State_CountryId",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                table: "States",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_City_States_StateId",
                table: "Addresses_City",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Addresses_Country_CountryId",
                table: "States",
                column: "CountryId",
                principalTable: "Addresses_Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
