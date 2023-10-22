namespace Health.Api.Schema.Types.MutationTypes.DepartmentMutationTypes;

public class DepartmentTypeInput
{
    public string Name { get; set; }
    
    public Guid HospitalId { get; set; }
}