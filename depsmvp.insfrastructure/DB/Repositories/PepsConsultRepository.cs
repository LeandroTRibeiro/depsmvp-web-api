using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace depsmvp.insfrastructure.DB.Repositories;

public class PepsConsultRepository : IPepsConsultRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PepsConsultRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRangeAsync(List<PepsConsult> pepConsults)
    {
        await _dbContext.PepConsults.AddRangeAsync(pepConsults);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Pep>> GetPepsByConsultationtIdAsync(int consultationId)
    {
        var peps = await _dbContext.PepConsults
            .Where(pc => pc.ConsultationId == consultationId)
            .Include(pc => pc.Pep)
            .Select(pc => pc.Pep)
            .ToListAsync();
        
        return peps;
    } 
}