using Health.Api.Schema.Types.MutationTypes.DepartmentMutationTypes;
using Health.Api.Schema.Types.MutationTypes.HospitalMutationTypes;
using Health.Domain.Entities;
using Health.Persistence.Repositories;

namespace Health.Api.Schema.Mutations;

public class Mutation
{
    private readonly HospitalRepository _hospitalRepository;
    private readonly DepartmentRepository _departmentRepository;

    public Mutation(HospitalRepository hospitalRepository, DepartmentRepository departmentRepository)
    {
        _hospitalRepository = hospitalRepository;
        _departmentRepository = departmentRepository;
    }
    
    public async Task<DepartmentTypeResult> CreateDepartment(DepartmentTypeInput departmentTypeInput)
    {
        var department = new Department()
        {
            Id = Guid.NewGuid(),
            Name = departmentTypeInput.Name,
            HospitalId = departmentTypeInput.HospitalId
        };

        department = await _departmentRepository.Add(department);

        var departmentResult = new DepartmentTypeResult()
        {
            Id = department.Id,
            Name = department.Name,
            HospitalId = department.HospitalId
        };
        
        return departmentResult;
    }
    
    public async Task<HospitalTypeResult> CreateHospital(HospitalTypeInput hospitalTypeInput)
    {
        var hospital = new Hospital()
        {
            Id =  Guid.NewGuid(),
            Name = hospitalTypeInput.Name,
            City = hospitalTypeInput.City,
            Street = hospitalTypeInput.Street
        };

        hospital = await _hospitalRepository.Add(hospital);

        var hospitalResult = new HospitalTypeResult()
        {
            Id = hospital.Id,
            Name = hospital.Name,
            City = hospital.City,
            Street = hospital.Street
        };

        return hospitalResult;
    }

    public async Task<HospitalTypeResult> UpdateHospital(Guid id, HospitalTypeInput hospitalTypeInput)
    {
        var hospital = new Hospital()
        {
            Id =  id,
            Name = hospitalTypeInput.Name,
            City = hospitalTypeInput.City,
            Street = hospitalTypeInput.Street
        };

        hospital = await _hospitalRepository.Update(hospital);
        
        var hospitalResult = new HospitalTypeResult()
        {
            Id = hospital.Id,
            Name = hospital.Name,
            City = hospital.City,
            Street = hospital.Street
        };

        return hospitalResult;
    }

    public async Task<bool> DeleteHospital(Guid id)
    {
        return await _hospitalRepository.Remove(id);
    }
}