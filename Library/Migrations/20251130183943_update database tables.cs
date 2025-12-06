using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class updatedatabasetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MembershipDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash", "isActive" },
                values: new object[] { null, "97c1e74d-de89-44e3-88bd-70e210558ed9", new DateTime(2025, 11, 30, 18, 39, 28, 187, DateTimeKind.Utc).AddTicks(9819), new DateTime(2025, 11, 30, 18, 39, 28, 187, DateTimeKind.Utc).AddTicks(9820), new DateTime(2025, 11, 30, 18, 39, 28, 187, DateTimeKind.Utc).AddTicks(9669), "AQAAAAIAAYagAAAAEGDoakUy4fX25PbVqHK+eOWKDwifguLkT/fxf/mrVB6zOw9EB/mVkEcl1iKiflmtqQ==", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "isActive" },
                values: new object[] { null, "81d2356b-e399-4eb3-8cfb-1d17eb17c701", new DateTime(2025, 11, 30, 18, 39, 28, 256, DateTimeKind.Utc).AddTicks(4942), new DateTime(2025, 11, 30, 18, 39, 28, 256, DateTimeKind.Utc).AddTicks(4944), new DateTime(2025, 11, 30, 18, 39, 28, 256, DateTimeKind.Utc).AddTicks(4823), true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2c8888e-b827-4b33-8212-286e679450f9", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5457), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5458), "AQAAAAIAAYagAAAAEE/DR0ZNu3euWvbLxkbstp2WihqE58gw5vWCCtwM+1yEk6F/DkNcuu5gDnmLkcsZNA==", "14c6088e-464a-4475-8227-83abb1401cbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42ab6a98-9d3b-4c6f-a0bb-198fe6f39497", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5493), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5493), "AQAAAAIAAYagAAAAENn/kh0iba19ftQPlgWHdSa98kbkwCYu3Hjye60NzEB3VIs6YAmuwlYd/vc/v4fqGA==", "8182dc00-1ce6-492a-9d64-8d9733c9833b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "c94a7c9e-feba-4fa7-b6f2-24a57db12cc5", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5500), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5501), "AQAAAAIAAYagAAAAEF0QsbXOSTE8zHYHmamD4Ao8Mw/nMEDVUlhWx+lvX/0bLo5uDRACRtmCX7HovYsZrw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "b79cf050-b693-4987-ab5c-35a258c10a55", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5506), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5506), "AQAAAAIAAYagAAAAECnC8cSF2i4zqotviSIyQBrkdYVqqlT/lNG146FgEScetGFOwRfI/jnCqqiG+G0x+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "ce8be613-d25a-4ab8-b26f-09ea38e3ad58", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5510), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5511), "AQAAAAIAAYagAAAAEKxQHqKpqEycMhbXcIPKB6hUho3Jo0QRJhbPMFDCw1KVoJYAx8O6dDMMSPCn8kKO6g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "41371662-053b-44a1-b88b-6c835d187e6c", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5522), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5523), "AQAAAAIAAYagAAAAEI9NmjTgO8WMQEC0s0iuDMYzVCl3JpYH9w454OtrrZQCiV8BYHqxz9DH+4aVQPR4uA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "37d89a79-be1b-4411-9553-7656de53b5f8", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5527), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5527), "AQAAAAIAAYagAAAAEBxt6ZmUrDrfUREbLGQptUfz5j1wvs93lbWkgkEoQelR3kdFDyMLsS38gqXlGJkElA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "e5c5db55-de6f-413a-b6fc-3c28766c9bff", new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5531), new DateTime(2025, 11, 30, 18, 39, 28, 323, DateTimeKind.Utc).AddTicks(5532), "AQAAAAIAAYagAAAAEGdWrFObgEOZHNkn1xK7ttfZY+EJgSneMAgvgqtt9yPr01ZvbwPF+v7PBJag4E9v/A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MembershipDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "9eedb97d-5695-47f3-9ddf-01b2007550a4", new DateTime(2025, 11, 30, 17, 29, 19, 406, DateTimeKind.Utc).AddTicks(2407), "ApplicationUser", "admin@library.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 406, DateTimeKind.Utc).AddTicks(2408), false, null, null, null, "AQAAAAIAAYagAAAAEAelJ1P+Tj7kqjCMjl88JtzmRSgOokAck6Aa2Sh3aupq6T6kFZ/INUqQIMmbnrD0DA==", "0111000001", false, null, false, "Admin 1" },
                    { 2, 0, "72d42c1e-5385-410f-afc6-6b63015f3ac2", new DateTime(2025, 11, 30, 17, 29, 19, 468, DateTimeKind.Utc).AddTicks(4500), "ApplicationUser", "admin2@library.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 468, DateTimeKind.Utc).AddTicks(4501), false, null, null, null, null, "0111000001", false, null, false, "Admin 2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "MembershipDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isActive" },
                values: new object[,]
                {
                    { 3, 0, "Cairo, Egypt", "dd251134-f23f-4e4c-b20c-291a571450e6", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1261), "Member", "ali.hassan@mail.com", true, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1261), false, null, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI.HASSAN@MAIL.COM", "ALI.HASSAN", "AQAAAAIAAYagAAAAEKv8D15s9kNZnOo+lkznH+Yhjyys8eyJq0CRUW+A3qhq6nXuBtIHQJHyysdim+r2bw==", "0101111111", false, "96b19b00-9eff-4e5b-bee4-df6149851c80", false, "ali.hassan", true },
                    { 4, 0, "Giza, Egypt", "ea780534-f15d-41f5-a07b-2725e9bf705e", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1298), "Member", "sara.m@mail.com", true, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1299), false, null, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SARA.M@MAIL.COM", "SARA.MAHMOUD", "AQAAAAIAAYagAAAAEIeEb8H77cWtKr6UFLGcIhRWmI4DTqIRAxMqTmFDmy9NbmUXzLBAO0BYnM+/4dRBAA==", "0102222222", false, "108a3dbd-e51d-4e98-870d-9fe052240455", false, "sara.mahmoud", true },
                    { 5, 0, "Alexandria, Egypt", "9e397239-94fa-4e85-bf49-0c267e9befe2", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1320), "Member", "mona.adel@mail.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1321), false, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAENcLmJu10iyhhaYGI0qExa8Io9wsaHnFBDcvfjLtxs6n5QkuM1q9lFgJAQ8TuLxicA==", "0103333333", false, null, false, "mona.adel", true },
                    { 6, 0, "Cairo, Egypt", "e7653624-f3c7-445c-854f-7f2a098b5f0b", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1325), "Member", "omar.y@mail.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1325), false, null, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEFqbe028tEou0VwNZH7N8XWqfB0K33gMp2VurZzUTQ2dCq8BkMO+iblMgxjpKvGunQ==", "0104444444", false, null, false, "omar.youssef", false },
                    { 7, 0, "Mansoura, Egypt", "d12e6b76-60f2-43b5-bcb6-40892e78ffd0", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1420), "Member", "hassan.m@mail.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1421), false, null, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEE1v9Jk6ZFu5Kbsv2CDhy7RNu8Am+jc3GDBHWTO01kvCmhSCRrmHv0ZPhpD5LcInvg==", "0105555555", false, null, false, "hassan.mostafa", true },
                    { 8, 0, "Cairo, Egypt", "969b954f-6869-476d-8116-393fa8d4b285", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1433), "Member", "laila.a@mail.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1433), false, null, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEEIc4NZKzhApFd3Tm6o2MAAGVyEjLRWBarRjN8CV0gy/upqd5GxQujclGPR468Zssg==", "0106666666", false, null, false, "laila.ahmed", true },
                    { 9, 0, "Tanta, Egypt", "3c5d61c1-557b-4a0e-bac8-f6c671f5c2d5", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1437), "Member", "nour.ibrahim@mail.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1438), false, null, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEMLhFI9/CzJRkINl4HUKaR96jIAZtvDVlzqbzPbqrbyQm6kn7AQg4U6/Ib32apoX/Q==", "0107777777", false, null, false, "nour.ibrahim", true },
                    { 10, 0, "Giza, Egypt", "9da12725-7c63-4047-8761-f06977aae6c8", new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1448), "Member", "yasmin.ehab@mail.com", false, new DateTime(2025, 11, 30, 17, 29, 19, 530, DateTimeKind.Utc).AddTicks(1448), false, null, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEGhmSYKIVbUaAC1DRyRbVzqa2m+F78X1eVJZtO7GFomm+163WK1hrStXFxz2FyQ17A==", "0108888888", false, null, false, "yasmin.ehab", false }
                });
        }
    }
}
