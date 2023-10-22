using Health.Api.Schema.Types.MutationTypes.DepartmentMutationTypes;
using Health.Domain.Entities;
using Health.Persistence.Repositories;

namespace Health.Api.Schema.Mutations;

public class DepartmentMutation
{
    private readonly DepartmentRepository _repository;

    public DepartmentMutation(DepartmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<DepartmentTypeResult> CreateDepartment(DepartmentTypeInput departmentTypeInput)
    {
        var department = new Department()
        {
            Id = Guid.NewGuid(),
            Name = departmentTypeInput.Name,
            HospitalId = departmentTypeInput.HospitalId
        };

        department = await _repository.Add(department);

        var departmentResult = new DepartmentTypeResult()
        {
            Id = department.Id,
            Name = department.Name,
            HospitalId = department.HospitalId
        };
        
        return departmentResult;
    }
}