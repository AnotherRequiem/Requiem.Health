using Health.Api.Schema.Types.MutationTypes.HospitalMutationTypes;
using Health.Domain.Entities;
using Health.Persistence.Repositories;

namespace Health.Api.Schema.Mutations;

public class HospitalMutation
{
    private readonly HospitalRepository _repository;

    public HospitalMutation(HospitalRepository repository)
    {
        _repository = repository;
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

        hospital = await _repository.Add(hospital);

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

        hospital = await _repository.Update(hospital);
        
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
        return await _repository.Remove(id);
    }
}