using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class changeinfinetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "e33d6848-bfef-4d03-a606-b7fb46fb2f9f", new DateTime(2025, 12, 2, 12, 55, 54, 390, DateTimeKind.Local).AddTicks(4595), new DateTime(2025, 12, 2, 12, 55, 54, 390, DateTimeKind.Local).AddTicks(4598), new DateTime(2025, 12, 2, 12, 55, 54, 390, DateTimeKind.Local).AddTicks(4456), "AQAAAAIAAYagAAAAEJJLYLaN+bJ3GtnZrQ5/1jT0C3pV44karGT1Gq9KNni3zpvgIFtbJdWKnH0nqBAecg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate" },
                values: new object[] { "63a0796b-e072-41a5-a259-c59d236ed705", new DateTime(2025, 12, 2, 12, 55, 54, 468, DateTimeKind.Local).AddTicks(5233), new DateTime(2025, 12, 2, 12, 55, 54, 468, DateTimeKind.Local).AddTicks(5236), new DateTime(2025, 12, 2, 12, 55, 54, 468, DateTimeKind.Local).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29ea8672-df4b-4e5d-9f8d-7ba44f526208", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7303), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7306), "AQAAAAIAAYagAAAAEOYzYLTxMjCgJpbjUWjKuwADTaxGpRsLp5/xOoNEOoKswFVMJg9yBFCxwI4fVVRciQ==", "add3c8f2-357b-49df-8f85-6b57d1f54451" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d3187e6-1775-43c5-905f-f51007526b74", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7320), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7322), "AQAAAAIAAYagAAAAEO3UWJ4Z4rPYY4koP0hTMr9URftb3kgRHM/EmR71nXBZQC+w5jUFS6CEtBXhmyeSiA==", "aebdcbfc-805e-4929-9567-a60cb4dbc5ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "17b71171-2a4b-4133-8cd5-e9ed7e305e88", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7330), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7332), "AQAAAAIAAYagAAAAEA2un67RYXXjNEwSv9cZGSdK9MQWvVcEw9BJjwz0qhoFsXVtt2RPazTQYFg5CDe90A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "ffe7febc-f5a6-4a43-8323-d1483450c025", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7339), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7340), "AQAAAAIAAYagAAAAEPWxj8wtvn2g9OFwr9oKLeU4c31C/4byv6/YtG2nrh0MHvjWoJa5wUmtmnIuJNUoAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "f0aed1f3-bf1c-44ee-a9aa-9d4db6c90a38", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7357), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7358), "AQAAAAIAAYagAAAAEIN8ykN3H3qPAoensuByPhOu4jWke/T+v83nnGjopmgBt8PIR0JcxxH4NzFdzd8jHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "d5950de8-b5ed-4618-833b-59d565b0f911", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7376), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7378), "AQAAAAIAAYagAAAAENc7o+NMpFekajAKAk0t82kYtxhKnZXqDuhJzTW6tGjFu2VaJ9eWZCv8q0x2cqwjQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "ca2a0607-f9f7-4cdf-8522-c4443ab6df1a", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7384), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7386), "AQAAAAIAAYagAAAAENc0VUGcuer0cQG2RaSVaMKuq/epa8jEsopo/1+LW0hcy4OQK8jGBSA+I1jMS95YiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "1a4891e8-942a-41e2-8df2-9964d606712f", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7392), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7393), "AQAAAAIAAYagAAAAEGDuXyBXqB8+Wmo0KgRc5zBB8wp9BWkGmIP8kX9mN4bMID9PBZ+EjtX2SoUVzO5CsQ==" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Status",
                value: "Waiting");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Status",
                value: "Waiting");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Status",
                value: "Waiting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "0e6b3fe6-8334-4c54-88d4-24e986837938", new DateTime(2025, 11, 30, 18, 58, 30, 765, DateTimeKind.Utc).AddTicks(2354), new DateTime(2025, 11, 30, 18, 58, 30, 765, DateTimeKind.Utc).AddTicks(2355), new DateTime(2025, 11, 30, 18, 58, 30, 765, DateTimeKind.Utc).AddTicks(2259), "AQAAAAIAAYagAAAAEJ9Gx40VR0NdzDKX4IKzh5C4G/qw4cldtpZgr0xllt6V0PpL9sGfISeNqsUkfEfByw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate" },
                values: new object[] { "76c78616-81b7-4722-924d-9d1e67dc372a", new DateTime(2025, 11, 30, 18, 58, 30, 827, DateTimeKind.Utc).AddTicks(1367), new DateTime(2025, 11, 30, 18, 58, 30, 827, DateTimeKind.Utc).AddTicks(1369), new DateTime(2025, 11, 30, 18, 58, 30, 827, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef26b4de-51c3-4ad8-ac6f-934fdbe1fde2", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7763), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7763), "AQAAAAIAAYagAAAAEBfvJoi51sctdYMN9xpwO5qDj4t8us0Xa68AYckzs7Xg8mV9DhMMWrWHv9cjXgIX6g==", "c5b17dee-2965-4369-8df7-2023273bbb83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd62891a-41bb-4510-a721-d8a28ec856c7", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7808), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7808), "AQAAAAIAAYagAAAAEOyPNfPf9liuYGD3u1HrUpW+DZNtDJK1GMb7e4NJ9SvG7LjR9Spw6unuJVSyCHxBQw==", "ce5f1c01-6e49-440b-9d8f-a97401b996cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "ad6277bd-c38b-481c-911c-9aeea52225e8", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7815), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7816), "AQAAAAIAAYagAAAAEJlIod7h1+Yo7e87MP9U04LMlhN0eqjSvkcecmI7WiTdM3vl6uUnhG9KuMlp45QwyA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "7e7f1aa1-5306-4178-a5a8-14d22a288bb5", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7821), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7821), "AQAAAAIAAYagAAAAEHddnVQCw3TAM/yMwuRY+ILLvTCEe11kX2JCcD1cs1+VLGMDYdH21hyQM7NTIWq3YQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "b6636018-f1c9-4111-86cb-961d84543056", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7825), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7826), "AQAAAAIAAYagAAAAEJDkT3KeFYY+FThV59PBMo/DgmzHMRTieWmTezCJ05ep68+ZZC6E/I/8Mk3lP9vXUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "c6f2742e-c180-4d80-b333-73179b36311f", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7839), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7839), "AQAAAAIAAYagAAAAEAG2rahWxYC26SuPxneYdhhD9JdFWqgiqG0BOnhVj++DfXh91y6D9AbUCoSVgsBoyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "3cb8c42a-2523-4f60-a07b-2d7d392ab5e7", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7843), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7844), "AQAAAAIAAYagAAAAEBnSXl+DUHIJAABYuRHN/bqwrv/v7SD2wQ9Uk4JA21UnpjVhlrFRxISvLSXnvYcd4A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "2458c85f-4a18-415d-8f8f-c3a999700afb", new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7847), new DateTime(2025, 11, 30, 18, 58, 30, 889, DateTimeKind.Utc).AddTicks(7848), "AQAAAAIAAYagAAAAEECtaVp7YpuLwl3tfA8VHiY7ymJQlYHBV3y6hiCBTEcx3gzFl7LzCI+uyE++In6uTQ==" });

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "Status",
                value: "Active");

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "Status",
                value: "Active");
        }
    }
}
