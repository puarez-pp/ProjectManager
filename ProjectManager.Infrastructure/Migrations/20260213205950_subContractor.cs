using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class subContractor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                table: "WorkScopeCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                table: "WorkScopeOffers");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "Inne");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "Inne");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "Inne");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: "Inne");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: "Inne");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 46,
                column: "Description",
                value: "Inne");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                table: "WorkScopeCosts",
                column: "SubContractorId",
                principalTable: "SubContractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                table: "WorkScopeOffers",
                column: "SubContractorId",
                principalTable: "SubContractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                table: "WorkScopeCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                table: "WorkScopeOffers");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "Rezerwa");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 26,
                column: "Description",
                value: "Rezerwa");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 32,
                column: "Description",
                value: "Rezerwa");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 37,
                column: "Description",
                value: "Rezerwa");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 41,
                column: "Description",
                value: "Rezerwa");

            migrationBuilder.UpdateData(
                table: "ProjectScopePositionTemplates",
                keyColumn: "Id",
                keyValue: 46,
                column: "Description",
                value: "Rezerwa");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                table: "WorkScopeCosts",
                column: "SubContractorId",
                principalTable: "SubContractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                table: "WorkScopeOffers",
                column: "SubContractorId",
                principalTable: "SubContractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
