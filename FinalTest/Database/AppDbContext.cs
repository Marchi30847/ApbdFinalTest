using FinalTest.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalTest.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<PublishingHouse> PublishingHouses { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<BookGenre> BookGenres { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<BookAuthor> BookAuthors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PublishingHouse>(entity =>
        {
            entity.ToTable("PublishingHouses");
            entity.HasKey(ph => ph.IdPublishingHouse);

            entity.Property(ph => ph.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(ph => ph.Country)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(ph => ph.City)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasMany(ph => ph.Books)
                .WithOne(b => b.PublishingHouse)
                .HasForeignKey(b => b.IdPublishingHouse);
        });
        
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");
            entity.HasKey(b => b.IdBook);

            entity.Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(b => b.ReleaseDate)
                .IsRequired();

            entity.HasMany(b => b.Genres)
                .WithOne(g => g.Book)
                .HasForeignKey(g => g.IdBook);
            
            entity.HasMany(b => b.Authors)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.IdBook);
        }); 
        
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");
            entity.HasKey(g => g.IdGenre);

            entity.Property(g => g.Name)
                .HasMaxLength(50)
                .IsRequired();
            
            entity.HasMany(g => g.Books)
                .WithOne(b => b.Genre)
                .HasForeignKey(b => b.IdGenre);
        }); 
        
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");
            entity.HasKey(a => a.IdAuthor);

            entity.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            
            entity.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();
            
            entity.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.IdAuthor);
        }); 
        
        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity.ToTable("Book_Genre");
            entity.HasKey(b => new { b.IdBook, b.IdGenre });
        }); 
        
        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity.ToTable("Book_Author");
            entity.HasKey(b => new { b.IdBook, b.IdAuthor });
        }); 
    }
}