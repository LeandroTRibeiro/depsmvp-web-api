using DepsMvp.Application.Services;
using depsmvp.domain.Entities;

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
    
}