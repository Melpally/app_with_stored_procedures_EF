using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DBSD.CW2._13768._14055._13287.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TGUserName",
                table: "Courier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Courier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "BirthDate",
                table: "Courier",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "ClientAddress",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HomeNumber",
                table: "ClientAddress",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "ClientAddress",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Client",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Butch", "Cassidy", "+998901235678" },
                    { 2, "Calamity", "Janet", "+998901235678" },
                    { 3, "Billy", "Joel", "+998901235678" },
                    { 4, "Kit", "Carson", "+998901235678" },
                    { 5, "Helga", "Storm", "+998901235678" },
                    { 6, "Rose", "Doolan", "+998901235678" }
                });

            migrationBuilder.InsertData(
                table: "Courier",
                columns: new[] { "Id", "BirthDate", "City", "FirstName", "HasDrivingLicense", "LastName", "PhoneNumber", "ProfilePicture", "TGUserName" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 12, 1), "Tashkent", "Avaz", false, "Khalikov", "+998991234567", new byte[0], "@avaz_IT" },
                    { 2, new DateOnly(1999, 11, 11), "Tashkent", "Jane", true, "Doe", "+998991234567", new byte[0], "@janedoe" },
                    { 3, new DateOnly(1980, 2, 1), "Samarkand", "John", false, "Doe", "+998991234567", new byte[0], "@johndoe" },
                    { 4, new DateOnly(1978, 5, 13), "Tashkent", "Rupert", true, "Kovalsky", "+998991234567", new byte[0], "@ruppy" },
                    { 5, new DateOnly(1990, 12, 1), "Samarkand", "Hariette", false, "Willey", "+998991234567", new byte[0], "@hanriette" },
                    { 6, new DateOnly(2000, 12, 21), "Tashkent", "Richard", true, "Willey", "+998991234567", new byte[0], "@richwill" },
                    { 7, new DateOnly(2004, 3, 22), "London", "Gladys", false, "Foster", "+998991234567", new byte[0], "@ineedpigden" }
                });

            migrationBuilder.InsertData(
                table: "ClientAddress",
                columns: new[] { "Id", "City", "ClientId", "HomeNumber", "Street" },
                values: new object[,]
                {
                    { 1, "Tashkent", 1, "12", "Istiqbol str" },
                    { 2, "Tashkent", 2, "13", "Shakhrisabz str" },
                    { 3, "Tashkent", 2, "14", "Amir Temur str" },
                    { 4, "Tashkent", 3, "15", "Istiqbol" },
                    { 5, "Tashkent", 4, "16", "Taras Shevchenko str" },
                    { 6, "Tashkent", 5, "17", "Shastri str" },
                    { 7, "Tashkent", 6, "18", "Oybek str" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClientAddress",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courier",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "TGUserName",
                table: "Courier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Courier",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Courier",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "ClientAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "HomeNumber",
                table: "ClientAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "ClientAddress",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Client",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
