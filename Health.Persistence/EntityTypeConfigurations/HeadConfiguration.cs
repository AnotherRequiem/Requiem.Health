using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Persistence.EntityTypeConfigurations;

public class HeadConfiguration : IEntityTypeConfiguration<Head>
{
    public void Configure(EntityTypeBuilder<Head> builder)
    {
        builder.HasKey(dp => dp.Id);
        builder.HasIndex(dp => dp.Id).IsUnique();
        builder.Property(dp => dp.Name).IsRequired().HasMaxLength(20);
        builder.Property(dp => dp.Surname).IsRequired().HasMaxLength(20);
        builder.Property(dp => dp.Age).IsRequired().HasMaxLength(3);
        
        builder.HasOne(h => h.Department).WithOne(d => d.Head).HasForeignKey<Head>(h => h.DepartmentId);
    }
}