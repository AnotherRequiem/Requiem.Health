using Microsoft.EntityFrameworkCore;
using RequiemHealth.Database.Entities;
using RequiemHealth.Database.EntityTypeConfigurations;

namespace RequiemHealth.Database;

public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }
    
    
    public DbSet<Hospital> Hospitals { get; set; }
    
    public DbSet<Department> Departaments { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HospitalConfiguration());
        modelBuilder.ApplyConfiguration(new DepartamentConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}