using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class updatebooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearOfPublication",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "a78c5aee-49c2-4f78-a547-445fbb2a4d5f", new DateTime(2025, 12, 2, 15, 24, 34, 349, DateTimeKind.Local).AddTicks(8919), new DateTime(2025, 12, 2, 15, 24, 34, 349, DateTimeKind.Local).AddTicks(8922), new DateTime(2025, 12, 2, 15, 24, 34, 349, DateTimeKind.Local).AddTicks(8784), "AQAAAAIAAYagAAAAEN4BpY3SFsbp0ck6l9JJvZ6kYEnfjSAMB7aoUMwzqyjUexvjInuyJq7qVp0gm3UnDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "4afa43c0-05a9-417c-b5b3-35af5e15a04f", new DateTime(2025, 12, 2, 15, 24, 34, 413, DateTimeKind.Local).AddTicks(9479), new DateTime(2025, 12, 2, 15, 24, 34, 413, DateTimeKind.Local).AddTicks(9482), new DateTime(2025, 12, 2, 15, 24, 34, 413, DateTimeKind.Local).AddTicks(9313), "AQAAAAIAAYagAAAAEA+ow4Mqp48syey6BOyYcOJ4kiZuBblBdUy2Rx45YEUvat/mOxzI+fqulQbQr9RXlA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d26455a6-dad1-40e3-8d5c-3a80490ea2c8", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9659), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9663), "AQAAAAIAAYagAAAAEPYjRRBgAvZuWIrgK80nugFDsgxQoBIPhpBsowYy9lcx6RtT5369KEorDooSicO02A==", "fdd5ace6-6d70-4f9b-a689-d20a61669de4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25bb95cd-a924-4e1d-8971-4b0acf2003f2", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9675), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9676), "AQAAAAIAAYagAAAAEO7FrMt0IC4FRtTnbQEOl0Dejind9mk6fUC+KQXZdBkh7dLcqSa5ofKw40lgLbWNdA==", "dc7ef0a7-5f0e-4d3f-bfae-3ba76144623a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "95fdfd81-cb7e-49fb-8412-3c21edf39724", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9685), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9686), "AQAAAAIAAYagAAAAEKvjyndfK0nS4iVKoaM9xtNgql8whHXd3CwODbkv0G4JUxSqjnKyG4BEozA4EER21Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "0c99714f-877b-4781-879e-370f48fb6a9e", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9706), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9708), "AQAAAAIAAYagAAAAEDFsPnJ5c5rM9U7pkfwFMPEjQ0TL60YJkqwYAg0P+J2dYtzq5Eri9S8yl1XMCICYXQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "e0216711-a640-4f80-b6e7-443871b8ad36", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9714), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9716), "AQAAAAIAAYagAAAAEPU5ES8x6tTcob+Moc8aPY9XDnaPylotFV3bvqJ1K/k45dXQ6N2gYfjzBd4Ba1z7IQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "10f6d82a-5199-4726-97e5-6f52895e9a71", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9729), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9731), "AQAAAAIAAYagAAAAEGtK0dzI+lT/mOQUxxBQCLsez5G5puJOlEypN1jMRkNoC2Z6OqQscZRyoee9+pUD0Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "73d64f0b-a03a-46df-973f-162c23ef47d4", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9737), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9738), "AQAAAAIAAYagAAAAEMdjRBDYcrIqffvjoCiJsAhbA7uS06cCmviDJjmORHhOzDT2BMHHfu7IM/6vs9NZsA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "0932f021-7caa-4332-a2e6-3be431261c85", new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9745), new DateTime(2025, 12, 2, 15, 24, 34, 475, DateTimeKind.Local).AddTicks(9746), "AQAAAAIAAYagAAAAEHWEUudSdBOnlzLuZTYcKautfd4oGDACpWzbBEsxM82vZ2Fmeo7cuH6iE8mp65tYzA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "YearOfPublication",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "46b3d9ba-8a7c-4d75-844a-8ae8cb2a1f54", new DateTime(2025, 12, 2, 14, 11, 36, 115, DateTimeKind.Local).AddTicks(8895), new DateTime(2025, 12, 2, 14, 11, 36, 115, DateTimeKind.Local).AddTicks(8898), new DateTime(2025, 12, 2, 14, 11, 36, 115, DateTimeKind.Local).AddTicks(8739), "AQAAAAIAAYagAAAAECvcZUU8Mb1BxidgM3oWmGb1HVKhBN/nlXefIVIKBmZAHE770zINPMjFuH6uqBxTFw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "eb3fc91a-4e9d-4d5e-819f-92dc5a087b57", new DateTime(2025, 12, 2, 14, 11, 36, 177, DateTimeKind.Local).AddTicks(5946), new DateTime(2025, 12, 2, 14, 11, 36, 177, DateTimeKind.Local).AddTicks(5952), new DateTime(2025, 12, 2, 14, 11, 36, 177, DateTimeKind.Local).AddTicks(5848), "AQAAAAIAAYagAAAAECH8ZyHen5AsXuwxzmcRbmG32RPV1rb1s1pLKWJuVHO3QlkgAsunYFtnVRb9ikn+VA==" });

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
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "750adf7c-01a8-49a0-b33e-50c499da9772", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5439), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5441), "AQAAAAIAAYagAAAAEFnFl/5iR2WeWAu4KbTlVrwS9uKdqDgY5yrab3Ndt8U8PLJotvfIo153F2CggzFv5Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "95c392df-3287-4c74-86c7-125485f9ab99", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5450), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5452), "AQAAAAIAAYagAAAAENAbfddp6ltKbddhtgggsSnVhPX1QzstgBQ4eGGOGdr8xgjOQAbyR/MjgL2HplFH2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "a971f276-9b90-4b75-8bbe-679dba4ed415", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5595), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5597), "AQAAAAIAAYagAAAAEOFO2OgbY/kMUPli+Z+jWCQ26ln+gsrvADn+1noB0UT3OFhc02qhdryWGt5Ts4gNWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "454143f3-f2a1-47af-930e-8f93194a3a9b", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5614), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5615), "AQAAAAIAAYagAAAAEIu0m8SYe32SwKo/aSBIn2plhsUK8QnNGqjsfl9DLGeuipTZUg9F/xUWJMntR82JRg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "eecf36b4-3456-43c2-9982-7dbbadc45f37", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5622), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5623), "AQAAAAIAAYagAAAAEK19YCz6a4Pbm/QlZyjFRALi4tfFzYQTGa7MtKjj5jqRp2elPLZrSysBnFjHtkqYNA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "c7f6f958-9acd-4db1-95dd-0acc25e7282f", new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5631), new DateTime(2025, 12, 2, 14, 11, 36, 239, DateTimeKind.Local).AddTicks(5632), "AQAAAAIAAYagAAAAEEEdtBkJ8ZyYHiJwkdm8HmdQDYV5lLWGrNyhJk5ygHvuqg7tukUXlH7mZItbGLue+g==" });
        }
    }
}
