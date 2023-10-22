using Health.Api.Schema.Types;
using Health.Domain.Entities;
using Health.Persistence.Repositories;

namespace Health.Api.Schema.Queries;

public class HospitalQuery
{
    private readonly HospitalRepository _repository;

    public HospitalQuery(HospitalRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<HospitalType>> GetAllHospitals()
    {
        var hospitals = await _repository.GetAll();
        
        var hospitalsResult = hospitals.Select(h => new HospitalType()
        {
            Id = h.Id,
            Name = h.Name,
            City = h.City,
            Street = h.Street
        });

        return hospitalsResult;
    }

    public async Task<HospitalType> GetHospitalById(Guid id)
    {
        var hospital = await _repository.GetById(id);
        
        var hospitalResult = new HospitalType()
        {
            Id = hospital.Id,
            Name = hospital.Name,
            City = hospital.City,
            Street = hospital.Street
        };
        
        return hospitalResult;
    }
}