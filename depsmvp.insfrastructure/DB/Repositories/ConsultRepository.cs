using DepsMvp.Application.Services;
using depsmvp.domain.Entities;

namespace depsmvp.insfrastructure.DB.Repositories;

public class ConsultRepository : IConsultRepository
{
    private readonly ApplicationDbContext _context;

    public ConsultRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddConsultAsync(Consult consult)
    {
        await _context.Consults.AddAsync(consult);
        await _context.SaveChangesAsync();
    }
}