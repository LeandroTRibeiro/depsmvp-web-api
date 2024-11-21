using depsmvp.domain.Entities.Company;

namespace DepsMvp.Application.Services;

public interface ICompanyRepository
{
    Task AddCompanyAsync(Company company);

    Task<Company> GetCompanyByCnpjAsync(string cnpj);
}