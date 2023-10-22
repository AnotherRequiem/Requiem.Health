using Health.Application.Abstractions;
using Health.Application.Common.Exceptions;
using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Health.Persistence.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    
    public DepartmentRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    
    public async Task<ICollection<Department>> GetAll()
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        
        return await context.Departments.ToListAsync();
    }

    public async Task<Department> GetById(Guid departmentId)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        var department = await context.Departments.FirstOrDefaultAsync(dp => dp.Id == departmentId);
        
        if (department == null) throw new NotFoundException(nameof(Hospital), departmentId);
        
        return department;
    }

    public async Task<Department> Add(Department department)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        
        context.Departments.Add(department);
        await context.SaveChangesAsync();
        
        return department;
    }

    public async Task<Department> Update(Department department)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();

        context.Departments.Update(department);
        await context.SaveChangesAsync();
        
        return department;
    }

    public async Task<bool> Remove(Guid departmentId)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        
        var department = context.Departments
            .FirstOrDefault(p => p.Id == departmentId);

        if (department is null) throw new NotFoundException(nameof(Hospital), departmentId);

        context.Departments.Remove(department);

        return await context.SaveChangesAsync() > 0;
    }
}