using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequiemHealth.Database.Entities;

namespace RequiemHealth.Database.EntityTypeConfigurations;

public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
{
    public void Configure(EntityTypeBuilder<Departament> builder)
    {
        builder.HasKey(dp => dp.Id);
        builder.HasIndex(dp => dp.Id).IsUnique();
        builder.Property(dp => dp.Name).IsRequired().HasMaxLength(20);
    }
}