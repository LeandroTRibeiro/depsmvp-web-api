using DepsMvp.Application.DTOs;

namespace DepsMvp.Application.Services;

public interface ICompanyServices
{
    Task<ResponseGeneric<CompanyResponse>> GetCompany(string cnpj, string referenceDate, int interval);
}