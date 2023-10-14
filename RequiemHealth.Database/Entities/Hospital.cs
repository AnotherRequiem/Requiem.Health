namespace RequiemHealth.Database.Entities;

public class Hospital
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    public ICollection<Departament> Departaments { get; set; }
}