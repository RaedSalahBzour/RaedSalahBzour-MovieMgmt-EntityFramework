using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Data.ValueConvertors;
using MovieManagement.Modles;
using System.Reflection.Emit;

namespace MovieManagement.Data.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(movie => movie.Id);
            builder.Property(movie => movie.Title)
                   .HasMaxLength(50).HasColumnType("varchar")
                   .IsRequired();

            builder.Property(movie => movie.ReleaseDate).HasColumnType("char(8)")
                .HasConversion(new DateTimeToChar8Converter());

            builder.Property(movie => movie.Synopsis).HasColumnType("varchar(max)");

            builder.Property(movie => movie.AgeRating).HasColumnType("varchar(32)")
                                                      .HasConversion<string>();

            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreId);

            builder.HasData(new Movie
            {
                Id = 1,
                Title = "First",
                ReleaseDate = new DateTime(2024,9,12),
                Synopsis = "First Works OFC",
                GenreId = 1,
                AgeRating=AgeRating.Adolescent,
            });
        }
    }


}
