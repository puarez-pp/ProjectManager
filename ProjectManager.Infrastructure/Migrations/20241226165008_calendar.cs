using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class calendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEvents_Projects_ProjectId",
                table: "EmployeeEvents");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "EmployeeEvents",
                newName: "CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEvents_ProjectId",
                table: "EmployeeEvents",
                newName: "IX_EmployeeEvents_CalendarId");

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_UserId",
                table: "Calendars",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEvents_Calendars_CalendarId",
                table: "EmployeeEvents",
                column: "CalendarId",
                principalTable: "Calendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEvents_Calendars_CalendarId",
                table: "EmployeeEvents");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.RenameColumn(
                name: "CalendarId",
                table: "EmployeeEvents",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEvents_CalendarId",
                table: "EmployeeEvents",
                newName: "IX_EmployeeEvents_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEvents_Projects_ProjectId",
                table: "EmployeeEvents",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
