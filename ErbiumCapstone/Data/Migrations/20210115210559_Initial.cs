using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErbiumCapstone.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    ContractorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.ContractorId);
                    table.ForeignKey(
                        name: "FK_Contractors_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    ContractorId = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    ProposedCost = table.Column<double>(nullable: false),
                    AgreedCost = table.Column<double>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: true),
                    JobStart = table.Column<DateTime>(nullable: true),
                    JobCompletion = table.Column<DateTime>(nullable: true),
                    JobDuration = table.Column<TimeSpan>(nullable: true),
                    isJobCompletionApproved = table.Column<bool>(nullable: false),
                    JobState = table.Column<string>(nullable: true),
                    ProvideUpdates = table.Column<bool>(nullable: false),
                    ProvidePix = table.Column<bool>(nullable: false),
                    NumberOfUpdates = table.Column<int>(nullable: false),
                    CustomerAcceptedJob = table.Column<bool>(nullable: false),
                    ContractorAcceptedJob = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractorSkills",
                columns: table => new
                {
                    ContractorSkillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(nullable: false),
                    ContractorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorSkills", x => x.ContractorSkillId);
                    table.ForeignKey(
                        name: "FK_ContractorSkills_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractorSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    CompletionImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_JobTasks_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc9279cb-94bf-4e82-b0f7-bd43fe1d5b8c", "305fc421-0048-488c-81ae-c2629e9bfc54", "Customer", "CUSTOMER" },
                    { "022fb840-f682-496c-adda-4d871996f22b", "6e7ccc87-dc15-4799-99b9-af732d3bdddf", "Contractor", "CONTRACTOR" }
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "ContractorId", "City", "FirstName", "IdentityUserId", "LastName", "Latitude", "Longitude", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Milwaukee", "John", null, "Smith", 0.0, 0.0, "WI", "550 N Harbor Dr", "53202" },
                    { 2, "Milwaukee", "Inigo", null, "Montoya", 0.0, 0.0, "WI", "239 E Chicago St #103", "53202" },
                    { 3, "Milwaukee", "Kirk", null, "Lazarus", 0.0, 0.0, "WI", "4022 N Oakland Ave,", "53211" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "City", "FirstName", "IdentityUserId", "LastName", "Latitude", "Longitude", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Milwaukee", "Mc", null, "Lovin", 0.0, 0.0, "WI", "346 N Broadway", "53202" },
                    { 2, "Milwaukee", "Saul", null, "Silver", 0.0, 0.0, "WI", "728 E Brady St", "53202" },
                    { 3, "Milwaukee", "Wade", null, "Wilson", 0.0, 0.0, "WI", "833 N Jefferson St,", "53202" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "SkillType" },
                values: new object[,]
                {
                    { 1, "Plumber" },
                    { 2, "Electrical" }
                });

            migrationBuilder.InsertData(
                table: "ContractorSkills",
                columns: new[] { "ContractorSkillId", "ContractorId", "SkillId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "ContractorSkills",
                columns: new[] { "ContractorSkillId", "ContractorId", "SkillId" },
                values: new object[] { 2, 2, 2 });

            migrationBuilder.InsertData(
                table: "ContractorSkills",
                columns: new[] { "ContractorSkillId", "ContractorId", "SkillId" },
                values: new object[] { 3, 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Contractors_IdentityUserId",
                table: "Contractors",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSkills_ContractorId",
                table: "ContractorSkills",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorSkills_SkillId",
                table: "ContractorSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_IdentityUserId",
                table: "Customers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContractorId",
                table: "Jobs",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CustomerId",
                table: "Jobs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobId",
                table: "JobTasks",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractorSkills");

            migrationBuilder.DropTable(
                name: "JobTasks");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Contractors");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "022fb840-f682-496c-adda-4d871996f22b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc9279cb-94bf-4e82-b0f7-bd43fe1d5b8c");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
