using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            builder.Property(movie => movie.ReleaseDate).HasColumnType("date");
            builder.Property(movie => movie.Synopsis).HasColumnType("varchar(max)");
            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreId);
            builder.HasData(new Movie
            {
                Id=1,
                Title="First",
                ReleaseDate=DateTime.Now,
                Synopsis="First Works OFC",
                GenreId=1,
            });
        }
    }


}
