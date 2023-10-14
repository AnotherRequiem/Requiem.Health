namespace RequiemHealth.Database.Entities;

public class Departament
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ICollection<Employee> Employees { get; set; }
}