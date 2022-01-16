using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitManager.Api.Migrations
{
    public partial class dbInitialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    AgentGuid = table.Column<string>(nullable: true),
                    AgentCommissionMultiply = table.Column<float>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AgentOrPlayer = table.Column<int>(nullable: false),
                    IsByOwner = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: false),
                    OwnerGuid = table.Column<string>(nullable: false),
                    LuckyMultiply = table.Column<int>(nullable: false),
                    DefaultMaxAmmountToPlay = table.Column<int>(nullable: false),
                    DeadlineHourAM = table.Column<int>(nullable: false),
                    DeadlineMinutesAM = table.Column<int>(nullable: false),
                    DeadlineHourPM = table.Column<int>(nullable: false),
                    DeadlineMinutesPM = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedData = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "AgentRefreshTokens",
                columns: table => new
                {
                    AgentRefreshTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentRefreshTokens", x => x.AgentRefreshTokenId);
                    table.ForeignKey(
                        name: "FK_AgentRefreshTokens_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MainDigits",
                columns: table => new
                {
                    MainDigitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumStr = table.Column<string>(nullable: true),
                    ShortcutType = table.Column<int>(nullable: false),
                    AmmountOne = table.Column<int>(nullable: false),
                    AmmountTwo = table.Column<int>(nullable: false),
                    VoucherId = table.Column<string>(nullable: true),
                    TotalAmmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IntendedDate = table.Column<DateTime>(nullable: false),
                    MorningOrEvening = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    DescriptionToShowUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDigits", x => x.MainDigitId);
                    table.ForeignKey(
                        name: "FK_MainDigits_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OwnerRefreshTokens",
                columns: table => new
                {
                    OwnerRefreshTokenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerRefreshTokens", x => x.OwnerRefreshTokenId);
                    table.ForeignKey(
                        name: "FK_OwnerRefreshTokens_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDigits",
                columns: table => new
                {
                    SubDigitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TwoNum = table.Column<string>(maxLength: 2, nullable: false),
                    Ammount = table.Column<int>(nullable: false),
                    MainDigitId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDigits", x => x.SubDigitId);
                    table.ForeignKey(
                        name: "FK_SubDigits_MainDigits_MainDigitId",
                        column: x => x.MainDigitId,
                        principalTable: "MainDigits",
                        principalColumn: "MainDigitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "CreatedData", "DeadlineHourAM", "DeadlineHourPM", "DeadlineMinutesAM", "DeadlineMinutesPM", "DefaultMaxAmmountToPlay", "IsActive", "LuckyMultiply", "Mobile", "OwnerGuid", "Password", "UpdatedDate", "UserName" },
                values: new object[] { 1, new DateTime(2020, 11, 18, 16, 7, 35, 834, DateTimeKind.Utc).AddTicks(412), 11, 4, 45, 0, 1000000, true, 80, "099192939495", "11dcfc53-0333-4a63-8654-cbc5f954a02a", "lM+LLEuQMvM0J10MCEh5h+1EZdBoXPTz0oj3iA1fZMY=", new DateTime(2020, 11, 18, 16, 7, 35, 834, DateTimeKind.Utc).AddTicks(881), "adminakt" });

            migrationBuilder.CreateIndex(
                name: "IX_AgentRefreshTokens_AgentId",
                table: "AgentRefreshTokens",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_MainDigits_AgentId",
                table: "MainDigits",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerRefreshTokens_OwnerId",
                table: "OwnerRefreshTokens",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDigits_MainDigitId",
                table: "SubDigits",
                column: "MainDigitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentRefreshTokens");

            migrationBuilder.DropTable(
                name: "OwnerRefreshTokens");

            migrationBuilder.DropTable(
                name: "SubDigits");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "MainDigits");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
