namespace Health.Domain.Entities;

public class Hospital
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    public ICollection<Department> Departments { get; set; }
    
}