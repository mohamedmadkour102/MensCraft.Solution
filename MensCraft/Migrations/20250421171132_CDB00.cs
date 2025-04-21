using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensCraft.Migrations
{
    /// <inheritdoc />
    public partial class CDB00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Cities_CityId",
                table: "Craftsmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Occupations_OccupationId",
                table: "Craftsmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Apartments_ApartmentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_LocationId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordResetCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OccupationId",
                table: "Craftsmen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Craftsmen",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Cities_CityId",
                table: "Craftsmen",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Occupations_OccupationId",
                table: "Craftsmen",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Apartments_ApartmentId",
                table: "Customers",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Cities_CityId",
                table: "Craftsmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Craftsmen_Occupations_OccupationId",
                table: "Craftsmen");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Apartments_ApartmentId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cities_LocationId",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordResetCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OccupationId",
                table: "Craftsmen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Craftsmen",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Cities_CityId",
                table: "Craftsmen",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Craftsmen_Occupations_OccupationId",
                table: "Craftsmen",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Apartments_ApartmentId",
                table: "Customers",
                column: "ApartmentId",
                principalTable: "Apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cities_LocationId",
                table: "Customers",
                column: "LocationId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
