using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class addimgUrltobooktable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "7870763a-8ef5-4e60-b4a6-e05950ff73b2", new DateTime(2025, 12, 2, 16, 55, 7, 426, DateTimeKind.Local).AddTicks(2940), new DateTime(2025, 12, 2, 16, 55, 7, 426, DateTimeKind.Local).AddTicks(2943), new DateTime(2025, 12, 2, 16, 55, 7, 426, DateTimeKind.Local).AddTicks(2762), "AQAAAAIAAYagAAAAEKNuQSupYei0ZleTma1xiy5/SkzxL/OtixCvcPeNZLmn/xb7ehCmZ8lwjYu+La84wA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "MembershipDate", "PasswordHash" },
                values: new object[] { "8ad47453-2973-4ba3-b737-af6e947d45de", new DateTime(2025, 12, 2, 16, 55, 7, 499, DateTimeKind.Local).AddTicks(557), new DateTime(2025, 12, 2, 16, 55, 7, 499, DateTimeKind.Local).AddTicks(560), new DateTime(2025, 12, 2, 16, 55, 7, 499, DateTimeKind.Local).AddTicks(403), "AQAAAAIAAYagAAAAEH+FS4tMK/sq7i39utK8FAbICpIKTdZyXYJOimoL4Ue+gcwhJDJIwiWza1nooGbk/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "32ca57c0-b03c-46f2-b522-dab91ac1a087", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(891), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(893), "AQAAAAIAAYagAAAAECR9ZEWiK9M+o++rp1IUYQxfJX16l50HxmuyisxRyZOGcCtlsQCuxkzA7mZtYHRXQg==", "b29e687b-12c2-408d-a558-8cfd9733ae96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d2f2815-8815-4b65-8738-b80c6a6af347", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(905), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(907), "AQAAAAIAAYagAAAAEI5p9GhPZf01I6AIibnSqQP0P8Nn0Ph70ppYxVF+KF8Oi8caGgF956rPVmpGhwkXUg==", "327bd685-b3fa-44b6-a47b-6cbfbfd5e012" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "dc1082fb-f767-43f2-b7ef-0300ffdd953f", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(915), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(916), "AQAAAAIAAYagAAAAEIH9XiOEDRvCJzQFeoPvXmgCJlpgKKy58wH4t2lh0pzicwAJZ93VntRV2YGoV59qgQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "0b281801-def2-4492-80f4-05e881688188", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(934), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(936), "AQAAAAIAAYagAAAAECwx5+RMD2WsYaPn2hEx4/B9hBqLhhl4V5RFxVxv8sLYdfsf+wxVt2xhBpu0+CpFSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "d614be2b-fabf-4401-aeec-b8124742c7ff", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(942), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(944), "AQAAAAIAAYagAAAAEM4NgMkVoIxfmg8W5k0ZqzIO69VtQwT36CsbLQqwhVI8+R3ha6QHPRq6XmaintPETw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "5a852afb-ccfd-415f-879b-2a962a643cd5", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(988), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(989), "AQAAAAIAAYagAAAAEBt/1F1n/MIzQ0rrRn1MctcWe0xKLw3J2/4D1Kq/3/VXXfgi9AEB5EQI5D5yavO2cw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "ad7061d3-cc4e-401e-a5ae-6d9646208243", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(995), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(996), "AQAAAAIAAYagAAAAENWJYmp2GkAiEZblZnntT4iTot2Lsj7oIgYEi4Qs6WcCSZQ/S2PqhnAoo/5vbLByhw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "LastLogin", "PasswordHash" },
                values: new object[] { "f2c1297d-293a-43d4-b885-60a7df40005e", new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(1001), new DateTime(2025, 12, 2, 16, 55, 7, 564, DateTimeKind.Local).AddTicks(1003), "AQAAAAIAAYagAAAAEFltxLs7YLmJLxTdQLP0r4htDCQTByjf6np3iQup2iUfV4JEsN9KeDYf3AX30eZbkA==" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN001",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN002",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN003",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN004",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN005",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN006",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN007",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN008",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN009",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN010",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN011",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN012",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN013",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN014",
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "ISBN",
                keyValue: "ISBN015",
                column: "ImageUrl",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

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
    }
}
