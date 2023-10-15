using RequiemHealth.DataAccess.Interfaces;
using RequiemHealth.Database;

namespace RequiemHealth.DataAccess.Repositories;

public class HospitalRepository : IHospitalRepository
{
    private readonly ApplicationDbContext _context;

    public HospitalRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}