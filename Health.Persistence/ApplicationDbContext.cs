using Health.Domain.Entities;
using Health.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Health.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Head> Heads { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HospitalConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new HeadConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}