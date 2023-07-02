using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_contact_company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    ConseillerId = table.Column<int>(type: "int", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_User_ConseillerId",
                        column: x => x.ConseillerId,
                        principalTable: "User",
                        principalColumn: "Id");
                });



            migrationBuilder.InsertData(
            table: "Address",
            columns: new[] { "Id", "Created", "Updated", "CityId", "Street", "ComplementStreet" },
            values: new object[,]
            {
                     { 2, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, 8380, "8 rue de Saint-Cloud", null },
                      { 3, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, 8380, "8 rue de Saint-Cloud", null },
            });

            migrationBuilder.InsertData(
            table: "Company",
            columns: new[] { "Id", "Created", "Updated", "Name", "Comment", "AddressId", "Mail", "PhoneNumber", "MobilePhoneNumber" },
            values: new object[,]
            {
                     { 1, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "Weyou-Group", null, 3, "jpdelacourt@denatis.com", null,null },
            });


            migrationBuilder.InsertData(
           table: "Contact",
           columns: new[] { "Id", "Created", "Updated", "FirstName", "LastName", "AddressId", "CompanyId", "ConseillerId", "Mail", "PhoneNumber", "MobilePhoneNumber" },
           values: new object[,]
           {
                 { 1, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "P", "BOZOVIC", 2, 1, 1, "pbozovic@denatis.com", null,null },
           });


            migrationBuilder.CreateIndex(
                name: "IX_Company_AddressId",
                table: "Company",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AddressId",
                table: "Contact",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CompanyId",
                table: "Contact",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ConseillerId",
                table: "Contact",
                column: "ConseillerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Mail",
                table: "Contact",
                column: "Mail",
                unique: true,
                filter: "[Mail] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
