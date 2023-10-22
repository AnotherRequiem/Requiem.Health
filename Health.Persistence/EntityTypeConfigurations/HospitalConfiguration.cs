using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Persistence.EntityTypeConfigurations;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.HasKey(hs => hs.Id);
        builder.Property(hs => hs.City).IsRequired().HasMaxLength(20);
        builder.Property(hs => hs.Name).IsRequired().HasMaxLength(50);
        builder.Property(hs => hs.Street).IsRequired().HasMaxLength(30);
        
        builder.HasMany(h => h.Departments)
            .WithOne(d => d.Hospital)
            ;
    }
}