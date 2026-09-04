using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemToExcel.Migrations
{
    /// <inheritdoc />
    public partial class ItemsToCategoryRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddCheckConstraint(
                name: "CK_After_Discount",
                table: "Items",
                sql: "[AfterDiscount] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Before_Discount",
                table: "Items",
                sql: "[BeforeDiscount] > 0");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Check_Valid_AfterDiscount",
                table: "Items",
                sql: "[AfterDiscount] <= [BeforeDiscount]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_After_Discount",
                table: "Items");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Before_Discount",
                table: "Items");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Check_Valid_AfterDiscount",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
