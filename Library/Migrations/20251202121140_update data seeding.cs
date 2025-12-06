using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class updatedataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "46b3d9ba-8a7c-4d75-844a-8ae8cb2a1f54", new DateTime(2025, 12, 2, 14, 11, 36, 115, DateTimeKind.Local).AddTicks(8895), new DateTime(2025, 12, 2, 14, 11, 36, 115, DateTimeKind.Local).AddTicks(8898), new DateTime(2025, 12, 2, 14, 11, 36, 115, DateTimeKind.Local).AddTicks(8739), "ADMIN@LIBRARY.COM", "ADMIN 1", "AQAAAAIAAYagAAAAECvcZUU8Mb1BxidgM3oWmGb1HVKhBN/nlXefIVIKBmZAHE770zINPMjFuH6uqBxTFw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "eb3fc91a-4e9d-4d5e-819f-92dc5a087b57", new DateTime(2025, 12, 2, 14, 11, 36, 177, DateTimeKind.Local).AddTicks(5946), new DateTime(2025, 12, 2, 14, 11, 36, 177, DateTimeKind.Local).AddTicks(5952), new DateTime(2025, 12, 2, 14, 11, 36, 177, DateTimeKind.Local).AddTicks(5848), "ADMIN2@LIBRARY.COM", "ADMIN 2", "AQAAAAIAAYagAAAAECH8ZyHen5AsXuwxzmcRbmG32RPV1rb1s1pLKWJuVHO3QlkgAsunYFtnVRb9ikn+VA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "101fe8f5-89b8-4c62-b35e-0d214d84a8cd", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5376), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5379), "AQAAAAIAAYagAAAAEM7E1BteA3LRq7a9dPV0Fj2yzuA8bopHwiW3EcAYOTMGLDy0AdHKnGraDOJfdEA/zg==", "e18b7194-14d1-46f6-bf92-53641fa66f5c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d587f3cd-d55e-4d2a-8480-b63e68f902ef", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5414), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5416), "AQAAAAIAAYagAAAAEDQCHum8sM1nDCvhCu8rOlBDEPfryv5SPCeGev32XdSHOXxkmz3hXqFKASxJ709tXw==", "c2862d21-7cab-4e1b-942e-e9e815631ddd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "750adf7c-01a8-49a0-b33e-50c499da9772", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5439), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5441), "MONA.ADEL@MAIL.COM", "MONA.ADEL", "AQAAAAIAAYagAAAAEFnFl/5iR2WeWAu4KbTlVrwS9uKdqDgY5yrab3Ndt8U8PLJotvfIo153F2CggzFv5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "95c392df-3287-4c74-86c7-125485f9ab99", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5450), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5452), "OMAR.Y@MAIL.COM", "OMAR.YOUSSEF", "AQAAAAIAAYagAAAAENAbfddp6ltKbddhtgggsSnVhPX1QzstgBQ4eGGOGdr8xgjOQAbyR/MjgL2HplFH2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "a971f276-9b90-4b75-8bbe-679dba4ed415", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5595), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5597), "HASSAN.M@MAIL.COM", "HASSAN.MOSTAFA", "AQAAAAIAAYagAAAAEOFO2OgbY/kMUPli+Z+jWCQ26ln+gsrvADn+1noB0UT3OFhc02qhdryWGt5Ts4gNWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "454143f3-f2a1-47af-930e-8f93194a3a9b", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5614), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5615), "LAILA.A@MAIL.COM", "LAILA.AHMED", "AQAAAAIAAYagAAAAEIu0m8SYe32SwKo/aSBIn2plhsUK8QnNGqjsfl9DLGeuipTZUg9F/xUWJMntR82JRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "eecf36b4-3456-43c2-9982-7dbbadc45f37", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5622), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5623), "NOUR.IBRAHIM@MAIL.COM", "NOUR.IBRAHIM", "AQAAAAIAAYagAAAAEK19YCz6a4Pbm/QlZyjFRALi4tfFzYQTGa7MtKjj5jqRp2elPLZrSysBnFjHtkqYNA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "c7f6f958-9acd-4db1-95dd-0acc25e7282f", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5631), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5632), "YASMIN.EHAB@MAIL.COM", "YASMIN.EHAB", "AQAAAAIAAYagAAAAEEEdtBkJ8ZyYHiJwkdm8HmdQDYV5lLWGrNyhJk5ygHvuqg7tukUXlH7mZItbGLue+g==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN015",
                column: "Title",
                value: "Egypt's History");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "e33d6848-bfef-4d03-a606-b7fb46fb2f9f", new DateTime(2025, 12, 2, 12, 55, 54, 390, DateTimeKind.Local).AddTicks(4595), new DateTime(2025, 12, 2, 12, 55, 54, 390, DateTimeKind.Local).AddTicks(4598), new DateTime(2025, 12, 2, 12, 55, 54, 390, DateTimeKind.Local).AddTicks(4456), null, null, "AQAAAAIAAYagAAAAEJJLYLaN+bJ3GtnZrQ5/1jT0C3pV44karGT1Gq9KNni3zpvgIFtbJdWKnH0nqBAecg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "63a0796b-e072-41a5-a259-c59d236ed705", new DateTime(2025, 12, 2, 12, 55, 54, 468, DateTimeKind.Local).AddTicks(5233), new DateTime(2025, 12, 2, 12, 55, 54, 468, DateTimeKind.Local).AddTicks(5236), new DateTime(2025, 12, 2, 12, 55, 54, 468, DateTimeKind.Local).AddTicks(5068), null, null, null });

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
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "17b71171-2a4b-4133-8cd5-e9ed7e305e88", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7330), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7332), null, null, "AQAAAAIAAYagAAAAEA2un67RYXXjNEwSv9cZGSdK9MQWvVcEw9BJjwz0qhoFsXVtt2RPazTQYFg5CDe90A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ffe7febc-f5a6-4a43-8323-d1483450c025", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7339), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7340), null, null, "AQAAAAIAAYagAAAAEPWxj8wtvn2g9OFwr9oKLeU4c31C/4byv6/YtG2nrh0MHvjWoJa5wUmtmnIuJNUoAQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "f0aed1f3-bf1c-44ee-a9aa-9d4db6c90a38", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7357), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7358), null, null, "AQAAAAIAAYagAAAAEIN8ykN3H3qPAoensuByPhOu4jWke/T+v83nnGjopmgBt8PIR0JcxxH4NzFdzd8jHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "d5950de8-b5ed-4618-833b-59d565b0f911", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7376), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7378), null, null, "AQAAAAIAAYagAAAAENc7o+NMpFekajAKAk0t82kYtxhKnZXqDuhJzTW6tGjFu2VaJ9eWZCv8q0x2cqwjQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ca2a0607-f9f7-4cdf-8522-c4443ab6df1a", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7384), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7386), null, null, "AQAAAAIAAYagAAAAENc0VUGcuer0cQG2RaSVaMKuq/epa8jEsopo/1+LW0hcy4OQK8jGBSA+I1jMS95YiQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "NormalizedEmail", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "1a4891e8-942a-41e2-8df2-9964d606712f", new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7392), new DateTime(2025, 12, 2, 12, 55, 54, 530, DateTimeKind.Local).AddTicks(7393), null, null, "AQAAAAIAAYagAAAAEGDuXyBXqB8+Wmo0KgRc5zBB8wp9BWkGmIP8kX9mN4bMID9PBZ+EjtX2SoUVzO5CsQ==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN015",
                column: "Title",
                value: "Egypt’s History");
        }
    }
}
