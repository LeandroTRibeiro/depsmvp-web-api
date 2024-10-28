using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace depsmvp.insfrastructure.DB.Repositories;

public class ConsultationRepository : IConsultRepository
{
    private readonly ApplicationDbContext _context;

    public ConsultationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddConsultAsync(Consultation consultation)
    {
        await _context.Consultations.AddAsync(consultation);
        await _context.SaveChangesAsync();
    }
    
    public async Task<int> GetTotalConsultsCountAsync()
    {
        return await _context.Consultations.CountAsync();
        
    }

    public async Task<List<Consultation>> GetAllConsultsAsync(int? limit = null, int pageNumber = 1, int pageSize = 10)
    {
        var query = _context.Consultations.Include(c => c.User).AsQueryable();

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