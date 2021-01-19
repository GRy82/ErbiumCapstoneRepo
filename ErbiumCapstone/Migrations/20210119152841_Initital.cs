using Microsoft.EntityFrameworkCore.Migrations;

namespace ErbiumCapstone.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70a57b2b-f4d3-494b-8b2f-a337077a0bcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad60a221-c9fb-44b6-89b6-b906813bfb90");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "604bdcfb-63e6-4de0-be6f-8bbe32ccc063", "357a704f-f713-40fb-8d1f-805dec78393d", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db23e79f-044b-4fea-8e03-0b5827be18a9", "406386d4-bb64-445a-b443-8d015c24a9ac", "Contractor", "CONTRACTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "604bdcfb-63e6-4de0-be6f-8bbe32ccc063");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db23e79f-044b-4fea-8e03-0b5827be18a9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad60a221-c9fb-44b6-89b6-b906813bfb90", "5cf438f6-06cb-46ff-8b61-8c9c063efa94", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "70a57b2b-f4d3-494b-8b2f-a337077a0bcf", "57cfcd02-fa77-46f3-ad5b-d0f8a0fe728f", "Contractor", "CONTRACTOR" });
        }
    }
}
