using Health.Application.Abstractions;
using Health.Application.Common.Exceptions;
using Health.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Health.Persistence.Repositories;

public class HospitalRepository : IHospitalRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    
    public HospitalRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }
    
    public async Task<ICollection<Hospital>> GetAll()
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        
        return await context.Hospitals.ToListAsync();
    }

    public async Task<Hospital> GetById(Guid hospitalId)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        var hospital = await context.Hospitals.FirstOrDefaultAsync(p => p.Id == hospitalId);
        
        if (hospital == null) throw new NotFoundException(nameof(Hospital), hospitalId);
        
        return hospital;
    }

    public async Task<Hospital> Add(Hospital hospital)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        
        context.Hospitals.Add(hospital);
        await context.SaveChangesAsync();
        
        return hospital;
    }

    public async Task<Hospital> Update(Hospital hospital)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();

        context.Hospitals.Update(hospital);
        await context.SaveChangesAsync();
        
        return hospital;
    }
    
    public async Task<bool> Remove(Guid hospitalId)
    {
        await using ApplicationDbContext context = await _contextFactory.CreateDbContextAsync();
        
        var hospital = context.Hospitals
            .FirstOrDefault(p => p.Id == hospitalId);

        if (hospital is null) throw new NotFoundException(nameof(Hospital), hospitalId);

        context.Hospitals.Remove(hospital);

        return await context.SaveChangesAsync() > 0;
    }
}