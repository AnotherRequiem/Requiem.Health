using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequiemHealth.Database.Entities;

namespace RequiemHealth.Database.EntityTypeConfigurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(emp => emp.Id);
        builder.HasIndex(emp => emp.Id).IsUnique();
        builder.Property(emp => emp.Age).IsRequired();
        builder.Property(emp => emp.FullName).IsRequired().HasMaxLength(50);
        builder.Property(emp => emp.JobTitle).IsRequired();
        builder.Property(emp => emp.IsFired).HasConversion<bool>();
    }
}