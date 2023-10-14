using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RequiemHealth.Database.Entities;

namespace RequiemHealth.Database;

public static class SeedData
{
    public static void Seed(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureDeleted();
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
            Departaments = new List<Departament>
            {
                new Departament
                {
                    Name = "Cardiology",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "John Smith",
                            Age = 35,
                            JobTitle = "Рead of department",
                        },
                        new Employee
                        {
                            FullName = "Sara Bloom",
                            Age = 41,
                            JobTitle = "Nurse",
                            IsFired = true
                        },
                        new Employee
                        {
                            FullName = "Mei Yong",
                            Age = 34,
                            JobTitle = "Nurse",
                        },
                        new Employee
                        {
                            FullName = "Rob Landon",
                            Age = 49,
                            JobTitle = "Medical orderly",
                        },
                        new Employee
                        {
                            FullName = "Henry Ashley",
                            Age = 30,
                            JobTitle = "Сardiologist",
                        }
                    }
                },
                new Departament
                {
                    Name = "General surgery",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "Bob Merol",
                            Age = 55,
                            JobTitle = "Head od departament",
                        },
                        new Employee
                        {
                            FullName = "Jim Odenkirk",
                            Age = 29,
                            JobTitle = "Male nurse",
                        },
                        new Employee
                        {
                            FullName = "Jeremy Lerington",
                            Age = 46,
                            JobTitle = "Surgeon",
                        },
                    }
                },
                new Departament
                {
                    Name = "Anesthesiology",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "Walter King",
                            Age = 70,
                            JobTitle = "Head of departament"
                        },
                        new Employee
                        {
                            FullName = "Tor Length",
                            Age = 25,
                            JobTitle = "Male nurse",
                            IsFired = true
                        },
                        new Employee
                        {
                            FullName = "Sam Rolling",
                            Age = 34,
                            JobTitle = "Anesthetist"
                        },
                    }
                }
                
            }
        });

        context.Hospitals.Add(new Hospital
        {
            Name = "Lutheran Community Hospital",
            City = "Kyiv",
            Street = "Bazhana 12A",
            Departaments = new List<Departament>
            {
                new Departament
                {
                    Name = "Oncology",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "Serhiy Lev",
                            Age = 43,
                            JobTitle = "Head medical"
                        }
                    }
                },
                new Departament
                {
                    Name = "Rheumatology",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "Damir Nagirniy",
                            Age = 25,
                            JobTitle = "Male Nurse",
                        },
                        new Employee()
                        {
                            FullName = "Oleksander Mal`uk",
                            Age = 33,
                            JobTitle = "Doctor"
                        }
                    }
                },
                new Departament
                {
                    Name = "Gastroenterology",
                    Employees = new List<Employee>
                    {
                        new Employee
                        {
                            FullName = "Oksana Nabaeva",
                            Age = 44,
                            JobTitle = "Nurse",
                        },
                        new Employee()
                        {
                            FullName = "Varvara Shevchenko",
                            Age = 30,
                            JobTitle = "Doctor"
                        }
                    }
                }
            }
        });

        context.SaveChanges();
    }
}