using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MHSAlumni.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MembershipType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiftType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftDedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Alumni",
                columns: table => new
                {
                    AlumniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaidenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPhonenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organizations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembershipId = table.Column<int>(type: "int", nullable: true),
                    OrganizationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumni", x => x.AlumniId);
                    table.ForeignKey(
                        name: "FK_Alumni_Memberships_MembershipId",
                        column: x => x.MembershipId,
                        principalTable: "Memberships",
                        principalColumn: "MembershipId");
                    table.ForeignKey(
                        name: "FK_Alumni_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationInfo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    AlumniId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Alumni_AlumniId",
                        column: x => x.AlumniId,
                        principalTable: "Alumni",
                        principalColumn: "AlumniId");
                    table.ForeignKey(
                        name: "FK_Registrations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumni_MembershipId",
                table: "Alumni",
                column: "MembershipId");

            migrationBuilder.CreateIndex(
                name: "IX_Alumni_OrganizationId",
                table: "Alumni",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AlumniId",
                table: "Registrations",
                column: "AlumniId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Alumni");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
