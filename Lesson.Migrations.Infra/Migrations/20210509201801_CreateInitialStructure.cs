using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson.Migrations.Infra.Migrations
{
    public partial class CreateInitialStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Document = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    BankId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agency_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OpenedAt = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Active"),
                    BankId = table.Column<long>(type: "bigint", nullable: false),
                    AgencyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountClient",
                columns: table => new
                {
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountClient", x => new { x.AccountId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_AccountClient_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountClient_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AgencyId",
                table: "Account",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_BankId",
                table: "Account",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Number",
                table: "Account",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_AccountClient_ClientId",
                table: "AccountClient",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_BankId",
                table: "Agency",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_Code",
                table: "Agency",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Agency_Name",
                table: "Agency",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Code",
                table: "Bank",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Bank_Name",
                table: "Bank",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Document",
                table: "Client",
                column: "Document");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Name",
                table: "Client",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountClient");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
