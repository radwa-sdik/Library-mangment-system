using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyFineRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxBorrowDays = table.Column<int>(type: "int", nullable: false),
                    ReservationExpiryDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingsId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    YearOfPublication = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    isAvaliable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISBN);
                    table.CheckConstraint("CK_Book_Copies", "TotalCopies >= 0 AND AvailableCopies >= 0 AND AvailableCopies <= TotalCopies");
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BorrowingBooks",
                columns: table => new
                {
                    BorrowingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    daysBorrowed = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "DATEADD(DAY, [DaysBorrowed], [BorrowDate])", stored: true),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowingBooks", x => x.BorrowingId);
                    table.CheckConstraint("CK_BorrowRecord_Status_ReturnDate", "(Status = 'Borrowed' AND ReturnDate IS NULL) OR (Status = 'OverDue' AND ReturnDate IS NULL) OR (Status = 'Returned' AND ReturnDate IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_BorrowingBooks_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowingBooks_Books_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Books_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    FineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BorrowingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FineDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.FineId);
                    table.ForeignKey(
                        name: "FK_Fines_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fines_BorrowingBooks_BorrowingId",
                        column: x => x.BorrowingId,
                        principalTable: "BorrowingBooks",
                        principalColumn: "BorrowingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Admin", "ADMIN" },
                    { 2, null, "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "69507b27-2668-49e2-8a19-6f96177fc010", new DateTime(2025, 11, 30, 15, 41, 58, 652, DateTimeKind.Utc).AddTicks(4520), "ApplicationUser", "admin@library.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 652, DateTimeKind.Utc).AddTicks(4521), false, null, null, null, "AQAAAAIAAYagAAAAEI5FMcchMBO790rrlzxROzP5TIwJDHci3GbcU/zsZIM76SAi9ejbLtojbqmWyH/brQ==", "0111000001", false, null, false, "Admin 1" },
                    { 2, 0, "807dce38-de15-4cf5-ad4a-fabf59424865", new DateTime(2025, 11, 30, 15, 41, 58, 718, DateTimeKind.Utc).AddTicks(169), "ApplicationUser", "admin2@library.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 718, DateTimeKind.Utc).AddTicks(169), false, null, null, null, null, "0111000001", false, null, false, "Admin 2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "CreatedAt", "Discriminator", "Email", "EmailConfirmed", "LastLogin", "LockoutEnabled", "LockoutEnd", "MembershipDate", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isActive" },
                values: new object[,]
                {
                    { 3, 0, "Cairo, Egypt", "30c62f86-05b7-4142-9adf-c7be5bc0dcee", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4493), "Member", "ali.hassan@mail.com", true, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4494), false, null, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ALI.HASSAN@MAIL.COM", "ALI.HASSAN", "AQAAAAIAAYagAAAAEHdCcjj4jDxnGrOkjCsAbC2kEI0GOudXoMsZ3AeJla6dSG/jugMeKIJ3hFK3bM+OWw==", "0101111111", false, "0b19fe27-fa46-42c0-9282-43cc70272977", false, "ali.hassan", true },
                    { 4, 0, "Giza, Egypt", "646df8c7-a7a7-48a7-ae9b-892f1d19e8f7", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4505), "Member", "sara.m@mail.com", true, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4506), false, null, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SARA.M@MAIL.COM", "SARA.MAHMOUD", "AQAAAAIAAYagAAAAEO3JIBZW4zvGFvrZqbkEVtRTvEdzxxNhntmsd7E1FwBPVfhEJfl6l6vu9WM+MehWFQ==", "0102222222", false, "7e735440-959f-434e-adaf-4ac33f73dcc7", false, "sara.mahmoud", true },
                    { 5, 0, "Alexandria, Egypt", "64fdbf43-cff3-4935-8c2b-437f36357aea", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4512), "Member", "mona.adel@mail.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4513), false, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEJVr6qP9BM4RzUkD7pNjXM3aIBTJkSP1HYsBPPfnQZbiTIzgeTB8FPFxSMX/sJXqTg==", "0103333333", false, null, false, "mona.adel", true },
                    { 6, 0, "Cairo, Egypt", "64ea224c-5760-464f-a4eb-28d36ec87b9e", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4517), "Member", "omar.y@mail.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4518), false, null, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAENdogcHqGKvbPOKoptJDmKSPSN0gc1XX9Dt1kGnKHp2aJZuzLJHHoVC4o7eKEeSD9A==", "0104444444", false, null, false, "omar.youssef", false },
                    { 7, 0, "Mansoura, Egypt", "e94791c0-c17c-4348-8248-55dea61a0b44", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4522), "Member", "hassan.m@mail.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4522), false, null, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAED5O7WTJIMYJtkOReOauHaZgy9YznJuMj0DSCJTBIfi8erVgXIo3UeXaN+EQPYPgGg==", "0105555555", false, null, false, "hassan.mostafa", true },
                    { 8, 0, "Cairo, Egypt", "1db652a1-302d-47d7-ad3c-c7eed8cd38d5", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4543), "Member", "laila.a@mail.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4544), false, null, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEFAaDGNWVzUR70j2fkHSNk3PYNaDR7U7mqaxIa109oYd5eJBNRjYxSyPTwqkA0Teow==", "0106666666", false, null, false, "laila.ahmed", true },
                    { 9, 0, "Tanta, Egypt", "6dc9797f-70f3-472f-bf49-c84ba9bf025b", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4548), "Member", "nour.ibrahim@mail.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4548), false, null, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEDzkv/O43MGWe6ypNFtN/cCIIL0D1hof0Np82gd0KqY+ngdRnd/KnmmB3RHRTD4G4w==", "0107777777", false, null, false, "nour.ibrahim", true },
                    { 10, 0, "Giza, Egypt", "9571125c-c874-4427-a0e2-08d780da3b15", new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4552), "Member", "yasmin.ehab@mail.com", false, new DateTime(2025, 11, 30, 15, 41, 58, 779, DateTimeKind.Utc).AddTicks(4553), false, null, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "AQAAAAIAAYagAAAAEFsN7Zyj2/1u/B1cKwjxeyUmKVSTdHk/rSppo7Qi+N4XcUyIGbS5SNI38fOK6tbVoA==", "0108888888", false, null, false, "yasmin.ehab", false }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Science Fiction" },
                    { 2, "History" },
                    { 3, "Self Development" },
                    { 4, "Technology" },
                    { 5, "Romance" },
                    { 6, "Mystery" },
                    { 7, "Programming" },
                    { 8, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "Name" },
                values: new object[,]
                {
                    { 1, "Penguin Books" },
                    { 2, "HarperCollins" },
                    { 3, "O'Reilly Media" },
                    { 4, "Bloomsbury" },
                    { 5, "Dar Al Maaref" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "Author", "AvailableCopies", "CategoryId", "Description", "Language", "Price", "PublisherId", "Title", "TotalCopies", "YearOfPublication", "isAvaliable" },
                values: new object[,]
                {
                    { "ISBN001", "H.G. Wells", 4, 1, "A sci-fi classic", "English", 150m, 1, "The Time Machine", 10, 1895, true },
                    { "ISBN002", "Yuval Noah Harari", 8, 2, "A history of humankind", "English", 300m, 2, "Sapiens", 12, 2011, true },
                    { "ISBN003", "James Clear", 9, 3, "Tiny changes, remarkable results", "English", 250m, 2, "Atomic Habits", 15, 2018, true },
                    { "ISBN004", "Robert C. Martin", 2, 7, "A handbook of agile software craftsmanship", "English", 400m, 3, "Clean Code", 7, 2008, true },
                    { "ISBN005", "Nicholas Sparks", 3, 5, "Romantic drama novel", "English", 180m, 1, "The Notebook", 10, 1996, true },
                    { "ISBN006", "Arthur Conan Doyle", 6, 6, "Mystery detective stories", "English", 220m, 1, "Sherlock Holmes", 14, 1892, true },
                    { "ISBN007", "J.K. Rowling", 5, 8, "Fantasy novel", "English", 350m, 4, "Harry Potter 1", 20, 1997, true },
                    { "ISBN008", "Cal Newport", 1, 3, "Rules for focused success", "English", 180m, 2, "Deep Work", 5, 2016, true },
                    { "ISBN009", "Cormen et al.", 10, 7, "Comprehensive algorithms book", "English", 600m, 3, "Introduction to Algorithms", 10, 2009, true },
                    { "ISBN010", "Paulo Coelho", 8, 5, "Spiritual journey novel", "English", 200m, 2, "The Alchemist", 12, 1988, true },
                    { "ISBN011", "J.R.R. Tolkien", 4, 8, "Fantasy adventure novel", "English", 300m, 4, "The Hobbit", 9, 1937, true },
                    { "ISBN012", "Peter Thiel", 1, 4, "Startup guide", "English", 250m, 2, "Zero to One", 8, 2014, true },
                    { "ISBN013", "Michael T. Goodrich", 7, 7, "Programming concepts", "English", 450m, 3, "Data Structures in Python", 7, 2021, true },
                    { "ISBN014", "Jane Austen", 2, 5, "Classic romance", "English", 160m, 1, "Pride and Prejudice", 5, 1813, true },
                    { "ISBN015", "Zaki Naguib Mahmoud", 6, 2, "History of Egypt", "Arabic", 120m, 5, "Egypt’s History", 6, 1998, true }
                });

            migrationBuilder.InsertData(
                table: "BorrowingBooks",
                columns: new[] { "BorrowingId", "BorrowDate", "ISBN", "MemberId", "ReturnDate", "Status", "daysBorrowed" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN003", 3, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Returned", 3 },
                    { 2, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN004", 5, null, "Borrowed", 3 },
                    { 3, new DateTime(2025, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN007", 5, new DateTime(2025, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Returned", 3 },
                    { 4, new DateTime(2025, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN001", 6, null, "OverDue", 3 },
                    { 5, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN006", 7, null, "Borrowed", 3 },
                    { 6, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN010", 8, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Returned", 3 },
                    { 7, new DateTime(2025, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN002", 9, null, "Borrowed", 3 },
                    { 8, new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN011", 10, null, "OverDue", 3 },
                    { 9, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN005", 5, null, "Borrowed", 3 },
                    { 10, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN012", 3, new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Returned", 3 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Date", "ExpiryDate", "ISBN", "MemberId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN007", 3, "Active" },
                    { 2, new DateTime(2025, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN003", 4, "Completed" },
                    { 3, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN010", 6, "Canceled" },
                    { 4, new DateTime(2025, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN001", 8, "Active" },
                    { 5, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN011", 9, "Active" },
                    { 6, new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ISBN006", 10, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Fines",
                columns: new[] { "FineId", "Amount", "BorrowingId", "FineDate", "IsPaid", "MemberId", "PaidDate" },
                values: new object[,]
                {
                    { 1, 20m, 6, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 8, null },
                    { 2, 40m, 10, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3, null },
                    { 3, 50m, 4, new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, null },
                    { 4, 100m, 8, new DateTime(2025, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author",
                table: "Books",
                column: "Author");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                table: "Books",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingBooks_ISBN",
                table: "BorrowingBooks",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowingBooks_MemberId",
                table: "BorrowingBooks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_BorrowingId",
                table: "Fines",
                column: "BorrowingId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_MemberId",
                table: "Fines",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ExpiryDate_Status",
                table: "Reservations",
                columns: new[] { "ExpiryDate", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ISBN",
                table: "Reservations",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "BorrowingBooks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
