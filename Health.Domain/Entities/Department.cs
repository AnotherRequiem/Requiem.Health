namespace Health.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Head Head { get; set; }
    
    public Hospital Hospital { get; set; }
    
    public Guid HospitalId { get; set; }
    
}