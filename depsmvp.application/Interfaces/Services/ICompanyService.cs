using DepsMvp.Application.DTOs;

namespace DepsMvp.Application.Services;

public interface ICompanyService
{
    public Task<ResponseGeneric<CompanyResponse>> GetCompany(string cnpj);
}