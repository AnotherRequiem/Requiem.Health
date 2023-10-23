using Health.Domain.Entities;

namespace Health.Api.Schema;

public class HospitalType
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string City { get; set; }
    
    public string Street { get; set; }
    
    //public ICollection<Department> Departments { get; set; }
}