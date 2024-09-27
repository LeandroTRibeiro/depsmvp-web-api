using DepsMvp.Application.Services;
using depsmvp.domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

namespace depsmvp.insfrastructure.DB.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CompanyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddCompanyAsync(Company company)
    {
        company.SearchDate = DateTime.UtcNow;
        
        var existingCompany = await _dbContext.Companies
            .FirstOrDefaultAsync(
                c => c.Cnpj!.Equals(company.Cnpj) && 
                     c.SearchDate.Date.Equals(company.SearchDate.Date));

        if (existingCompany != null)
        {
            return;
        }
        
        await _dbContext.Companies.AddAsync(company);
        await _dbContext.SaveChangesAsync();
    }
}