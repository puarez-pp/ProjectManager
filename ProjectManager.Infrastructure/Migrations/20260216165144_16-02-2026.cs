using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class _16022026 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                table: "WorkScopeCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                table: "WorkScopeOffers");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "WorkScopeOffers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                table: "WorkScopeCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                table: "WorkScopeOffers");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "WorkScopeOffers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
    }
}
