using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GraphQL_API.Models
{
    public partial class DVD_LibraryContext : DbContext
    {
        public DVD_LibraryContext()
        {
        }

        public DVD_LibraryContext(DbContextOptions<DVD_LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AudioFormat> AudioFormat { get; set; }
        public virtual DbSet<Dvd> Dvd { get; set; }
        public virtual DbSet<Dvdlanguage> Dvdlanguage { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Filename=DVD_Library.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AudioFormat>(entity =>
            {
                entity.HasKey(e => e.AudioId);

                entity.HasIndex(e => e.AudioId)
                    .IsUnique();

                entity.Property(e => e.AudioId)
                    .HasColumnName("audio_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasColumnName("format");
            });

            modelBuilder.Entity<Dvd>(entity =>
            {
                entity.ToTable("DVD");

                entity.Property(e => e.DvdId)
                    .HasColumnName("dvd_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Edition).HasColumnName("edition");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn");

                entity.Property(e => e.MovieId).HasColumnName("movie_id");

                entity.Property(e => e.Region).HasColumnName("region");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Dvd)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Dvdlanguage>(entity =>
            {
                entity.ToTable("DVDLanguage");

                entity.Property(e => e.DvdLanguageId)
                    .HasColumnName("dvd_language_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AudioFormatId).HasColumnName("audio_format_id");

                entity.Property(e => e.DvdId).HasColumnName("dvd_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.HasOne(d => d.AudioFormat)
                    .WithMany(p => p.Dvdlanguage)
                    .HasForeignKey(d => d.AudioFormatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Dvd)
                    .WithMany(p => p.Dvdlanguage)
                    .HasForeignKey(d => d.DvdId);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Dvdlanguage)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.GenreId)
                    .IsUnique();

                entity.Property(e => e.GenreId)
                    .HasColumnName("genre_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Genre1)
                    .IsRequired()
                    .HasColumnName("genre");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIndex(e => e.LanguageId)
                    .IsUnique();

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Language1)
                    .IsRequired()
                    .HasColumnName("language");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasIndex(e => e.MovieId)
                    .IsUnique();

                entity.Property(e => e.MovieId)
                    .HasColumnName("movie_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.MovieTitle)
                    .IsRequired()
                    .HasColumnName("movie_title");

                entity.Property(e => e.ReleaseDate)
                    .IsRequired()
                    .HasColumnName("release_date");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
