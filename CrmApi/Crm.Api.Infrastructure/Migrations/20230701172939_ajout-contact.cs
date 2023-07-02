using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using System;

#nullable disable

namespace Crm.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajoutcontact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Générer 100 adresses
            for (int i = 4; i <= 104; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 36996);

                migrationBuilder.InsertData(
                    table: "Address",
                    columns: new[] { "Id", "Created", "Updated", "CityId", "Street", "ComplementStreet" },
                    values: new object[] { i, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, randomNumber, $"Adresse {i}", null }
                );
            }

            // Générer 100 sociétés
            for (int i = 2; i <= 100; i++)
            {
                migrationBuilder.InsertData(
                    table: "Company",
                    columns: new[] { "Id", "Created", "Updated", "Name", "Comment", "AddressId", "Mail", "PhoneNumber", "MobilePhoneNumber" },
                    values: new object[] { i, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, $"Société {i}", null, i, $"mail{i}@example.com", null, null }
                );
            }

            // Générer 100 users
            for (int i = 2; i <= 100; i++)
            {
                Random randomCivilite = new Random();
                int randomCiviliteNumber = randomCivilite.Next(1, 3);

                Random randomAddress = new Random();
                int randomAddressNumber = randomAddress.Next(1, 100);

                migrationBuilder.InsertData(
                    table: "User",
                    columns: new[] { "Id", "Created", "Updated", "AddressId", "CivilityId", "LastName", "FirstName", "PhoneNumber", "MobilePhoneNumber", "Mail", "Password", "Actif", "Lock" },
                    values: new object[] { i, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, randomAddressNumber, randomCiviliteNumber, $"LastName{i}", $"FirstName{i}", null, null, $"mail{i}@example.com", "834C5A4199AB2DF6D23054F585B9CE76", true, false }
                ); 
            }

            // Générer 100 contacts
            for (int i = 2; i <= 100; i++)
            {
                Random randomConseillerId = new Random();
                int randomConseillerIdNumber = randomConseillerId.Next(1, 100);

                Random randomAddress = new Random();
                int randomAddressNumber = randomAddress.Next(1, 100);

                migrationBuilder.InsertData(
                    table: "Contact",
                    columns: new[] { "Id", "Created", "Updated", "FirstName", "LastName", "AddressId", "CompanyId", "ConseillerId", "Mail", "PhoneNumber", "MobilePhoneNumber" },
                    values: new object[] { i, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, $"Prénom {i}", $"Nom {i}", randomAddressNumber, i, randomConseillerIdNumber, $"contact{i}@example.com", null, null }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
