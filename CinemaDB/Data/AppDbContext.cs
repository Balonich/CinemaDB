using System;
using CinemaDB.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Filmography> Filmography { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().ToTable(nameof(Country));
            modelBuilder.Entity<Genre>().ToTable(nameof(Genre));
            modelBuilder.Entity<Film>().ToTable(nameof(Film));
            modelBuilder.Entity<Profession>().ToTable(nameof(Profession));
            modelBuilder.Entity<Person>().ToTable(nameof(Person));
            modelBuilder.Entity<Filmography>().ToTable(nameof(Filmography))
                                              .HasKey(fg => new { fg.FilmID, fg.PersonID, fg.ProfessionID });
        }
    }
}