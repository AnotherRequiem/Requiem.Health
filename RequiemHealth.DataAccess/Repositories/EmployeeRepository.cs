using RequiemHealth.DataAccess.Interfaces;
using RequiemHealth.Database;

namespace RequiemHealth.DataAccess.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }
}