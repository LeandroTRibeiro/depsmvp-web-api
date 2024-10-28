using depsmvp.domain.Entities;
using depsmvp.domain.Entities.Company;

namespace DepsMvp.Application.Services;

public interface ICompanyConsultRepository
{
    Task AddAsync(CompanyConsult companyConsult);
    
    Task<Company> GetCompanyByConsultationtIdAsync(int consultationId);
}