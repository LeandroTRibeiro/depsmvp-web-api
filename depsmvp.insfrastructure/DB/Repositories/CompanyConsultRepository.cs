using DepsMvp.Application.Services;
using depsmvp.domain.Entities;

namespace depsmvp.insfrastructure.DB.Repositories;

public class CompanyConsultRepository : ICompanyConsultRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CompanyConsultRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(CompanyConsult companyConsult)
    {
        await _dbContext.CompanyConsults.AddAsync(companyConsult);
        await _dbContext.SaveChangesAsync();
    }
}