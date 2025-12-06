using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BorrowingBook> BorrowingBooks { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Settings> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Relationships

            builder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<BorrowingBook>()
                .HasOne(bb => bb.Member)
                .WithMany(m => m.BorrowingBooks)
                .HasForeignKey(bb => bb.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BorrowingBook>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.Borrowings)
                .HasForeignKey(bb => bb.ISBN)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reservation>()
                .HasOne(r => r.Member)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Reservation>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.ISBN)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Fine>()
                .HasOne(f => f.Member)
                .WithMany(m => m.Fines)
                .HasForeignKey(f => f.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Fine>()
                .HasOne(f => f.Borrowing)
                .WithMany()
                .HasForeignKey(f => f.BorrowingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Enum conversions (store as strings like 'Active', 'Borrowed', etc)
            builder.Entity<BorrowingBook>().Property(b => b.Status).HasConversion<string>();
            builder.Entity<Reservation>().Property(r => r.Status).HasConversion<string>();


            builder.Entity<BorrowingBook>()
                .Property(b => b.DueDate)
                .HasComputedColumnSql("DATEADD(DAY, [DaysBorrowed], [BorrowDate])", stored: true);


            // Check constraints (EF Core supports HasCheckConstraint)
            builder.Entity<Book>()
                .ToTable(t => t.HasCheckConstraint("CK_Book_Copies", "TotalCopies >= 0 AND AvailableCopies >= 0 AND AvailableCopies <= TotalCopies"));

            builder.Entity<BorrowingBook>().ToTable(t =>
                t.HasCheckConstraint(
                    "CK_BorrowRecord_Status_ReturnDate",
                    "(Status = 'Borrowed' AND ReturnDate IS NULL) OR " +
                    "(Status = 'OverDue' AND ReturnDate IS NULL) OR " +
                    "(Status = 'Returned' AND ReturnDate IS NOT NULL)"
                )
            );

            //Seed Data
            DataSeeder.Seed(builder);
            
        }
    }
}
