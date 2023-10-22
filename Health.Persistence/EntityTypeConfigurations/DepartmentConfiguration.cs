using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Health.Persistence.EntityTypeConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(dp => dp.Id);
        builder.Property(dp => dp.Name).IsRequired().HasMaxLength(20);
        
        builder.HasOne(d => d.Hospital)
            .WithMany(h => h.Departments)
            .HasForeignKey(d => d.HospitalId);

         
    }
}