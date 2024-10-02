using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using Microsoft.EntityFrameworkCore;

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
    
    public async Task<int> GetTotalConsultsCountAsync()
    {
        return await _context.Consults.CountAsync();
        
    }

    public async Task<List<Consult>> GetAllConsultsAsync(int? limit = null, int pageNumber = 1, int pageSize = 10)
    {
        var query = _context.Consults.AsQueryable();

        if (pageNumber > 0 && pageSize > 0)
        {
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        if (limit.HasValue && limit > 0)
        {
            query = query.Take(limit.Value);
        }

        return await query.ToListAsync();
    }

}