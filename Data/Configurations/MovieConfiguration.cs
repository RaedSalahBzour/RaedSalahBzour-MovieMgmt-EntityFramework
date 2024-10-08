﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Data.ValueConvertors;
using MovieManagement.Modles;

namespace MovieManagement.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasQueryFilter(m => m.ReleaseDate >= new DateTime(2000, 1, 1))
                .HasKey(movie => movie.Id);

            builder.Property(movie => movie.Title)
                   .HasMaxLength(50).HasColumnType("varchar")
                   .IsRequired();

            builder.Property(movie => movie.ReleaseDate).HasColumnType("char(8)")
                .HasConversion(new DateTimeToChar8Converter());
            builder.HasAlternateKey(movie => new { movie.ReleaseDate, movie.Title });

            builder.Property(movie => movie.Synopsis).HasColumnType("varchar(max)");

            builder.Property(movie => movie.AgeRating).HasColumnType("varchar(32)")
                                                      .HasConversion<string>();

            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreId);

            //builder.OwnsOne(movie => movie.Director)
            //       .ToTable("movie_directors");

            //builder.OwnsMany(movie => movie.Actors)
            //       .ToTable("movie_actors");


        }

    }


}
