using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentManagerCapstone.Data.Migrations
{
    public partial class addDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessAppointment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    EmailSetupPackage = table.Column<bool>(type: "bit", nullable: false),
                    DomainSetupPackage = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionSupportPackage = table.Column<bool>(type: "bit", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessAppointment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessAppointment_Appointment_ID",
                        column: x => x.ID,
                        principalTable: "Appointment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessAppointment_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateCustomerAppointment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    MobileSetupPackage = table.Column<bool>(type: "bit", nullable: false),
                    KidsSafeMediaPackage = table.Column<bool>(type: "bit", nullable: false),
                    WorkgroupSetupPackage = table.Column<bool>(type: "bit", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CreatedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateCustomerAppointment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PrivateCustomerAppointment_Appointment_ID",
                        column: x => x.ID,
                        principalTable: "Appointment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateCustomerAppointment_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAppointment_CustomerID",
                table: "BusinessAppointment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateCustomerAppointment_CustomerID",
                table: "PrivateCustomerAppointment",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessAppointment");

            migrationBuilder.DropTable(
                name: "PrivateCustomerAppointment");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
