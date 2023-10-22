using Health.Domain.Entities;

namespace Health.Application.Abstractions;

public interface IDepartmentRepository
{
    Task<ICollection<Department>> GetAll();
    
    Task<Department> GetById(Guid departmentId);
    
    Task<Department> Add(Department department);

    Task<Department> Update(Department department);

    Task<bool> Remove(Guid departmentId); 
}