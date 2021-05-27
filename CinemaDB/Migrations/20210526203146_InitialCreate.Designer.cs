﻿// <auto-generated />
using System;
using CinemaDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CinemaDB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210526203146_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaDB.Models.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CinemaDB.Models.Film", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeRestriction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StudioID")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.HasIndex("StudioID");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("CinemaDB.Models.Filmography", b =>
                {
                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("ProfessionID")
                        .HasColumnType("int");

                    b.HasKey("FilmID", "PersonID", "ProfessionID");

                    b.HasIndex("PersonID");

                    b.HasIndex("ProfessionID");

                    b.ToTable("Filmography");
                });

            modelBuilder.Entity("CinemaDB.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("CinemaDB.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MidName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PortraitImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("CinemaDB.Models.Profession", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Profession");
                });

            modelBuilder.Entity("CinemaDB.Models.Studio", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.Property<int>("FilmsID")
                        .HasColumnType("int");

                    b.Property<int>("GenresID")
                        .HasColumnType("int");

                    b.HasKey("FilmsID", "GenresID");

                    b.HasIndex("GenresID");

                    b.ToTable("FilmGenre");
                });

            modelBuilder.Entity("CinemaDB.Models.Film", b =>
                {
                    b.HasOne("CinemaDB.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");

                    b.HasOne("CinemaDB.Models.Studio", "Studio")
                        .WithMany("PublishedFilms")
                        .HasForeignKey("StudioID");

                    b.Navigation("Country");

                    b.Navigation("Studio");
                });

            modelBuilder.Entity("CinemaDB.Models.Filmography", b =>
                {
                    b.HasOne("CinemaDB.Models.Film", "Film")
                        .WithMany("People")
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaDB.Models.Person", "Person")
                        .WithMany("Filmography")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaDB.Models.Profession", "Profession")
                        .WithMany("Filmography")
                        .HasForeignKey("ProfessionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Person");

                    b.Navigation("Profession");
                });

            modelBuilder.Entity("CinemaDB.Models.Person", b =>
                {
                    b.HasOne("CinemaDB.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FilmGenre", b =>
                {
                    b.HasOne("CinemaDB.Models.Film", null)
                        .WithMany()
                        .HasForeignKey("FilmsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaDB.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CinemaDB.Models.Film", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("CinemaDB.Models.Person", b =>
                {
                    b.Navigation("Filmography");
                });

            modelBuilder.Entity("CinemaDB.Models.Profession", b =>
                {
                    b.Navigation("Filmography");
                });

            modelBuilder.Entity("CinemaDB.Models.Studio", b =>
                {
                    b.Navigation("PublishedFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
