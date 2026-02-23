using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class _200220261 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Settlements_SettlementId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_SettlementId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "SettlementId",
                table: "Invoices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SettlementId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SettlementId",
                table: "Invoices",
                column: "SettlementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Settlements_SettlementId",
                table: "Invoices",
                column: "SettlementId",
                principalTable: "Settlements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
