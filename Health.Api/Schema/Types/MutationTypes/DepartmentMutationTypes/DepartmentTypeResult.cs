namespace Health.Api.Schema.Types.MutationTypes.DepartmentMutationTypes;

public class DepartmentTypeResult
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public Guid HospitalId { get; set; }
}