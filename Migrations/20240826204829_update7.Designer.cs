﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieManagement.Data;

#nullable disable

namespace MovieManagement.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240826204829_update7")]
    partial class update7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieManagement.Modles.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("MovieManagement.Modles.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("ReleaseDate")
                        .IsRequired()
                        .HasColumnType("char(8)");

                    b.Property<string>("Synopsis")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GenreId = 1,
                            ReleaseDate = "00010101",
                            Synopsis = "First Works OFC",
                            Title = "First"
                        });
                });

            modelBuilder.Entity("MovieManagement.Modles.Movie", b =>
                {
                    b.HasOne("MovieManagement.Modles.Genre", "Genre")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MovieManagement.Modles.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
