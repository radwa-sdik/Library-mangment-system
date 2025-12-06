using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Library.Models.Enums;

namespace Library.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            //Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int> { Id = 2, Name = "Member", NormalizedName = "MEMBER" }
            );

            // Seed Admins
            var hasher = new PasswordHasher<ApplicationUser>();
            var id = 1;

            var adminUser = new ApplicationUser
            {
                Id = id++,
                UserName = "Admin 1",
                NormalizedUserName = "ADMIN 1",
                Email = "admin@library.com",
                NormalizedEmail = "ADMIN@LIBRARY.COM",
                PhoneNumber = "0111000001",
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now,
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin@123");

            var adminUser2 = new ApplicationUser
            {
                Id = id++,
                UserName = "Admin 2",
                NormalizedUserName = "ADMIN 2",
                Email = "admin2@library.com",
                NormalizedEmail = "ADMIN2@LIBRARY.COM",
                PhoneNumber = "0111000001",
                CreatedAt = DateTime.Now,
                LastLogin = DateTime.Now,
            };
            adminUser2.PasswordHash = hasher.HashPassword(adminUser2, "admin@123");

            builder.Entity<ApplicationUser>().HasData(adminUser,adminUser2);

            var members = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "ali.hassan",
                    NormalizedUserName = "ALI.HASSAN",
                    Email = "ali.hassan@mail.com",
                    NormalizedEmail = "ALI.HASSAN@MAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0101111111",
                    Address = "Cairo, Egypt",
                    MembershipDate = new DateTime(2024, 1, 10),
                    isActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "sara.mahmoud",
                    NormalizedUserName = "SARA.MAHMOUD",
                    Email = "sara.m@mail.com",
                    NormalizedEmail = "SARA.M@MAIL.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "0102222222",
                    Address = "Giza, Egypt",
                    MembershipDate = new DateTime(2024, 2, 12),
                    isActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "mona.adel",
                    NormalizedUserName = "MONA.ADEL",
                    Email = "mona.adel@mail.com",
                    NormalizedEmail = "MONA.ADEL@MAIL.COM",
                    PhoneNumber = "0103333333",
                    Address = "Alexandria, Egypt",
                    MembershipDate = new DateTime(2024, 3, 1),
                    isActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "omar.youssef",
                    NormalizedUserName = "OMAR.YOUSSEF",
                    Email = "omar.y@mail.com",
                    NormalizedEmail = "OMAR.Y@MAIL.COM",
                    PhoneNumber = "0104444444",
                    Address = "Cairo, Egypt",
                    MembershipDate = new DateTime(2024, 4, 20),
                    isActive = false,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "hassan.mostafa",
                    NormalizedUserName = "HASSAN.MOSTAFA",
                    Email = "hassan.m@mail.com",
                    NormalizedEmail = "HASSAN.M@MAIL.COM",
                    PhoneNumber = "0105555555",
                    Address = "Mansoura, Egypt",
                    MembershipDate = new DateTime(2024, 5, 14),
                    isActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "laila.ahmed",
                    NormalizedUserName = "LAILA.AHMED",
                    Email = "laila.a@mail.com",
                    NormalizedEmail = "LAILA.A@MAIL.COM",
                    PhoneNumber = "0106666666",
                    Address = "Cairo, Egypt",
                    MembershipDate = new DateTime(2024, 6, 2),
                    isActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "nour.ibrahim",
                    NormalizedUserName = "NOUR.IBRAHIM",
                    Email = "nour.ibrahim@mail.com",
                    NormalizedEmail = "NOUR.IBRAHIM@MAIL.COM",
                    PhoneNumber = "0107777777",
                    Address = "Tanta, Egypt",
                    MembershipDate = new DateTime(2024, 7, 7),
                    isActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                },
                new ApplicationUser
                {
                    Id = id++,
                    UserName = "yasmin.ehab",
                    NormalizedUserName = "YASMIN.EHAB",
                    Email = "yasmin.ehab@mail.com",
                    NormalizedEmail = "YASMIN.EHAB@MAIL.COM",
                    PhoneNumber = "0108888888",
                    Address = "Giza, Egypt",
                    MembershipDate = new DateTime(2024, 8, 15),
                    isActive = false,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now,
                }
            };

            // Hash passwords
            foreach (var member in members)
            {
                member.PasswordHash = hasher.HashPassword(member, "pass123");
            }

            builder.Entity<ApplicationUser>().HasData(members);

            // Seed UserRoles
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { UserId = 1, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 2, RoleId = 1 },
                new IdentityUserRole<int> { UserId = 3, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 4, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 5, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 6, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 7, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 8, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 9, RoleId = 2 },
                new IdentityUserRole<int> { UserId = 10, RoleId = 2 }
            );

            // Seed Other Entites
            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Science Fiction" },
                new Category { CategoryId = 2, Name = "History" },
                new Category { CategoryId = 3, Name = "Self Development" },
                new Category { CategoryId = 4, Name = "Technology" },
                new Category { CategoryId = 5, Name = "Romance" },
                new Category { CategoryId = 6, Name = "Mystery" },
                new Category { CategoryId = 7, Name = "Programming" },
                new Category { CategoryId = 8, Name = "Fantasy" }
            );

            builder.Entity<Publisher>().HasData(
                new Publisher { PublisherId = 1, Name = "Penguin Books" },
                new Publisher { PublisherId = 2, Name = "HarperCollins" },
                new Publisher { PublisherId = 3, Name = "O'Reilly Media" },
                new Publisher { PublisherId = 4, Name = "Bloomsbury" },
                new Publisher { PublisherId = 5, Name = "Dar Al Maaref" }
            );

            builder.Entity<Book>().HasData(
                new Book { ISBN = "ISBN001",ImageUrl = "/uploads/books/book1.jpg", Title = "The Time Machine", Description = "A sci-fi classic", YearOfPublication = 1895, Language = "English", Author = "H.G. Wells", Price = 150m, TotalCopies = 10, AvailableCopies = 4, CategoryId = 1, PublisherId = 1 },
                new Book { ISBN = "ISBN002",ImageUrl = "/uploads/books/book2.jpg", Title = "Sapiens", Description = "A history of humankind", YearOfPublication = 2011, Language = "English", Author = "Yuval Noah Harari", Price = 300m, TotalCopies = 12, AvailableCopies = 8, CategoryId = 2, PublisherId = 2 },
                new Book { ISBN = "ISBN003",ImageUrl = "/uploads/books/book3.jpeg", Title = "Atomic Habits", Description = "Tiny changes, remarkable results", YearOfPublication = 2018, Language = "English", Author = "James Clear", Price = 250m, TotalCopies = 15, AvailableCopies = 9, CategoryId = 3, PublisherId = 2 },
                new Book { ISBN = "ISBN004",ImageUrl = "/uploads/books/book4.jpg", Title = "Clean Code", Description = "A handbook of agile software craftsmanship", YearOfPublication = 2008, Language = "English", Author = "Robert C. Martin", Price = 400m, TotalCopies = 7, AvailableCopies = 2, CategoryId = 7, PublisherId = 3 },
                new Book { ISBN = "ISBN005",ImageUrl = "/uploads/books/book5.jpeg", Title = "The Notebook", Description = "Romantic drama novel", YearOfPublication = 1996, Language = "English", Author = "Nicholas Sparks", Price = 180m, TotalCopies = 10, AvailableCopies = 3, CategoryId = 5, PublisherId = 1 },
                new Book { ISBN = "ISBN006",ImageUrl = "/uploads/books/book6.jpeg", Title = "Sherlock Holmes", Description = "Mystery detective stories", YearOfPublication = 1892, Language = "English", Author = "Arthur Conan Doyle", Price = 220m, TotalCopies = 14, AvailableCopies = 6, CategoryId = 6, PublisherId = 1 },
                new Book { ISBN = "ISBN007",ImageUrl = "/uploads/books/book7.jpg", Title = "Harry Potter 1", Description = "Fantasy novel", YearOfPublication = 1997, Language = "English", Author = "J.K. Rowling", Price = 350m, TotalCopies = 20, AvailableCopies = 5, CategoryId = 8, PublisherId = 4 },
                new Book { ISBN = "ISBN008",ImageUrl = "/uploads/books/book8.jpg", Title = "Deep Work", Description = "Rules for focused success", YearOfPublication = 2016, Language = "English", Author = "Cal Newport", Price = 180m, TotalCopies = 5, AvailableCopies = 1, CategoryId = 3, PublisherId = 2 },
                new Book { ISBN = "ISBN009",ImageUrl = "/uploads/books/book9.jpg", Title = "Introduction to Algorithms", Description = "Comprehensive algorithms book", YearOfPublication = 2009, Language = "English", Author = "Cormen et al.", Price = 600m, TotalCopies = 10, AvailableCopies = 10, CategoryId = 7, PublisherId = 3 },
                new Book { ISBN = "ISBN010",ImageUrl = "/uploads/books/book10.jpg", Title = "The Alchemist", Description = "Spiritual journey novel", YearOfPublication = 1988, Language = "English", Author = "Paulo Coelho", Price = 200m, TotalCopies = 12, AvailableCopies = 8, CategoryId = 5, PublisherId = 2 },
                new Book { ISBN = "ISBN011",ImageUrl = "/uploads/books/book11.jpeg", Title = "The Hobbit", Description = "Fantasy adventure novel", YearOfPublication = 1937, Language = "English", Author = "J.R.R. Tolkien", Price = 300m, TotalCopies = 9, AvailableCopies = 4, CategoryId = 8, PublisherId = 4 },
                new Book { ISBN = "ISBN012",ImageUrl = "/uploads/books/book12.jpg", Title = "Zero to One", Description = "Startup guide", YearOfPublication = 2014, Language = "English", Author = "Peter Thiel", Price = 250m, TotalCopies = 8, AvailableCopies = 1, CategoryId = 4, PublisherId = 2 },
                new Book { ISBN = "ISBN013",ImageUrl = "/uploads/books/book13.jpg", Title = "Data Structures in Python", Description = "Programming concepts", YearOfPublication = 2021, Language = "English", Author = "Michael T. Goodrich", Price = 450m, TotalCopies = 7, AvailableCopies = 7, CategoryId = 7, PublisherId = 3 },
                new Book { ISBN = "ISBN014",ImageUrl = "/uploads/books/book14.jpg", Title = "Pride and Prejudice", Description = "Classic romance", YearOfPublication = 1813, Language = "English", Author = "Jane Austen", Price = 160m, TotalCopies = 5, AvailableCopies = 2, CategoryId = 5, PublisherId = 1 },
                new Book { ISBN = "ISBN015",ImageUrl = "/uploads/books/book15.jpeg", Title = "Egypt's History", Description = "History of Egypt", YearOfPublication = 1998, Language = "Arabic", Author = "Zaki Naguib Mahmoud", Price = 120m, TotalCopies = 6, AvailableCopies = 6, CategoryId = 2, PublisherId = 5 }
            );

            builder.Entity<BorrowingBook>().HasData(
                new BorrowingBook { BorrowingId = 1, MemberId = 3, ISBN = "ISBN003", BorrowDate = new DateTime(2025, 9, 10), DueDate = new DateTime(2025, 9, 24), ReturnDate = new DateTime(2025, 9, 23), Status = BorrowingStatus.Returned},
                new BorrowingBook { BorrowingId = 2, MemberId = 5, ISBN = "ISBN004", BorrowDate = new DateTime(2025, 11, 12), DueDate = new DateTime(2025, 11, 26), ReturnDate = null, Status = BorrowingStatus.Borrowed },
                new BorrowingBook { BorrowingId = 3, MemberId = 5, ISBN = "ISBN007", BorrowDate = new DateTime(2025, 8, 25), DueDate = new DateTime(2025, 9, 8), ReturnDate = new DateTime(2025, 9, 7), Status = BorrowingStatus.Returned },
                new BorrowingBook { BorrowingId = 4, MemberId = 6, ISBN = "ISBN001", BorrowDate = new DateTime(2025, 9, 28), DueDate = new DateTime(2025, 10, 11), ReturnDate = null, Status = BorrowingStatus.OverDue },
                new BorrowingBook { BorrowingId = 5, MemberId = 7, ISBN = "ISBN006", BorrowDate = new DateTime(2025, 11, 15), DueDate = new DateTime(2025, 11, 22), ReturnDate = null, Status = BorrowingStatus.Borrowed },
                new BorrowingBook { BorrowingId = 6, MemberId = 8, ISBN = "ISBN010", BorrowDate = new DateTime(2025, 6, 30), DueDate = new DateTime(2025, 7, 13), ReturnDate = new DateTime(2025, 7, 15), Status = BorrowingStatus.Returned },
                new BorrowingBook { BorrowingId = 7, MemberId = 9, ISBN = "ISBN002", BorrowDate = new DateTime(2025, 11, 14), DueDate = new DateTime(2025, 11, 28), ReturnDate = null, Status = BorrowingStatus.Borrowed },
                new BorrowingBook { BorrowingId = 8, MemberId = 10, ISBN = "ISBN011", BorrowDate = new DateTime(2025, 11, 17), DueDate = new DateTime(2025, 11, 22), ReturnDate = null, Status = BorrowingStatus.OverDue },
                new BorrowingBook { BorrowingId = 9, MemberId = 5, ISBN = "ISBN005", BorrowDate = new DateTime(2025, 11, 22), DueDate = new DateTime(2025, 12, 4), ReturnDate = null, Status = BorrowingStatus.Borrowed },
                new BorrowingBook { BorrowingId = 10, MemberId = 3, ISBN = "ISBN012", BorrowDate = new DateTime(2025, 1, 26), DueDate = new DateTime(2025, 2, 9), ReturnDate = new DateTime(2025, 2, 13), Status = BorrowingStatus.Returned }
            );


            builder.Entity<Reservation>().HasData(
                new Reservation { ReservationId = 1, MemberId = 3, ISBN = "ISBN007",  Date = new DateTime(2025, 8, 20), Status = ReservationStatus.Waiting, ExpiryDate = new DateTime(2025, 8, 27) },
                new Reservation { ReservationId = 2, MemberId = 4, ISBN = "ISBN003",  Date = new DateTime(2025, 9, 5), Status = ReservationStatus.Completed, ExpiryDate = new DateTime(2025, 9, 12) },
                new Reservation { ReservationId = 3, MemberId = 6, ISBN = "ISBN010",  Date = new DateTime(2025, 6, 25), Status = ReservationStatus.Canceled, ExpiryDate = new DateTime(2025, 7, 2) },
                new Reservation { ReservationId = 4, MemberId = 8, ISBN = "ISBN001",  Date = new DateTime(2025, 9, 20), Status = ReservationStatus.Waiting, ExpiryDate = new DateTime(2025, 9, 30) },
                new Reservation { ReservationId = 5, MemberId = 9, ISBN = "ISBN011",  Date = new DateTime(2025, 11, 10), Status = ReservationStatus.Waiting, ExpiryDate = new DateTime(2025, 11, 18) },
                new Reservation { ReservationId = 6, MemberId = 10, ISBN = "ISBN006",  Date = new DateTime(2025, 11, 12), Status = ReservationStatus.Completed, ExpiryDate = new DateTime(2025, 11, 17) }
            );


            builder.Entity<Fine>().HasData(
                new Fine { FineId = 1, MemberId = 8, BorrowingId = 6, Amount = 20m, FineDate = new DateTime(2025, 7, 16), IsPaid = true },
                new Fine { FineId = 2, MemberId = 3, BorrowingId = 10, Amount = 40m, FineDate = new DateTime(2025, 2, 14), IsPaid = true},
                new Fine { FineId = 3, MemberId = 6, BorrowingId = 4, Amount = 50m, FineDate = new DateTime(2025, 10, 16), IsPaid = false},
                new Fine { FineId = 4, MemberId = 10, BorrowingId = 8, Amount = 100m, FineDate = new DateTime(2025, 12, 2), IsPaid = false}
            );

            builder.Entity<Settings>().HasData(new Settings { SettingsId = 1 });



        }
    }
}
