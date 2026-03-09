using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class _20260309 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_UserId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Plant_AspNetUsers_UserId",
                table: "Plant");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoReplies_AspNetUsers_ApplicationUserId",
                table: "TodoReplies");

            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_UserToId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_TodoReplies_ApplicationUserId",
                table: "TodoReplies");

            migrationBuilder.DropIndex(
                name: "IX_Plant_UserId",
                table: "Plant");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TodoReplies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Devices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidDate",
                table: "Tools",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "OtherCounters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "HeatCounters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "GasCounters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Engines",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ElectricCounters",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Alarms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Key", "Order", "SettingsId", "Value" },
                values: new object[] { "Czy wysłać email adresatowi nowego zadania?", "EmailOnNewTodo", 7, 1, "False" });

            migrationBuilder.UpdateData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Key", "Order", "Type", "Value" },
                values: new object[] { "Czy wyświetlać banner na stronie głównej?", "BannerVisible", 1, 1, "True" });

            migrationBuilder.UpdateData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Key", "Order", "Type", "Value" },
                values: new object[] { "Folor footera strona głównej", "FooterColor", 2, 5, "#dc3545" });

            migrationBuilder.InsertData(
                table: "SettingsPositions",
                columns: new[] { "Id", "Description", "Key", "Order", "SettingsId", "Type", "Value" },
                values: new object[] { 10, "Główny adres e-mail administratora", "AdminEmail", 3, 2, 0, "integri.pp@gmail.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_UserToId",
                table: "Todos",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_UserToId",
                table: "Todos");

            migrationBuilder.DeleteData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidDate",
                table: "Tools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TodoReplies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Plant",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OtherCounters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "HeatCounters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "GasCounters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Engines",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ElectricCounters",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Devices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Alarms",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Description", "Key", "Order", "SettingsId", "Value" },
                values: new object[] { "Czy wyświetlać banner na stronie głównej?", "BannerVisible", 1, 2, "True" });

            migrationBuilder.UpdateData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Description", "Key", "Order", "Type", "Value" },
                values: new object[] { "Folor footera strona głównej", "FooterColor", 2, 5, "#dc3545" });

            migrationBuilder.UpdateData(
                table: "SettingsPositions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Description", "Key", "Order", "Type", "Value" },
                values: new object[] { "Główny adres e-mail administratora", "AdminEmail", 3, 0, "integri.pp@gmail.com" });

            migrationBuilder.CreateIndex(
                name: "IX_TodoReplies_ApplicationUserId",
                table: "TodoReplies",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_UserId",
                table: "Plant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_UserId",
                table: "Devices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_AspNetUsers_UserId",
                table: "Plant",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoReplies_AspNetUsers_ApplicationUserId",
                table: "TodoReplies",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_UserToId",
                table: "Todos",
                column: "UserToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
