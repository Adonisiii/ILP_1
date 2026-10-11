using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxPayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CurrentStep = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationRequests_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationRequests_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_ApplicationRequests_ApplicationRequestId",
                        column: x => x.ApplicationRequestId,
                        principalTable: "ApplicationRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Activities_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Annexes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annexes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annexes_ApplicationRequests_ApplicationRequestId",
                        column: x => x.ApplicationRequestId,
                        principalTable: "ApplicationRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Annexes_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Annexes_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnnualPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ApplicationRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualPlans_ApplicationRequests_ApplicationRequestId",
                        column: x => x.ApplicationRequestId,
                        principalTable: "ApplicationRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnnualPlans_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnnualPlans_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApplicationDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_ApplicationRequests_ApplicationRequestId",
                        column: x => x.ApplicationRequestId,
                        principalTable: "ApplicationRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicationDocuments_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnnualPlanItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TariffNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnnualPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualPlanItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualPlanItems_AnnualPlans_AnnualPlanId",
                        column: x => x.AnnualPlanId,
                        principalTable: "AnnualPlans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnnualPlanItems_Users_CreateUserId",
                        column: x => x.CreateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnnualPlanItems_Users_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ApplicationRequestId",
                table: "Activities",
                column: "ApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CreateUserId",
                table: "Activities",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UpdateUserId",
                table: "Activities",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Annexes_ApplicationRequestId",
                table: "Annexes",
                column: "ApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Annexes_CreateUserId",
                table: "Annexes",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Annexes_UpdateUserId",
                table: "Annexes",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualPlanItems_AnnualPlanId",
                table: "AnnualPlanItems",
                column: "AnnualPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualPlanItems_CreateUserId",
                table: "AnnualPlanItems",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualPlanItems_UpdateUserId",
                table: "AnnualPlanItems",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualPlans_ApplicationRequestId",
                table: "AnnualPlans",
                column: "ApplicationRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnnualPlans_CreateUserId",
                table: "AnnualPlans",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualPlans_UpdateUserId",
                table: "AnnualPlans",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_ApplicationRequestId",
                table: "ApplicationDocuments",
                column: "ApplicationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_CreateUserId",
                table: "ApplicationDocuments",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDocuments_UpdateUserId",
                table: "ApplicationDocuments",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRequests_CreateUserId",
                table: "ApplicationRequests",
                column: "CreateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRequests_UpdateUserId",
                table: "ApplicationRequests",
                column: "UpdateUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationRequests_UserId",
                table: "ApplicationRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId_RoleId",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Annexes");

            migrationBuilder.DropTable(
                name: "AnnualPlanItems");

            migrationBuilder.DropTable(
                name: "ApplicationDocuments");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "AnnualPlans");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ApplicationRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
