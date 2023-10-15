using RequiemHealth.DataAccess.Interfaces;
using RequiemHealth.Database;

namespace RequiemHealth.DataAccess.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}