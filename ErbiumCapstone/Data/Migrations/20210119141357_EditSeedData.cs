using Microsoft.EntityFrameworkCore.Migrations;

namespace ErbiumCapstone.Data.Migrations
{
    public partial class EditSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "022fb840-f682-496c-adda-4d871996f22b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9279cb-94bf-4e82-b0f7-bd43fe1d5b8c");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Jobs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobType",
                table: "Jobs",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3fe4303-1590-4769-ae87-a45baeaa60e2", "bef2d095-d4ee-4e4c-bbae-0118be30953d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5905b95-7ab0-4854-a00f-232109136783", "46d50268-9582-4202-8b83-26320fc62b16", "Contractor", "CONTRACTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5905b95-7ab0-4854-a00f-232109136783");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3fe4303-1590-4769-ae87-a45baeaa60e2");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobName",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc9279cb-94bf-4e82-b0f7-bd43fe1d5b8c", "305fc421-0048-488c-81ae-c2629e9bfc54", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "022fb840-f682-496c-adda-4d871996f22b", "6e7ccc87-dc15-4799-99b9-af732d3bdddf", "Contractor", "CONTRACTOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
