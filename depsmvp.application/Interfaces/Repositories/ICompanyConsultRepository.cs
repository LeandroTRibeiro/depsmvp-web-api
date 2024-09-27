using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface ICompanyConsultRepository
{
    Task AddAsync(CompanyConsult companyConsult);
}