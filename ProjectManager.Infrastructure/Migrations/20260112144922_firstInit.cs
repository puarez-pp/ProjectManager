using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class firstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConfigured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devices_Plant_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemplatePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplatePositions_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlarmType = table.Column<int>(type: "int", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alarms_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeviceHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceHeaders_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parametr1 = table.Column<float>(type: "real", nullable: false),
                    Parametr2 = table.Column<float>(type: "real", nullable: false),
                    Parametr3 = table.Column<float>(type: "real", nullable: false),
                    Parametr4 = table.Column<float>(type: "real", nullable: false),
                    Parametr5 = table.Column<float>(type: "real", nullable: false),
                    Parametr6 = table.Column<float>(type: "real", nullable: false),
                    Parametr7 = table.Column<float>(type: "real", nullable: false),
                    Parametr8 = table.Column<float>(type: "real", nullable: false),
                    Parametr9 = table.Column<float>(type: "real", nullable: false),
                    Parametr10 = table.Column<float>(type: "real", nullable: false),
                    Parametr11 = table.Column<float>(type: "real", nullable: false),
                    Parametr12 = table.Column<float>(type: "real", nullable: false),
                    Parametr13 = table.Column<float>(type: "real", nullable: false),
                    Parametr14 = table.Column<float>(type: "real", nullable: false),
                    Parametr15 = table.Column<float>(type: "real", nullable: false),
                    Parametr16 = table.Column<float>(type: "real", nullable: false),
                    Parametr17 = table.Column<float>(type: "real", nullable: false),
                    Parametr18 = table.Column<float>(type: "real", nullable: false),
                    Parametr19 = table.Column<float>(type: "real", nullable: false),
                    Parametr20 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricCounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricCounters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parametr1 = table.Column<float>(type: "real", nullable: false),
                    Parametr2 = table.Column<float>(type: "real", nullable: false),
                    Parametr3 = table.Column<float>(type: "real", nullable: false),
                    Parametr4 = table.Column<float>(type: "real", nullable: false),
                    Parametr5 = table.Column<float>(type: "real", nullable: false),
                    Parametr6 = table.Column<float>(type: "real", nullable: false),
                    Parametr7 = table.Column<float>(type: "real", nullable: false),
                    Parametr8 = table.Column<float>(type: "real", nullable: false),
                    Parametr9 = table.Column<float>(type: "real", nullable: false),
                    Parametr10 = table.Column<float>(type: "real", nullable: false),
                    Parametr11 = table.Column<float>(type: "real", nullable: false),
                    Parametr12 = table.Column<float>(type: "real", nullable: false),
                    Parametr13 = table.Column<float>(type: "real", nullable: false),
                    Parametr14 = table.Column<float>(type: "real", nullable: false),
                    Parametr15 = table.Column<float>(type: "real", nullable: false),
                    Parametr16 = table.Column<float>(type: "real", nullable: false),
                    Parametr17 = table.Column<float>(type: "real", nullable: false),
                    Parametr18 = table.Column<float>(type: "real", nullable: false),
                    Parametr19 = table.Column<float>(type: "real", nullable: false),
                    Parametr20 = table.Column<float>(type: "real", nullable: false),
                    Parametr21 = table.Column<float>(type: "real", nullable: false),
                    Parametr22 = table.Column<float>(type: "real", nullable: false),
                    Parametr23 = table.Column<float>(type: "real", nullable: false),
                    Parametr24 = table.Column<float>(type: "real", nullable: false),
                    Parametr25 = table.Column<float>(type: "real", nullable: false),
                    Parametr26 = table.Column<float>(type: "real", nullable: false),
                    Parametr27 = table.Column<float>(type: "real", nullable: false),
                    Parametr28 = table.Column<float>(type: "real", nullable: false),
                    Parametr29 = table.Column<float>(type: "real", nullable: false),
                    Parametr30 = table.Column<float>(type: "real", nullable: false),
                    Parametr31 = table.Column<float>(type: "real", nullable: false),
                    Parametr32 = table.Column<float>(type: "real", nullable: false),
                    Parametr33 = table.Column<float>(type: "real", nullable: false),
                    Parametr34 = table.Column<float>(type: "real", nullable: false),
                    Parametr35 = table.Column<float>(type: "real", nullable: false),
                    Parametr36 = table.Column<float>(type: "real", nullable: false),
                    Parametr37 = table.Column<float>(type: "real", nullable: false),
                    Parametr38 = table.Column<float>(type: "real", nullable: false),
                    Parametr39 = table.Column<float>(type: "real", nullable: false),
                    Parametr40 = table.Column<float>(type: "real", nullable: false),
                    Parametr41 = table.Column<float>(type: "real", nullable: false),
                    Parametr42 = table.Column<float>(type: "real", nullable: false),
                    Parametr43 = table.Column<float>(type: "real", nullable: false),
                    Parametr44 = table.Column<float>(type: "real", nullable: false),
                    Parametr45 = table.Column<float>(type: "real", nullable: false),
                    Parametr46 = table.Column<float>(type: "real", nullable: false),
                    Parametr47 = table.Column<float>(type: "real", nullable: false),
                    Parametr48 = table.Column<float>(type: "real", nullable: false),
                    Parametr49 = table.Column<float>(type: "real", nullable: false),
                    Parametr50 = table.Column<float>(type: "real", nullable: false),
                    Parametr51 = table.Column<float>(type: "real", nullable: false),
                    Parametr52 = table.Column<float>(type: "real", nullable: false),
                    Parametr53 = table.Column<float>(type: "real", nullable: false),
                    Parametr54 = table.Column<float>(type: "real", nullable: false),
                    Parametr55 = table.Column<float>(type: "real", nullable: false),
                    Parametr56 = table.Column<float>(type: "real", nullable: false),
                    Parametr57 = table.Column<float>(type: "real", nullable: false),
                    Parametr58 = table.Column<float>(type: "real", nullable: false),
                    Parametr59 = table.Column<float>(type: "real", nullable: false),
                    Parametr60 = table.Column<float>(type: "real", nullable: false),
                    Parametr61 = table.Column<float>(type: "real", nullable: false),
                    Parametr62 = table.Column<float>(type: "real", nullable: false),
                    Parametr63 = table.Column<float>(type: "real", nullable: false),
                    Parametr64 = table.Column<float>(type: "real", nullable: false),
                    Parametr65 = table.Column<float>(type: "real", nullable: false),
                    Parametr66 = table.Column<float>(type: "real", nullable: false),
                    Parametr67 = table.Column<float>(type: "real", nullable: false),
                    Parametr68 = table.Column<float>(type: "real", nullable: false),
                    Parametr69 = table.Column<float>(type: "real", nullable: false),
                    Parametr70 = table.Column<float>(type: "real", nullable: false),
                    Parametr71 = table.Column<float>(type: "real", nullable: false),
                    Parametr72 = table.Column<float>(type: "real", nullable: false),
                    Parametr73 = table.Column<float>(type: "real", nullable: false),
                    Parametr74 = table.Column<float>(type: "real", nullable: false),
                    Parametr75 = table.Column<float>(type: "real", nullable: false),
                    Parametr76 = table.Column<float>(type: "real", nullable: false),
                    Parametr77 = table.Column<float>(type: "real", nullable: false),
                    Parametr78 = table.Column<float>(type: "real", nullable: false),
                    Parametr79 = table.Column<float>(type: "real", nullable: false),
                    Parametr80 = table.Column<float>(type: "real", nullable: false),
                    Parametr81 = table.Column<float>(type: "real", nullable: false),
                    Parametr82 = table.Column<float>(type: "real", nullable: false),
                    Parametr83 = table.Column<float>(type: "real", nullable: false),
                    Parametr84 = table.Column<float>(type: "real", nullable: false),
                    Parametr85 = table.Column<float>(type: "real", nullable: false),
                    Parametr86 = table.Column<float>(type: "real", nullable: false),
                    Parametr87 = table.Column<float>(type: "real", nullable: false),
                    Parametr88 = table.Column<float>(type: "real", nullable: false),
                    Parametr89 = table.Column<float>(type: "real", nullable: false),
                    Parametr90 = table.Column<float>(type: "real", nullable: false),
                    Parametr91 = table.Column<float>(type: "real", nullable: false),
                    Parametr92 = table.Column<float>(type: "real", nullable: false),
                    Parametr93 = table.Column<float>(type: "real", nullable: false),
                    Parametr94 = table.Column<float>(type: "real", nullable: false),
                    Parametr95 = table.Column<float>(type: "real", nullable: false),
                    Parametr96 = table.Column<float>(type: "real", nullable: false),
                    Parametr97 = table.Column<float>(type: "real", nullable: false),
                    Parametr98 = table.Column<float>(type: "real", nullable: false),
                    Parametr99 = table.Column<float>(type: "real", nullable: false),
                    Parametr100 = table.Column<float>(type: "real", nullable: false),
                    Parametr101 = table.Column<float>(type: "real", nullable: false),
                    Parametr102 = table.Column<float>(type: "real", nullable: false),
                    Parametr103 = table.Column<float>(type: "real", nullable: false),
                    Parametr104 = table.Column<float>(type: "real", nullable: false),
                    Parametr105 = table.Column<float>(type: "real", nullable: false),
                    Parametr106 = table.Column<float>(type: "real", nullable: false),
                    Parametr107 = table.Column<float>(type: "real", nullable: false),
                    Parametr108 = table.Column<float>(type: "real", nullable: false),
                    Parametr109 = table.Column<float>(type: "real", nullable: false),
                    Parametr110 = table.Column<float>(type: "real", nullable: false),
                    Parametr111 = table.Column<float>(type: "real", nullable: false),
                    Parametr112 = table.Column<float>(type: "real", nullable: false),
                    Parametr113 = table.Column<float>(type: "real", nullable: false),
                    Parametr114 = table.Column<float>(type: "real", nullable: false),
                    Parametr115 = table.Column<float>(type: "real", nullable: false),
                    Parametr116 = table.Column<float>(type: "real", nullable: false),
                    Parametr117 = table.Column<float>(type: "real", nullable: false),
                    Parametr118 = table.Column<float>(type: "real", nullable: false),
                    Parametr119 = table.Column<float>(type: "real", nullable: false),
                    Parametr120 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GasCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parametr1 = table.Column<float>(type: "real", nullable: false),
                    Parametr2 = table.Column<float>(type: "real", nullable: false),
                    Parametr3 = table.Column<float>(type: "real", nullable: false),
                    Parametr4 = table.Column<float>(type: "real", nullable: false),
                    Parametr5 = table.Column<float>(type: "real", nullable: false),
                    Parametr6 = table.Column<long>(type: "bigint", nullable: false),
                    Parametr7 = table.Column<long>(type: "bigint", nullable: false),
                    Parametr8 = table.Column<long>(type: "bigint", nullable: false),
                    Parametr9 = table.Column<long>(type: "bigint", nullable: false),
                    Parametr10 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GasCounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GasCounters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeatCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parametr1 = table.Column<float>(type: "real", nullable: false),
                    Parametr2 = table.Column<float>(type: "real", nullable: false),
                    Parametr3 = table.Column<float>(type: "real", nullable: false),
                    Parametr4 = table.Column<float>(type: "real", nullable: false),
                    Parametr5 = table.Column<float>(type: "real", nullable: false),
                    Parametr6 = table.Column<float>(type: "real", nullable: false),
                    Parametr7 = table.Column<float>(type: "real", nullable: false),
                    Parametr8 = table.Column<float>(type: "real", nullable: false),
                    Parametr9 = table.Column<float>(type: "real", nullable: false),
                    Parametr10 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatCounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeatCounters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OtherCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Parametr1 = table.Column<float>(type: "real", nullable: false),
                    Parametr2 = table.Column<float>(type: "real", nullable: false),
                    Parametr3 = table.Column<float>(type: "real", nullable: false),
                    Parametr4 = table.Column<float>(type: "real", nullable: false),
                    Parametr5 = table.Column<float>(type: "real", nullable: false),
                    Parametr6 = table.Column<float>(type: "real", nullable: false),
                    Parametr7 = table.Column<float>(type: "real", nullable: false),
                    Parametr8 = table.Column<float>(type: "real", nullable: false),
                    Parametr9 = table.Column<float>(type: "real", nullable: false),
                    Parametr10 = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherCounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherCounters_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "DeviceType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 2 },
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
                    { 1, "Olej smarowy przed filtrem", "P196", 1, 1 },
                    { 2, "Olej smarowy za filtrem A", "P302", 2, 1 },
                    { 3, "Olej smarowy", "T208", 3, 1 },
                    { 4, "Poziom oleju smarnego w misie olejowej", "L234", 4, 1 },
                    { 5, "Skrzynia korbowa", "P145", 5, 1 },
                    { 6, "Odbiornik B", "P270", 6, 1 },
                    { 7, "Napięcie akumulatora", "UAKUM", 7, 1 },
                    { 8, "Powietrze rozruchowe", "P371", 8, 1 },
                    { 9, "Powietrze zasysane", "T203", 9, 1 },
                    { 10, "Powietrze zasysane B", "T377", 10, 1 },
                    { 11, "Odbiornik", "T201", 11, 1 },
                    { 12, "Odbiornik B", "T378", 12, 1 },
                    { 13, "Odbiornik", "P232", 13, 1 },
                    { 14, "TEM CU napięcie zasilania", "E149", 14, 1 },
                    { 15, "Położenie przepustnicy", "G197", 15, 1 },
                    { 16, "Prędkość obrotowa silnika", "S200", 16, 1 },
                    { 17, "Moc rzeczywista", "E198.2", 17, 1 },
                    { 18, "Dopuszczalna moc", "E198.6", 18, 1 },
                    { 19, "żądanie aktywne", "E199.7", 19, 1 },
                    { 20, "spaliny za AWT", "T288", 20, 1 },
                    { 21, "Woda chłodz.wylot silnika", "T206", 21, 1 },
                    { 22, "Woda chłodząca wlot silnika", "T207", 22, 1 },
                    { 23, "Ciśnienie doładowania", "P268", 23, 1 },
                    { 24, "Woda chłodząca wlot GK", "T202", 24, 1 },
                    { 25, "GK-chłodnica stołowa wylot", "T405", 25, 1 },
                    { 26, "NK-chłodnica stołowa wylot", "T419", 26, 1 },
                    { 27, "Dopływ wody grzewczej", "T291", 27, 1 },
                    { 28, "Powrót wody grzewczej", "T289", 28, 1 },
                    { 29, "Woda chłodząca przed chłod. awar.", "T384", 29, 1 },
                    { 30, "Woda grzewcza przed KWT", "T290", 30, 1 },
                    { 31, "Woda grzewcza przed AWT", "T385", 31, 1 },
                    { 32, "Łożysko generatora A", "T459", 32, 1 },
                    { 33, "Łożysko generatora B", "T460", 33, 1 },
                    { 34, "Uzwojenie generatora U", "T209", 34, 1 },
                    { 35, "Uzwojenie generatora V", "T210", 35, 1 },
                    { 36, "Uzwojenie generatora W", "T211", 36, 1 },
                    { 37, "Komora spalania A1", "T461", 37, 1 },
                    { 38, "Komora spalania A2", "T462", 38, 1 },
                    { 39, "Komora spalania A3", "T463", 39, 1 },
                    { 40, "Komora spalania A4", "T464", 40, 1 },
                    { 41, "Komora spalania A5", "T465", 41, 1 },
                    { 42, "Komora spalania A6", "T466", 42, 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
                    { 43, "Komora spalania A7", "T467", 43, 1 },
                    { 44, "Komora spalania A8", "T468", 44, 1 },
                    { 45, "Komora spalania A9", "T469", 45, 1 },
                    { 46, "Komora spalania A10", "T470", 46, 1 },
                    { 47, "Komora spalania B1", "T471", 47, 1 },
                    { 48, "Komora spalania B2", "T472", 48, 1 },
                    { 49, "Komora spalania B3", "T473", 49, 1 },
                    { 50, "Komora spalania B4", "T474", 50, 1 },
                    { 51, "Komora spalania B5", "T475", 51, 1 },
                    { 52, "Komora spalania B6", "T476", 52, 1 },
                    { 53, "Komora spalania B7", "T477", 53, 1 },
                    { 54, "Komora spalania B8", "T478", 54, 1 },
                    { 55, "Komora spalania B9", "T479", 55, 1 },
                    { 56, "Komora spalania B10", "T480", 56, 1 },
                    { 57, "Łożysko podstawowe", "T501", 57, 1 },
                    { 58, "Wylot spalin ETC A", "T494", 58, 1 },
                    { 59, "Wylot spalin ETC B", "T495", 59, 1 },
                    { 60, "Prędkość obrotowa ATL A", "S492", 60, 1 },
                    { 61, "Prędkość obrotowa ATL b", "S493", 61, 1 },
                    { 62, "Woda chłodz.wylot silnika", "P497", 62, 1 },
                    { 63, "Olej smarowy za filtrem B", "P318", 63, 1 },
                    { 64, "Położenie zaworu upustowego", "G273", 64, 1 },
                    { 65, "wysterowanie", "GKS", 65, 1 },
                    { 66, "Wysterowanie", "NKS", 66, 1 },
                    { 67, "Częstotliwość generatora", "FGEN", 67, 1 },
                    { 68, "Moc czynna generatora (kW)", "PGEN", 68, 1 },
                    { 69, "Moc bierna generatora (kvar)", "QGEN", 69, 1 },
                    { 70, "Generator współczynnik mocy", "PF", 70, 1 },
                    { 71, "Napięcie generatora L1-2", "UL12G", 71, 1 },
                    { 72, "Napięcie generatora L2-3", "UL23G", 72, 1 },
                    { 73, "generatora L3-1", "UL31GNapięcie", 73, 1 },
                    { 74, "Napięcie generatora L1-N", "UL1G", 74, 1 },
                    { 75, "Napięcie generatora L2-N", "UL2G", 75, 1 },
                    { 76, "Napięcie generatora L3-N", "UL2G", 76, 1 },
                    { 77, "Prąd generatora L1", "IL1G", 77, 1 },
                    { 78, "generatora L2", "IL1G2Prąd", 78, 1 },
                    { 79, "Prąd generatora L3", "IL3G", 79, 1 },
                    { 80, "Częstotliwość sieci", "FM", 80, 1 },
                    { 81, "Napięcie sieci L1-2", "UL12M", 81, 1 },
                    { 82, "Napięcie sieci L2-3", "UL23M", 82, 1 },
                    { 83, "Napięcie sieci L3-1", "UL31M", 83, 1 },
                    { 84, "Napięcie sieci L1-N", "UL1M", 84, 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
                    { 85, "Napięcie sieci L2-N", "UL2M", 85, 1 },
                    { 86, "Napięcie sieci L3-N", "UL3M", 86, 1 },
                    { 87, "Zadana moc czynna aktualna", "PSET", 87, 1 },
                    { 88, "Zadany wspólczynnik mocy aktualny", "PFSET", 88, 1 },
                    { 89, "Zadana moc czynna z SCADA", "PSCADA", 89, 1 },
                    { 90, "Zadany wspólczynnik mocy z SCADA", "PFSCADA", 90, 1 },
                    { 91, "Zadana wartość mocy czynnej - OSD", "POSD", 91, 1 },
                    { 92, "Zadana wartość mocy biernej  - OSD", "QOSD", 92, 1 },
                    { 93, "Zadana wartość współczynnika mocy  - OSD", "PFOSD", 93, 1 },
                    { 94, "Zadana wartość napięcia - OSD", "UOSD", 94, 1 },
                    { 95, "Woda grzewcza przed KWT", "T290", 95, 1 },
                    { 96, "Woda grzewcza przed AWT", "T385", 96, 1 },
                    { 97, "Description", "Rezerwa", 97, 1 },
                    { 98, "Description", "Rezerwa", 98, 1 },
                    { 99, "Description", "Rezerwa", 99, 1 },
                    { 100, "Description", "Rezerwa", 100, 1 },
                    { 101, "Description", "Rezerwa", 101, 1 },
                    { 102, "Description", "Rezerwa", 102, 1 },
                    { 103, "Description", "Rezerwa", 103, 1 },
                    { 104, "Description", "Rezerwa", 104, 1 },
                    { 105, "Description", "Rezerwa", 105, 1 },
                    { 106, "Description", "Rezerwa", 106, 1 },
                    { 107, "Description", "Rezerwa", 107, 1 },
                    { 108, "Description", "Rezerwa", 108, 1 },
                    { 109, "Description", "Rezerwa", 109, 1 },
                    { 110, "Description", "Rezerwa", 110, 1 },
                    { 111, "Description", "Rezerwa", 111, 1 },
                    { 112, "Description", "Rezerwa", 112, 1 },
                    { 113, "Description", "Rezerwa", 113, 1 },
                    { 114, "Description", "Rezerwa", 114, 1 },
                    { 115, "Description", "Rezerwa", 115, 1 },
                    { 116, "Description", "Rezerwa", 116, 1 },
                    { 117, "Description", "Rezerwa", 117, 1 },
                    { 118, "Description", "Rezerwa", 118, 1 },
                    { 119, "Description", "Rezerwa", 119, 1 },
                    { 120, "Description", "Rezerwa", 120, 1 },
                    { 121, "Przepływ chwilowy", "Licznik ciepła", 1, 2 },
                    { 122, "Moc", "Licznik ciepła", 2, 2 },
                    { 123, "Stan licznika", "Licznik ciepła", 3, 2 },
                    { 124, "Energia", "Licznik ciepła", 4, 2 },
                    { 125, "Rezerwa", "Licznik ciepła", 5, 2 },
                    { 126, "Rezerwa", "Licznik ciepła", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
                    { 127, "Rezerwa", "Licznik ciepła", 7, 2 },
                    { 128, "Rezerwa", "Licznik ciepła", 8, 2 },
                    { 129, "Rezerwa", "Licznik ciepła", 9, 2 },
                    { 130, "Powietrze zasysane B", "Licznik ciepła", 10, 2 },
                    { 131, "Temperatura", "Licznik gazu", 1, 3 },
                    { 132, "Licznik Gazu Ciśnienie P1", "Licznik gazu", 2, 3 },
                    { 133, "Ciśnienie Pb", "Licznik gazu", 3, 3 },
                    { 134, "Przepływ Qm", "Licznik gazu", 4, 3 },
                    { 135, "Przepływ Qb", "Licznik gazu", 5, 3 },
                    { 136, "Licznik Vm", "Licznik gazu", 6, 3 },
                    { 137, "Licznik Vb", "Licznik gazu", 7, 3 },
                    { 138, "Licznik energii", "Licznik gazu", 8, 3 },
                    { 139, "Rezerwa", "Licznik gazu", 9, 3 },
                    { 140, "Powietrze zasysane B", "Licznik gazu", 10, 3 },
                    { 141, "Napięcie UL1", "Licznik energi elektrycznej", 1, 4 },
                    { 142, "Napięcie UL2", "Licznik energi elektrycznej", 2, 4 },
                    { 143, "Napięcie UL3", "Licznik energi elektrycznej", 3, 4 },
                    { 144, "Napięcie UL12", "Licznik energi elektrycznej", 4, 1 },
                    { 145, "Napięcie UL23", "Licznik energi elektrycznej", 5, 4 },
                    { 146, "Napięcie UL31", "Licznik energi elektrycznej", 6, 4 },
                    { 147, "Prąd IL1", "Licznik energi elektrycznej", 7, 4 },
                    { 148, "Prąd IL2", "Licznik energi elektrycznej", 8, 4 },
                    { 149, "Prąd IL3", "Licznik energi elektrycznej", 9, 4 },
                    { 150, "Częstotliwość", "Licznik energi elektrycznej", 10, 4 },
                    { 151, "Moc czynna", "Licznik energi elektrycznej", 11, 4 },
                    { 152, "Moc bierna", "Licznik energi elektrycznej", 12, 4 },
                    { 153, "Moc pozorna", "Licznik energi elektrycznej", 13, 4 },
                    { 154, "Współczynnik mocy", "Licznik energi elektrycznej", 14, 4 },
                    { 155, "Energia czynna", "Licznik energi elektrycznej", 15, 4 },
                    { 156, "Energia bierna", "Licznik energi elektrycznej", 15, 4 },
                    { 157, "Energia pozorna", "Licznik energi elektrycznej", 17, 4 },
                    { 158, "Rezerwa", "Licznik energi elektrycznej", 18, 4 },
                    { 159, "Rezerwa", "Licznik energi elektrycznej", 19, 4 },
                    { 160, "Rezerwa", "Licznik energi elektrycznej", 20, 4 },
                    { 161, "Rezerwa", "Inny", 1, 5 },
                    { 162, "Rezerwa", "Inny", 2, 5 },
                    { 163, "Rezerwa", "Inny", 3, 5 },
                    { 164, "Rezerwa", "Inny", 4, 5 },
                    { 165, "Rezerwa", "Inny", 5, 5 },
                    { 166, "Rezerwa", "Inny", 6, 5 },
                    { 167, "Rezerwa", "Inny", 7, 5 },
                    { 168, "Rezerwa", "Inny", 8, 5 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[] { 169, "Rezerwa", "Inny", 9, 5 });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[] { 170, "Powietrze zasysane B", "Inny", 10, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_DeviceId",
                table: "Alarms",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceHeaders_DeviceId",
                table: "DeviceHeaders",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_PlantId",
                table: "Devices",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricCounters_DeviceId",
                table: "ElectricCounters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_DeviceId",
                table: "Engines",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_GasCounters_DeviceId",
                table: "GasCounters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_HeatCounters_DeviceId",
                table: "HeatCounters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCounters_DeviceId",
                table: "OtherCounters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_UserId",
                table: "Plant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePositions_TemplateId",
                table: "TemplatePositions",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "DeviceHeaders");

            migrationBuilder.DropTable(
                name: "ElectricCounters");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "GasCounters");

            migrationBuilder.DropTable(
                name: "HeatCounters");

            migrationBuilder.DropTable(
                name: "OtherCounters");

            migrationBuilder.DropTable(
                name: "TemplatePositions");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Plant");
        }
    }
}
