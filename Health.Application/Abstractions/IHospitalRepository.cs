using Health.Domain.Entities;

namespace Health.Application.Abstractions;

public interface IHospitalRepository
{
    Task<ICollection<Hospital>> GetAll();
    
    Task<Hospital> GetById(Guid hospitalId);
    
    Task<Hospital> Add(Hospital hospital);

    Task<Hospital> Update(Hospital hospital);

    Task<bool> Remove(Guid hospitalId); 
}