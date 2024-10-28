using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using depsmvp.domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Company> GetCompanyByConsultationtIdAsync(int consultationId)
    {
        return await _dbContext.CompanyConsults
            .Where(cp => cp.ConsultationId == consultationId)
            .Include(cp => cp.Company)
            .Select(cp => cp.Company)
            .SingleOrDefaultAsync() ?? new Company();
    }
}