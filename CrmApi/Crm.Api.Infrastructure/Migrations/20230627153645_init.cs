using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crm.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Civility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LongName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Civility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Region_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartementId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    InseeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SearchName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ComplementStreet = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CivilityId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    MobilePhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Actif = table.Column<bool>(type: "bit", nullable: false),
                    Lock = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_Civility_CivilityId",
                        column: x => x.CivilityId,
                        principalTable: "Civility",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
             table: "Civility",
             columns: new[] { "Id", "Created", "Updated", "ShortName", "LongName" },
             values: new object[,]
             {
                    { 1, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "M", "Monsieur" },
                    { 2, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "Mme", "Madame" },
                    { 3, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "Mlle", "Mademoiselle" }
             });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Created", "Updated", "Name", "SearchName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "FRANCE", "" },
                    { 2, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "ÎLE-MAURICE", "île maurice ile maurice" },
                    { 3, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "THAILANDE", "thaïlande thailande" },
                    { 4, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "ÉTATS-UNIS / USA", "états unis etats unis usa united states of america" },
                    { 5, new DateTime(2022, 11, 21, 15, 0, 0, 0, DateTimeKind.Unspecified), null, "PORTUGAL", "" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Created", "Updated", "Name", "SearchName", "CountryId" },
                values: new object[,]
                {
                    { 1, "84", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "AUVERGNE-RHÔNE-ALPES", "auvergne rhône alpes auvergne rhone alpes", 1 },
                    { 2, "27", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "BOURGOGNE-FRANCHE-COMTE", "bourgogne franche comté bourgogne franche comte",  1 },
                    { 3, "53", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "BRETAGNE", "",  1 },
                    { 4, "24", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CENTRE-VAL DE LOIRE", "centre val de loire",  1 },
                    { 5, "94", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CORSE", "",  1 },
                    { 6, "44", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "GRAND EST", "",  1 },
                    { 7, "32", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUT-DE-FRANCE", "haut de france hauts de france",  1 },
                    { 8, "11", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ÎLE-DE-FRANCE", "île de france ile de france idf",  1 },
                    { 9, "28", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "NORMANDIE", "",  1 },
                    { 10, "75", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "NOUVELLE-AQUITAINE", "nouvelle aquitaine",  1 },
                    { 11, "76", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "OCCITANIE", "",  1 },
                    { 12, "52", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PAYS DE LA LOIRE", "",  1 },
                    { 13, "93", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PROVENCE-ALPES-CÔTE D'AZUR", "provence alpes côte d'azur provence alpes côte d azur provence alpes cote d'azur provence alpes cote d azur paca",  1 },
                    { 14, "9", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "DOM-TOM", "",  1 },
                    { 15, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PHUKET", "",  3 },
                    { 16, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "FLORIDE", "",  4 },
                    { 17, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "OHIO", "",  4 },
                    { 18, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MISSOURI", "",  4 },
                    { 19, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MICHIGAN", "",  4 },
                    { 20, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ALGARVE", "",  5 },
                    { 21, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ÎLE-MAURICE", "",  2 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Created", "Updated", "Name", "SearchName", "RegionId" },
                values: new object[,]
                {
                    { 1, "67", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "BAS-RHIN", "bas rhin", 6 },
                    { 2, "68", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUT-RHIN", "haut rhin", 6 },
                    { 3, "24", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "DORDOGNE", "", 10 },
                    { 4, "33", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "GIRONDE", "", 10 },
                    { 5, "40", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LANDES", "", 10 },
                    { 6, "47", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOT-ET-GARONNE", "lot et garonne", 10 },
                    { 7, "64", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PYRÉNÉES-ATLANTIQUES", "pyrénées atlantiques pyrenees atlantiques pyrénees atlantiques pyrenées atlantiques",  10 },
                    { 8, "03", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ALLIER", "",  1 },
                    { 9, "15", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CANTAL", "",  1 },
                    { 10, "43", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-LOIRE", "haute loire",  1 },
                    { 11, "63", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PUY-DE-DÔME", "puy de dôme puy de dome",  1 },
                    { 12, "14", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CALVADOS", "",  9 },
                    { 13, "50", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MANCHE", "",  9 },
                    { 14, "61", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ORNE", "",  9 },
                    { 15, "21", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CÔTE-D'OR", "côte d'or cote d or cote d'or côte d or",  2 },
                    { 16, "58", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "NIÈVRE", "nievre",  2 },
                    { 17, "71", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SAÔNE-ET-LOIRE", "saône et loire saone et loire",  2 },
                    { 18, "89", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "YONNE", "", 2 },
                    { 19, "22", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CÔTES-D'ARMOR", "côtes d'armor cotes d armor côtes d armor cotes d'armor",  3 },
                    { 20, "29", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "FINISTÈRE", "finistere",  3 },
                    { 21, "35", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ILLE-ET-VILAINE", "ille et vilaine",  3 },
                    { 22, "56", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MORBIHAN", "",  3 },
                    { 23, "18", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CHER", "",  4 },
                    { 24, "28", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "EURE-ET-LOIR", "eure et loir",  4 },
                    { 25, "36", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "INDRE", "",  4 },
                    { 26, "37", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "INDRE-ET-LOIRE", "indre et loire",  4 },
                    { 27, "41", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOIR-ET-CHER", "loir et cher",  4 },
                    { 28, "45", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOIRET", "",  4 },
                    { 29, "08", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ARDENNES", "",  6 },
                    { 30, "10", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "AUBE", "",  6 },
                    { 31, "52", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-MARNE", "haute marne",  6 },
                    { 32, "51", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MARNE", "",  6 },
                    { 33, "2A", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CORSE-DU-SUD", "corse du sud",  5 },
                    { 34, "2B", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-CORSE", "haute corse",  5 },
                    { 35, "971", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "GUADELOUPE", "",  14 },
                    { 36, "973", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "GUYANE", "",  14 },
                    { 37, "974", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LA RÉUNION", "la reunion",  14 },
                    { 38, "972", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MARTINIQUE", "",  14 },
                    { 39, "976", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MAYOTTE", "",  14 },
                    { 40, "988", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "NOUVELLE-CALÉDONIE", "nouvelle caledonie", 14 },
                    { 41, "987", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "POLYNÉSIE FRANÇAISE", "polynesie francaise polynésie francaise polynesie française",  14 },
                    { 42, "975", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ST-PIERRE ET MIQUELON", "st pierre et miquelon saint pierre et miquelon",  14 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Created", "Updated", "Name", "SearchName", "RegionId" },
                values: new object[,]
                {
                    { 43, "986", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "WALLIS ET FUTUNA", "",  14 },
                    { 44, "25", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "DOUBS", "", 2 },
                    { 45, "70", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-SAÔNE", "haute saône haute soane",  2 },
                    { 46, "39", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "JURA", "",  2 },
                    { 47, "90", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "TERRITOIRE DE BELFORT", "",  2 },
                    { 48, "27", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "EURE", "",  9 },
                    { 49, "76", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SEINE-MARITIME", "seine maritime",  9 },
                    { 50, "91", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ESSONNE", "",  8 },
                    { 51, "92", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTS-DE-SEINE", "hauts de seine",  8 },
                    { 52, "75", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PARIS", "",  8 },
                    { 53, "77", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SEINE-ET-MARNE", "seine et marne",  8 },
                    { 54, "93", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SEINE-SAINT-DENIS", "seine saint denis",  8 },
                    { 55, "95", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VAL-D'OISE", "val d'oise val d oise",  8 },
                    { 56, "94", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VAL-DE-MARNE", "val de marne",  8 },
                    { 57, "78", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "YVELINES", "",  8 },
                    { 58, "11", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "AUDE", "",  11 },
                    { 59, "30", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "GARD", "",  11 },
                    { 60, "34", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HÉRAULT", "herault",  11 },
                    { 61, "48", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOZÈRE", "lozere",  11 },
                    { 62, "66", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PYRÉNÉES-ORIENTALES", "pyrénées orientales pyrenees orientales pyrénees orientales pyrenées orientales",  11 },
                    { 63, "19", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CORRÈZE", "correze",  10 },
                    { 64, "23", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CREUSE", "",  10 },
                    { 65, "87", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-VIENNE", "haute vienne",  10 },
                    { 66, "54", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MEURTHE-ET-MOSELLE", "meurthe et moselle",  6 },
                    { 67, "55", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MEUSE", "",  6 },
                    { 68, "57", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MOSELLE", "", 6 },
                    { 69, "88", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VOSGES", "",  6 },
                    { 70, "09", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ARIÈGE", "ariege",  11 },
                    { 71, "12", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "AVEYRON", "",  11 },
                    { 72, "32", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "GERS", "",  11 },
                    { 73, "31", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-GARONNE", "haute garonne",  11 },
                    { 74, "65", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTES-PYRÉNÉES", "hautes pyrénées hautes pyrenees hautes pyrénees hautes pyrenées", 11 },
                    { 75, "46", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOT", "",  11 },
                    { 76, "81", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "TARN", "",  11 },
                    { 77, "82", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "TARN-ET-GARONNE", "tarn et garonne", 11 },
                    { 78, "59", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "NORD", "",  7 },
                    { 79, "62", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PAS-DE-CALAIS", "pas de calais",  7 },
                    { 80, "44", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOIRE-ATLANTIQUE", "loire atlantique", 12 },
                    { 81, "49", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MAINE-ET-LOIRE", "maine et loire",  12 },
                    { 82, "53", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MAYENNE", "",  12 },
                    { 83, "72", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SARTHE", "",  12 },
                    { 84, "85", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VENDÉE", "vendee",  12 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Code", "Created", "Updated", "Name", "SearchName",  "RegionId" },
                values: new object[,]
                {
                    { 85, "02", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "AISNE", "",  7 },
                    { 86, "60", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "OISE", "",  7 },
                    { 87, "80", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SOMME", "",  7 },
                    { 88, "16", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CHARENTE", "",  10 },
                    { 89, "17", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "CHARENTE-MARITIME", "charente maritime",  10 },
                    { 90, "79", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "DEUX-SÈVRES", "deux sèvres deux sevres",  10 },
                    { 91, "86", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VIENNE", "",  10 },
                    { 92, "04", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ALPES-DE-HAUTE-PROVENCE", "alpes de haute provence",  13 },
                    { 93, "06", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ALPES-MARITIMES", "alpes maritimes",  13 },
                    { 94, "13", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "BOUCHES-DU-RHÔNE", "bouches du rhône bouches du rhone",  13 },
                    { 95, "05", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTES-ALPES", "hautes alpes",  13 },
                    { 96, "83", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VAR", "",  13 },
                    { 97, "84", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "VAUCLUSE", "",  13 },
                    { 98, "01", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "AIN", "",  1 },
                    { 99, "07", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ARDÈCHE", "ardeche",  1 },
                    { 100, "26", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "DRÔME", "drome",  1 },
                    { 101, "74", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "HAUTE-SAVOIE", "haute savoie",  1 },
                    { 102, "38", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "ISÈRE", "isere",  1 },
                    { 103, "42", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "LOIRE", "",  1 },
                    { 104, "69", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "RHÔNE", "rhone",  1 },
                    { 105, "73", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "SAVOIE", "",  1 },
                    { 106, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "PHUKET", "",  15 },
                    { 107, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "FLORIDE", "",  16 },
                    { 108, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "OHIO", "",  17 },
                    { 109, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MISSOURI", "",  18 },
                    { 110, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "MICHIGAN", "",  19 },
                    { 111, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "FARO", "",  20 },
                    { 112, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "RIVIÈRE NOIRE", "riviere noire",  21 },
                    { 113, "", new DateTime(2022, 11, 21, 15,  0, 0, 0, DateTimeKind.Unspecified), null, "RIVIÈRE DU REMPART", "riviere du rempart",  21 }
                });




            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_City_DepartmentId",
                table: "City",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_City_PostalCode",
                table: "City",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_City_SearchName",
                table: "City",
                column: "SearchName");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Code",
                table: "Department",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Department_RegionId",
                table: "Department",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_SearchName",
                table: "Department",
                column: "SearchName");

            migrationBuilder.CreateIndex(
                name: "IX_Region_CountryId",
                table: "Region",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Region_SearchName",
                table: "Region",
                column: "SearchName");

            migrationBuilder.CreateIndex(
                name: "IX_User_AddressId",
                table: "User",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CivilityId",
                table: "User",
                column: "CivilityId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Mail",
                table: "User",
                column: "Mail",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Civility");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
