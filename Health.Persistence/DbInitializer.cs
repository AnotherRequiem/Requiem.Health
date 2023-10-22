using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Health.Persistence;

public static class DbInitializer
{
    public static void Seed(this IHost host)
    {
        using IServiceScope scope = host.Services.CreateScope();
        IDbContextFactory<ApplicationDbContext> contextFactory =
            scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();

        using ApplicationDbContext context = contextFactory.CreateDbContext();
        context.Database.EnsureCreated();
        AddData(context);
    }

    private static void AddData(ApplicationDbContext context)
    {
        var hospitals = context.Hospitals.FirstOrDefault();
        if (hospitals != null) return;

        context.Hospitals.Add(new Hospital
        {
            Name = "Massachusetts General Hospital",
            City = "Boston",
            Street = "55 Fruit Street",
            Departments = new List<Department>()
            {
                new Department()
                {
                    Name = "Cardiology",
                    Head = new Head()
                    {
                        Name = "Nina",
                        Surname = "Boyko",
                        Age = 45
                    }
                }
            }
            
        });

        context.Hospitals.Add(new Hospital
        {
            Name = "Lutheran Community Hospital",
            City = "Kyiv",
            Street = "Bazhana 12A",
            Departments = new List<Department>()
            {
                new Department()
                {
                    Name = "Surgery",
                    Head = new Head()
                    {
                        Name = "John",
                        Surname = "Bayker",
                        Age = 37
                    }
                    
                }
            } 
        });

        context.SaveChanges();
    }
}
