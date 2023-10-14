using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequiemHealth.Database.Entities;

namespace RequiemHealth.Database.EntityTypeConfigurations;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.HasKey(hs => hs.Id);
        builder.HasIndex(hs => hs.Id).IsUnique();
        builder.Property(hs => hs.City).IsRequired().HasMaxLength(20);
        builder.Property(hs => hs.Name).IsRequired().HasMaxLength(50);
        builder.Property(hs => hs.Street).IsRequired().HasMaxLength(30);
    }
}