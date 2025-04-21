using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MensCraft.Migrations
{
	/// <inheritdoc />
	public partial class SeedCraftsmanAndCustomerRoles02 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			// لازم تستخدم int للـ Id هنا بدل من Guid
			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
				values: new object[] { 1, "CRAFTSMAN", "CRAFTSMAN", Guid.NewGuid().ToString() }
			);

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
				values: new object[] { 2, "CUSTOMER", "CUSTOMER", Guid.NewGuid().ToString() }
			);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: 1
			);

			migrationBuilder.DeleteData(
				table: "AspNetRoles",
				keyColumn: "Id",
				keyValue: 2
			);
		}
	}
}
