using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManager.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Bytes = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectScopeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScopeTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubContractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubContractors", x => x.Id);
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
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToolStatus = table.Column<int>(type: "int", nullable: false),
                    DateOfPurchase = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkScopeTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProjectType = table.Column<int>(type: "int", nullable: false),
                    WorkScopeType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkScopeTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectScopePositionTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectScopeTemplateId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScopePositionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectScopePositionTemplates_ProjectScopeTemplates_ProjectScopeTemplateId",
                        column: x => x.ProjectScopeTemplateId,
                        principalTable: "ProjectScopeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSettingPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ProjectSettingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSettingPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSettingPositions_ProjectSettings_ProjectSettingId",
                        column: x => x.ProjectSettingId,
                        principalTable: "ProjectSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SettingsPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingsPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingsPositions_Settings_SettingsId",
                        column: x => x.SettingsId,
                        principalTable: "Settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubConAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubContractorId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StreetNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubConAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubConAddresses_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
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
                name: "WorkScopePositionTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkScopeTemplateId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkScopePositionTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkScopePositionTemplates_WorkScopeTemplates_WorkScopeTemplateId",
                        column: x => x.WorkScopeTemplateId,
                        principalTable: "WorkScopeTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Est = table.Column<int>(type: "int", nullable: false),
                    Lst = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predecessor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predecessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predecessor_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsFullDay = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEvents_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    WebsiteRaw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserPMId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DesignEngId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectricEngId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserUpdatorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Sharepoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_DesignEngId",
                        column: x => x.DesignEngId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_ElectricEngId",
                        column: x => x.ElectricEngId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserPMId",
                        column: x => x.UserPMId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserUpdatorId",
                        column: x => x.UserUpdatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ToolRentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolRentals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToolRentals_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectScopes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectScopes_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settlements_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserFromId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserToId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_AspNetUsers_UserFromId",
                        column: x => x.UserFromId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Todos_AspNetUsers_UserToId",
                        column: x => x.UserToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Todos_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
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

            migrationBuilder.CreateTable(
                name: "PostReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostReplies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostReplies_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectScopePositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    NotApplicable = table.Column<bool>(type: "bit", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProjectScopeId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectScopePositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectScopePositions_ProjectScopes_ProjectScopeId",
                        column: x => x.ProjectScopeId,
                        principalTable: "ProjectScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectScopePositions_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Assumptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettlementId = table.Column<int>(type: "int", nullable: false),
                    MarginGen = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MarginInstall = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Maturity = table.Column<int>(type: "int", nullable: false),
                    CompanyCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompanyGuarantee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Insurance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assumptions_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkScopes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettlementId = table.Column<int>(type: "int", nullable: false),
                    WorkScopeType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkScopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkScopes_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoReplies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TodoReplies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoReplies_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TodoToUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TodoId = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoToUsers_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TodoToUsers_Todos_TodoId",
                        column: x => x.TodoId,
                        principalTable: "Todos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PositionPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PositionPosts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PositionPosts_ProjectScopePositions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "ProjectScopePositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroNetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SettlementId = table.Column<int>(type: "int", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkScopeId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_WorkScopes_WorkScopeId",
                        column: x => x.WorkScopeId,
                        principalTable: "WorkScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkScopeCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkScopeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CostStatusType = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    Order = table.Column<int>(type: "int", nullable: false),
                    UnitType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroNetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkScopeCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkScopeCosts_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkScopeCosts_WorkScopes_WorkScopeId",
                        column: x => x.WorkScopeId,
                        principalTable: "WorkScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkScopeOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkScopeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    UnitType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroNetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EuroRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkScopeOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkScopeOffers_SubContractors_SubContractorId",
                        column: x => x.SubContractorId,
                        principalTable: "SubContractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkScopeOffers_WorkScopes_WorkScopeId",
                        column: x => x.WorkScopeId,
                        principalTable: "WorkScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ADE32A3F-6149-475A-8155-CFE5D69ACA42", "B50B7D83-F6E6-4DE3-8346-7D0E8501EEB5", "Pracownik", "PRACOWNIK" },
                    { "C854A873-3D75-4973-AD7E-A83C95726133", "C778085D-D407-4936-8A19-350C6817AA5D", "Administrator", "ADMINISTRATOR" },
                    { "EC23C152-A1C5-4D9A-B8D4-FAE62D5F059D", "A1277894-E24D-490E-A3BA-83F9CF5F838D", "Kierownik", "KIEROWNIK" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ContactPerson", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, null, null, "Klient domyślny", null });

            migrationBuilder.InsertData(
                table: "ProjectScopeTemplates",
                columns: new[] { "Id", "Description", "Order", "ProjectType" },
                values: new object[,]
                {
                    { 1, "Zestaw kogeneracyjny Caterpillar", 1, 0 },
                    { 2, "Projekt i uruchomienie", 2, 0 },
                    { 3, "Instalacja elektryczna", 3, 0 },
                    { 4, "Układ chłodzenia i produkcji ciepłej wody z bloku silnika", 4, 0 },
                    { 5, "Układ odprowadzenia spalin", 5, 0 },
                    { 6, "Ścieżka gazowa", 6, 0 },
                    { 7, "Układ gospodarki oleju silnikowego", 7, 0 },
                    { 8, "Obudowa kontenerowa zespołu prądotwórczego oraz prace budowlane", 8, 0 },
                    { 9, "Opomiarowanie", 9, 0 },
                    { 10, "Instalacje technologiczne – odzysk ciepła, instalacja gazowa", 10, 0 },
                    { 11, "Dostawa nadrzędnego systemu sterowania", 11, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProjectSettings",
                columns: new[] { "Id", "ProjectType" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Description", "Order" },
                values: new object[,]
                {
                    { 1, "E-mail", 2 },
                    { 2, "Ogólne", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubContractors",
                columns: new[] { "Id", "ContactPerson", "Email", "Name", "PhoneNumber" },
                values: new object[] { 1, null, null, "Bergerat Monnoyeur", null });

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
                table: "WorkScopeTemplates",
                columns: new[] { "Id", "Description", "Order", "ProjectType", "WorkScopeType" },
                values: new object[,]
                {
                    { 1, "Agregat", 1, 0, 0 },
                    { 2, "Prace budowlano-konstrukcyjne", 2, 0, 1 },
                    { 3, "Układ chłodzenia i wyprowadzenia ciepła", 3, 0, 1 },
                    { 4, "Wentylacja", 4, 0, 1 },
                    { 5, "Instalacje elektryczne", 5, 0, 1 },
                    { 6, "Instalacja gazowa", 6, 0, 1 },
                    { 7, "Zarządzenie projektem, dokumenetacja techniczna, rozruchy", 7, 0, 2 },
                    { 8, "Zespół prądotwórczy", 1, 1, 0 },
                    { 9, "Zespół prądotwórczy - Logistyka", 2, 1, 0 },
                    { 10, "Instalacje elektryczne", 3, 1, 1 },
                    { 11, "Układ chłodzenia silnika", 4, 1, 1 },
                    { 12, "Układ odprowadzenia spalin", 5, 1, 1 },
                    { 13, "Instalacja paliwowa", 6, 1, 1 },
                    { 14, "Instalacja olejowa", 7, 1, 1 },
                    { 15, "Wentylacja", 8, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "WorkScopeTemplates",
                columns: new[] { "Id", "Description", "Order", "ProjectType", "WorkScopeType" },
                values: new object[] { 16, "Prace budowlano-konstrukcyjne", 9, 1, 1 });

            migrationBuilder.InsertData(
                table: "WorkScopeTemplates",
                columns: new[] { "Id", "Description", "Order", "ProjectType", "WorkScopeType" },
                values: new object[] { 17, "Zarządzenie projektem, dokumenetacja techniczna, rozruchy", 10, 1, 2 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "ClientId", "Street", "StreetNumber", "ZipCode" },
                values: new object[] { 1, null, 1, null, null, null });

            migrationBuilder.InsertData(
                table: "ProjectScopePositionTemplates",
                columns: new[] { "Id", "Description", "Order", "ProjectScopeTemplateId" },
                values: new object[,]
                {
                    { 1, "Dostawa", 1, 1 },
                    { 2, "Projekt wykonawczy elektryczny", 1, 2 },
                    { 3, "Projekt wykonawczy automatyki", 2, 2 },
                    { 4, "Projekt powykonawczy elektryczny", 3, 2 },
                    { 5, "Projekt powykonawczy automatyki", 4, 2 },
                    { 6, "Projekt wykonawczy obudowy", 5, 2 },
                    { 7, "Projekt powykonawczy obudowy", 6, 2 },
                    { 8, "Szkolenie personelu.", 7, 2 },
                    { 9, "Dokumentacja dla zespołu w języku polskim - 2 egzemplarze", 8, 2 },
                    { 10, "Rozruch i regulacja urządzeń", 9, 2 },
                    { 11, "Ośmiogodzinny ruch próbny", 10, 2 },
                    { 12, "Dokumentacja dla URE.", 11, 2 },
                    { 13, "Wsparcie w przygotowaniu dokumentów o udzielenie koncesji na wytwarzanie energii elektrycznej", 12, 2 },
                    { 14, "Wsparcie w złożeniu pierwszego wniosku o wypłatę premii gwarantowanej", 13, 2 },
                    { 15, "Wsparcie w przygotowaniu planu przeprowadzenia testów NCRfG", 14, 2 },
                    { 16, "Przeprowadzenie testów NCRfG", 15, 2 },
                    { 17, "Rezerwa", 16, 2 },
                    { 18, "Okablowanie potrzeb własnych zestawu kogeneracyjnego", 2, 3 },
                    { 19, "Dostawa szaf do sterowania zespołem kogeneracyjnym, urządzeń pomocniczych i synchronizacji z siecią elektroenergetyczną", 3, 3 },
                    { 20, "Wykonanie połączeń elektrycznych i AKPiA do szaf sterowania zespołem kogeneracyjnym", 4, 3 },
                    { 21, "Dostawa stacji transformatorowej", 5, 3 },
                    { 22, "Wyprowadzenie mocy – nN od generatora do transformatora", 6, 3 },
                    { 23, "Wyprowadzenie mocy – SN od tranformatora do rozdzielnicy SN", 7, 3 },
                    { 24, "Modernizacja rozdzielni SN", 8, 3 },
                    { 25, "Przystosowanie szaf AKPiA na potrzeby systemu SCADA - udostępnienie sygnałów", 9, 3 },
                    { 26, "Rezerwa", 10, 3 },
                    { 27, "Układ LT wraz z chłodnicą, orurowaniem, pompą, zaworami, armaturą,", 2, 4 },
                    { 28, "Układ HT wraz z chłodnicą, orurowaniem, pompą, zaworami, armaturą,", 3, 4 },
                    { 29, "Montaż urządzeń wchodzących w skład układu odzysku ciepła (pompy, wymiennik separacyjny, armatura odcinająca i regulacyjna, czujniki)", 4, 4 },
                    { 30, "Wykonanie orurowania", 5, 4 },
                    { 31, "Próby pomontażowe szczelności", 6, 4 },
                    { 32, "Rezerwa", 7, 4 },
                    { 33, "Tłumik hałasu", 2, 5 },
                    { 34, "Wymiennik poziomy spaliny/woda-glikol", 3, 5 },
                    { 35, "Wykonanie i montaż komina wyrzutu spalin", 4, 5 },
                    { 36, "Diverter", 5, 5 },
                    { 37, "Rezerwa", 6, 5 },
                    { 38, "Przewód elastyczny łączący ścieżkę gazową z silnikiem", 2, 6 },
                    { 39, "Ścieżka gazowa wewnątrz maszynowni", 3, 6 },
                    { 40, "System wykrywania niebezpiecznego stężenia gazu - MAG3", 4, 6 },
                    { 41, "Rezerwa", 5, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProjectScopePositionTemplates",
                columns: new[] { "Id", "Description", "Order", "ProjectScopeTemplateId" },
                values: new object[,]
                {
                    { 42, "Instalacja olejowa - zbiornik oleju z automatycznym uzupełnieniem.", 2, 7 },
                    { 43, "Płyn chłodniczy i olej", 3, 7 },
                    { 44, "Dostawa i zalanie układu olejowego olejem silnikowym.", 4, 7 },
                    { 45, "Dostawa i zalanie układu płynem chłodzącym", 5, 7 },
                    { 46, "Rezerwa", 6, 7 },
                    { 47, "Wykonanie obudowy dźwiękochłonnej", 2, 8 },
                    { 48, "Wykonanie kompletnego układu wentylacji do obudowy", 3, 8 },
                    { 49, "Wykonanie instalacji oświetleniowej i gniazd wtyczkowych", 4, 8 },
                    { 50, "Układ pomiarowy energii elektrycznej netto", 1, 9 },
                    { 51, "Układ pomiarowy energii elektrycznej brutto", 2, 9 },
                    { 52, "Układ pomiarowy energii elektrycznej potrzeb własnych", 3, 9 },
                    { 53, "Licznik gazu z korektorem objętościowym", 4, 9 },
                    { 54, "Licznik produkcji ciepła", 5, 9 },
                    { 55, "Instalacja gazowa", 1, 10 },
                    { 56, "Instalacja odzysku ciepła ze spalin", 2, 10 },
                    { 57, "Instalacja odzysku ciepła z bloku z silnika", 3, 10 },
                    { 58, "Kable grzewcze dla dostarczanych instalacji", 4, 10 },
                    { 59, "Sterownik PLC + panel HMI", 1, 11 },
                    { 60, "System nadrzędny SCADA - licencje + komputer i monitor", 2, 11 },
                    { 61, "Okablowanie i trasy kablowe", 3, 11 },
                    { 62, "Prefabrykacja szaf", 4, 11 },
                    { 63, "Montaż tras kablowych i kabli", 5, 11 },
                    { 64, "Rozruch, uruchomienie, optymalizacja.", 6, 11 }
                });

            migrationBuilder.InsertData(
                table: "SettingsPositions",
                columns: new[] { "Id", "Description", "Key", "Order", "SettingsId", "Type", "Value" },
                values: new object[,]
                {
                    { 1, "Host", "HostSmtp", 1, 1, 0, "smtp.gmail.com" },
                    { 2, "Port", "Port", 2, 1, 2, "587" },
                    { 3, "Adres e-mail nadawcy", "SenderEmail", 3, 1, 0, "" },
                    { 4, "Hasło", "SenderEmailPassword", 4, 1, 4, "" },
                    { 5, "Nazwa nadawcy", "SenderName", 5, 1, 0, "Administrator" },
                    { 6, "Login nadawcy", "SenderLogin", 6, 1, 0, "" },
                    { 7, "Czy wyświetlać banner na stronie głównej?", "BannerVisible", 1, 2, 1, "True" },
                    { 8, "Folor footera strona głównej", "FooterColor", 2, 2, 5, "#dc3545" },
                    { 9, "Główny adres e-mail administratora", "AdminEmail", 3, 2, 0, "integri.pp@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "SubConAddresses",
                columns: new[] { "Id", "City", "Street", "StreetNumber", "SubContractorId", "ZipCode" },
                values: new object[] { 1, null, null, null, 1, null });

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
                    { 9, "Powietrze zasysane", "T203", 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
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
                    { 42, "Komora spalania A6", "T466", 42, 1 },
                    { 43, "Komora spalania A7", "T467", 43, 1 },
                    { 44, "Komora spalania A8", "T468", 44, 1 },
                    { 45, "Komora spalania A9", "T469", 45, 1 },
                    { 46, "Komora spalania A10", "T470", 46, 1 },
                    { 47, "Komora spalania B1", "T471", 47, 1 },
                    { 48, "Komora spalania B2", "T472", 48, 1 },
                    { 49, "Komora spalania B3", "T473", 49, 1 },
                    { 50, "Komora spalania B4", "T474", 50, 1 },
                    { 51, "Komora spalania B5", "T475", 51, 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
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
                    { 84, "Napięcie sieci L1-N", "UL1M", 84, 1 },
                    { 85, "Napięcie sieci L2-N", "UL2M", 85, 1 },
                    { 86, "Napięcie sieci L3-N", "UL3M", 86, 1 },
                    { 87, "Zadana moc czynna aktualna", "PSET", 87, 1 },
                    { 88, "Zadany wspólczynnik mocy aktualny", "PFSET", 88, 1 },
                    { 89, "Zadana moc czynna z SCADA", "PSCADA", 89, 1 },
                    { 90, "Zadany wspólczynnik mocy z SCADA", "PFSCADA", 90, 1 },
                    { 91, "Zadana wartość mocy czynnej - OSD", "POSD", 91, 1 },
                    { 92, "Zadana wartość mocy biernej  - OSD", "QOSD", 92, 1 },
                    { 93, "Zadana wartość współczynnika mocy  - OSD", "PFOSD", 93, 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
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
                    { 126, "Rezerwa", "Licznik ciepła", 6, 2 },
                    { 127, "Rezerwa", "Licznik ciepła", 7, 2 },
                    { 128, "Rezerwa", "Licznik ciepła", 8, 2 },
                    { 129, "Rezerwa", "Licznik ciepła", 9, 2 },
                    { 130, "Powietrze zasysane B", "Licznik ciepła", 10, 2 },
                    { 131, "Temperatura", "Licznik gazu", 1, 3 },
                    { 132, "Licznik Gazu Ciśnienie P1", "Licznik gazu", 2, 3 },
                    { 133, "Ciśnienie Pb", "Licznik gazu", 3, 3 },
                    { 134, "Przepływ Qm", "Licznik gazu", 4, 3 },
                    { 135, "Przepływ Qb", "Licznik gazu", 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "TemplatePositions",
                columns: new[] { "Id", "Description", "Name", "Order", "TemplateId" },
                values: new object[,]
                {
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
                    { 168, "Rezerwa", "Inny", 8, 5 },
                    { 169, "Rezerwa", "Inny", 9, 5 },
                    { 170, "Powietrze zasysane B", "Inny", 10, 5 }
                });

            migrationBuilder.InsertData(
                table: "WorkScopePositionTemplates",
                columns: new[] { "Id", "Description", "Order", "WorkScopeTemplateId" },
                values: new object[,]
                {
                    { 1, "Agregat", 1, 1 },
                    { 2, "Agregat - transport", 2, 1 },
                    { 3, "Fundament", 1, 2 },
                    { 4, "Zagospodarowanie terenu", 2, 2 },
                    { 5, "Przepusty przez ścianę kotłowni", 3, 2 },
                    { 6, "Kanalizacja deszczowa i technologiczna", 4, 2 },
                    { 7, "Zabudowa kontenerowa", 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "WorkScopePositionTemplates",
                columns: new[] { "Id", "Description", "Order", "WorkScopeTemplateId" },
                values: new object[,]
                {
                    { 8, "Rezerwa", 6, 2 },
                    { 9, "Rezerwa", 7, 2 },
                    { 10, "Obieg LT, chłodnica", 1, 3 },
                    { 11, "Obieg LT, zawór równoważący", 2, 3 },
                    { 12, "Obieg LT, naczynie membranowe 3 bar z zestawem przyłączeniowym", 3, 3 },
                    { 13, "Obieg LT, pompa", 4, 3 },
                    { 14, "Obieg LT, kompensatory elastyczne", 5, 3 },
                    { 15, "Obieg LT, przepustnice odcinające", 6, 3 },
                    { 16, "Obieg LT, zawór bezpieczeństwa 1915 3bar", 7, 3 },
                    { 17, "Obieg LT, filtr kołnierzowy", 8, 3 },
                    { 18, "Obieg LT, odpowietrzniki", 9, 3 },
                    { 19, "Obieg LT, czujniki, wskaźniki temperatury itp.", 10, 3 },
                    { 20, "Obieg LT, wymiennik separacyjny płytowy", 11, 3 },
                    { 21, "Obieg LT - rezerwa", 12, 3 },
                    { 22, "Obieg LT - rezerwa", 13, 3 },
                    { 23, "Obieg HT, chłodnica", 14, 3 },
                    { 24, "Obieg HT, pompa obiegu", 15, 3 },
                    { 25, "Obieg HT, wymiennik separacyjny płytowy", 16, 3 },
                    { 26, "Obieg HT, zawór równoważący", 17, 3 },
                    { 27, "Obieg HT, naczynie membranowe 10 bar z zestawem przyłączeniowym", 18, 3 },
                    { 28, "Obieg HT, naczynie schładzające 10bar", 19, 3 },
                    { 29, "Obieg HT, przepustnice odcinające", 20, 3 },
                    { 30, "Obieg HT, zawór bezpieczeństwa 1915 10bar", 21, 3 },
                    { 31, "Obieg HT, filtr kołnierzowy", 22, 3 },
                    { 32, "Obieg HT, odpowietrzniki", 23, 3 },
                    { 33, "Obieg HT, czujniki, wskaźniki temperatury itp.", 24, 3 },
                    { 34, "Obieg HT, kompensatory elastyczne", 25, 3 },
                    { 35, "Obieg HT, zawór bezpieczeństwa 1915 3 bar", 26, 3 },
                    { 36, "Obieg HT, zawór bezpieczeństwa 1915 10 bar", 27, 3 },
                    { 37, "Obieg HT, zabezpieczenia Presostaty i Termostaty", 28, 3 },
                    { 38, "Obieg HT, odpowietrzniki", 29, 3 },
                    { 39, "Obieg HT, filtr kołnierzowy", 30, 3 },
                    { 40, "Obieg HT, Czujniki, wskaźniki temperatury itp.", 31, 3 },
                    { 41, "Rury HT / LT", 32, 3 },
                    { 42, "Izolacja, osłony rury, prace dodatkowe", 33, 3 },
                    { 43, "Automatyczny układ do oleju", 34, 3 },
                    { 44, "Zbiornik oleju", 35, 3 },
                    { 45, "Olej silnikowy", 36, 3 },
                    { 46, "Mieszanka Glikol/Woda 50/50", 37, 3 },
                    { 47, "Kable grzewcze", 38, 3 },
                    { 48, "Instalacje technologiczne: gaz, ciepło - kotłownia - kogeneracja", 39, 3 },
                    { 49, "Układ pompowy - obieg wymiennik spaliny/woda", 40, 3 }
                });

            migrationBuilder.InsertData(
                table: "WorkScopePositionTemplates",
                columns: new[] { "Id", "Description", "Order", "WorkScopeTemplateId" },
                values: new object[,]
                {
                    { 50, "Instalacja odzysku ciepła z bloku silnika oraz spalin", 41, 3 },
                    { 51, "Instalacja odzysku ciepła - wyprowadzenie ciepła", 42, 3 },
                    { 52, "Instalacje technologiczne: gaz, ciepło - kotłownia - kogeneracja", 43, 3 },
                    { 53, "Licznik ciepła z przepływomierzem ultradźwiękowym", 44, 3 },
                    { 54, "Zawory odcinajace na obiegach grzewczych", 45, 3 },
                    { 55, "Obieg HT - rezerwa", 46, 3 },
                    { 56, "Obieg HT - rezerwa", 47, 3 },
                    { 57, "Wentylatory", 1, 4 },
                    { 58, "Klimatizator AKPiA", 2, 4 },
                    { 59, "Wentylator EX", 3, 4 },
                    { 60, "Przepustnice", 4, 4 },
                    { 61, "Kulisy tłumiące", 5, 4 },
                    { 62, "Montaż układu wentylacji", 6, 4 },
                    { 63, "Wentylacja - rezerwa", 7, 4 },
                    { 64, "Okablowanie potrzeb własnych", 1, 5 },
                    { 65, "Instalacje uziemienia i odgromowa", 2, 5 },
                    { 66, "Instalacje oświetlenia i gniazd wtyczkowych", 3, 5 },
                    { 67, "Szafa sterowania AX", 4, 5 },
                    { 68, "Rozdzielnica GCB", 5, 5 },
                    { 69, "Falowniki", 6, 5 },
                    { 70, "Wyprowadzenie mocy", 7, 5 },
                    { 71, "Transformator", 8, 5 },
                    { 72, "Pomiary transformatora, uruchomienie", 9, 5 },
                    { 73, "Okablowanie stacji", 10, 5 },
                    { 74, "Wyprowadzenie mocy TR-RGSN", 11, 5 },
                    { 75, "Rozbudowa istniejącej rozdzielnicy SN", 12, 5 },
                    { 76, "Przeciski sterowane", 13, 5 },
                    { 77, "Wyprowadzenie sygnałów - SCADA", 14, 5 },
                    { 78, "System sterowania SCADA - kogeneracja", 15, 5 },
                    { 79, "Dostawa stacji transformatorowej", 16, 5 },
                    { 80, "Obudowa transformatora", 17, 5 },
                    { 81, "Posadowienie stacji", 18, 5 },
                    { 82, "Układ pomiarowy energii elektrycznej na zaciskach generatora", 19, 5 },
                    { 83, "Instalacje dodatkowe komunikacja światłowodowa", 20, 5 },
                    { 84, "Dostawa rozdzielnicy SN, montaż", 21, 5 },
                    { 85, "Zakup i ułożenie kabla pożarowego wyłącznika prądu", 22, 5 },
                    { 86, "Wykonanie mostu kablowego", 23, 5 },
                    { 87, "Modyfikacja architektury systemu SCADA", 24, 5 },
                    { 88, "Stacja redukcji gazu", 1, 6 },
                    { 89, "Zawór kulowy", 2, 6 },
                    { 90, "Gazex, zawór odcinający, instalacja bezpieczeństwa", 3, 6 },
                    { 91, "Wykonanie przyłącza gazowego - od skrzynki gazowej do kontenera", 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "WorkScopePositionTemplates",
                columns: new[] { "Id", "Description", "Order", "WorkScopeTemplateId" },
                values: new object[,]
                {
                    { 92, "Licznik gazu + Korektor obiętościowy ", 5, 6 },
                    { 93, "Projekt wykonawczy Elektryka / Automatyka", 1, 7 },
                    { 94, "Projekty wykonawcze kontener", 2, 7 },
                    { 95, "Projekt budowlany", 3, 7 },
                    { 96, "Odbiór UDT", 4, 7 },
                    { 97, "Uruchomienie i rozruch (Eneria)", 5, 7 },
                    { 98, "Szkolenie operatorów", 6, 7 },
                    { 99, "Zespół prądotwórczy", 1, 9 },
                    { 100, "Transport zespołu prądotwórczego", 2, 9 },
                    { 101, "Dodatkowe akumulatory", 3, 9 },
                    { 102, "Instalacja zasilania potrzeb własnych ( agregat+instacja paliwowa) z zabezpieczeniami", 1, 10 },
                    { 103, "Elastyczne połączenia generatora z szynoprzewodem", 2, 10 },
                    { 104, "Układ chłodzenia - rezerwa", 1, 11 },
                    { 105, "Tłumik spalin o tłumienności 40 db", 1, 12 },
                    { 106, "Instalacja wyrzutu spalin wraz z okuciem tłumika", 2, 12 },
                    { 107, "Zbiornik dzienny ROTH 1000 L", 1, 13 },
                    { 108, "Okablowanie instalacji paliwowej", 2, 13 },
                    { 109, "Zbiornik podziemny dwupłaszczowy, o poj. ..... 34 m3", 3, 13 },
                    { 110, "Wykonanie ochrony katodowej zbiorników", 4, 13 },
                    { 111, "Automatyka układu paliwowego", 5, 13 },
                    { 112, "Rury Brugg", 6, 13 },
                    { 113, "Instalacja paliwowa - rezerwa", 7, 13 },
                    { 114, "Instalacja olejowa - rezerwa", 1, 14 },
                    { 115, "Wentylatory", 1, 15 },
                    { 116, "Pzrepustnice", 2, 15 },
                    { 117, "Czerpnia", 3, 15 },
                    { 118, "Wyrzutnia", 4, 15 },
                    { 119, "Tłumniki akustyczne", 5, 15 },
                    { 120, "Montaż instalacji wentylacyjnej", 6, 15 },
                    { 121, "Prace budowlano-konstrukcyjne - rezerwa", 1, 16 },
                    { 122, "Prace budowlano-konstrukcyjne - rezerwa", 2, 16 },
                    { 123, "Prace budowlano-konstrukcyjne - rezerwa", 3, 16 },
                    { 124, "Testy agregatu w fabryce (FAT)", 1, 17 },
                    { 125, "Wynajem kontenera socjalnego na czas budowy", 2, 17 },
                    { 126, "Dokumentacja", 3, 17 },
                    { 127, "Uruchomienie i szkolenie", 4, 17 },
                    { 128, "Testy z obciążalnikiem", 5, 17 },
                    { 129, "Paliwo", 6, 17 },
                    { 130, "Rezerwa", 7, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ScheduleId",
                table: "Activities",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ClientId",
                table: "Addresses",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alarms_DeviceId",
                table: "Alarms",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ScheduleId",
                table: "AspNetUsers",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assumptions_SettlementId",
                table: "Assumptions",
                column: "SettlementId",
                unique: true);

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
                name: "IX_EmployeeEvents_UserId",
                table: "EmployeeEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

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
                name: "IX_Invoices_SettlementId",
                table: "Invoices",
                column: "SettlementId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_WorkScopeId",
                table: "Invoices",
                column: "WorkScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherCounters_DeviceId",
                table: "OtherCounters",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Plant_UserId",
                table: "Plant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPosts_PositionId",
                table: "PositionPosts",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionPosts_UserId",
                table: "PositionPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_PostId",
                table: "PostReplies",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostReplies_UserId",
                table: "PostReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProjectId",
                table: "Posts",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Predecessor_ActivityId",
                table: "Predecessor",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DesignEngId",
                table: "Projects",
                column: "DesignEngId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ElectricEngId",
                table: "Projects",
                column: "ElectricEngId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserID",
                table: "Projects",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserPMId",
                table: "Projects",
                column: "UserPMId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserUpdatorId",
                table: "Projects",
                column: "UserUpdatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScopePositions_ProjectScopeId",
                table: "ProjectScopePositions",
                column: "ProjectScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScopePositions_SubContractorId",
                table: "ProjectScopePositions",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScopePositionTemplates_ProjectScopeTemplateId",
                table: "ProjectScopePositionTemplates",
                column: "ProjectScopeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScopes_ApplicationUserId",
                table: "ProjectScopes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectScopes_ProjectId",
                table: "ProjectScopes",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSettingPositions_ProjectSettingId",
                table: "ProjectSettingPositions",
                column: "ProjectSettingId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ProjectId",
                table: "Schedules",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserID",
                table: "Schedules",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SettingsPositions_SettingsId",
                table: "SettingsPositions",
                column: "SettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_ProjectId",
                table: "Settlements",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settlements_UserId",
                table: "Settlements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubConAddresses_SubContractorId",
                table: "SubConAddresses",
                column: "SubContractorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePositions_TemplateId",
                table: "TemplatePositions",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoReplies_ApplicationUserId",
                table: "TodoReplies",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoReplies_TodoId",
                table: "TodoReplies",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoReplies_UserId",
                table: "TodoReplies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_ProjectId",
                table: "Todos",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserFromId",
                table: "Todos",
                column: "UserFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserToId",
                table: "Todos",
                column: "UserToId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoToUsers_TodoId",
                table: "TodoToUsers",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoToUsers_UserID",
                table: "TodoToUsers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ToolRentals_ToolId",
                table: "ToolRentals",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolRentals_UserId",
                table: "ToolRentals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkScopeCosts_SubContractorId",
                table: "WorkScopeCosts",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkScopeCosts_WorkScopeId",
                table: "WorkScopeCosts",
                column: "WorkScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkScopeOffers_SubContractorId",
                table: "WorkScopeOffers",
                column: "SubContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkScopeOffers_WorkScopeId",
                table: "WorkScopeOffers",
                column: "WorkScopeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkScopePositionTemplates_WorkScopeTemplateId",
                table: "WorkScopePositionTemplates",
                column: "WorkScopeTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkScopes_SettlementId",
                table: "WorkScopes",
                column: "SettlementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_AspNetUsers_UserId",
                table: "Activities",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Schedules_ScheduleId",
                table: "Activities",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alarms_Devices_DeviceId",
                table: "Alarms",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Schedules_ScheduleId",
                table: "AspNetUsers",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_DesignEngId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_ElectricEngId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserPMId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_UserUpdatorId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_UserID",
                table: "Schedules");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Assumptions");

            migrationBuilder.DropTable(
                name: "DeviceHeaders");

            migrationBuilder.DropTable(
                name: "ElectricCounters");

            migrationBuilder.DropTable(
                name: "EmployeeEvents");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "GasCounters");

            migrationBuilder.DropTable(
                name: "HeatCounters");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OtherCounters");

            migrationBuilder.DropTable(
                name: "PositionPosts");

            migrationBuilder.DropTable(
                name: "PostReplies");

            migrationBuilder.DropTable(
                name: "Predecessor");

            migrationBuilder.DropTable(
                name: "ProjectScopePositionTemplates");

            migrationBuilder.DropTable(
                name: "ProjectSettingPositions");

            migrationBuilder.DropTable(
                name: "SettingsPositions");

            migrationBuilder.DropTable(
                name: "SubConAddresses");

            migrationBuilder.DropTable(
                name: "TemplatePositions");

            migrationBuilder.DropTable(
                name: "TodoReplies");

            migrationBuilder.DropTable(
                name: "TodoToUsers");

            migrationBuilder.DropTable(
                name: "ToolRentals");

            migrationBuilder.DropTable(
                name: "WorkScopeCosts");

            migrationBuilder.DropTable(
                name: "WorkScopeOffers");

            migrationBuilder.DropTable(
                name: "WorkScopePositionTemplates");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "ProjectScopePositions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ProjectScopeTemplates");

            migrationBuilder.DropTable(
                name: "ProjectSettings");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "WorkScopes");

            migrationBuilder.DropTable(
                name: "WorkScopeTemplates");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "ProjectScopes");

            migrationBuilder.DropTable(
                name: "SubContractors");

            migrationBuilder.DropTable(
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
