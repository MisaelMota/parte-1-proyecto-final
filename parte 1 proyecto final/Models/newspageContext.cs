using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class newspageContext : DbContext
    {
        public newspageContext()
        {
        }

        public newspageContext(DbContextOptions<newspageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=DESKTOP-CQ049J0;Database=newspage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Author1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Author");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Country1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Country");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Content)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PublishedAt).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.UrlToImage)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("urlToImage");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("Fk_AuthorId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("Fk_CategoryId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("Fk_CountryId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Fk_UserId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Passw)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("Fk_UserTypeId");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType");

                entity.Property(e => e.UserType1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UserType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
