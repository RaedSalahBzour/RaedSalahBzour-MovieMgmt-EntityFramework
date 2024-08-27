using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieManagement.Data.ValueGenerators;
using MovieManagement.Modles;

namespace MovieManagement.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.Property<DateTime>("CreatedDate")
                   .HasColumnName("CreatedAt")
                   .HasValueGenerator<CreatedDAteTimeGenerator>();

        }
    }
}
