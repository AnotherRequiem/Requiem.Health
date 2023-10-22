namespace Health.Domain.Entities;

public class Head
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public ushort Age { get; set; }
    
    public Department Department { get; set; }
    
    public Guid DepartmentId { get; set; }
}