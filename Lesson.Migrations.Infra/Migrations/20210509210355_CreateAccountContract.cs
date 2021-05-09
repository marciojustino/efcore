using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lesson.Migrations.Infra.Migrations
{
    public partial class CreateAccountContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContractId",
                table: "Account",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    DATETIME = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contract_AccountId",
                table: "Contract",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Account");
        }
    }
}
