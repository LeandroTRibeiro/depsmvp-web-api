using DepsMvp.Application.DTOs;

namespace DepsMvp.Application.Services;

public interface ICompanyServices
{
    Task<ResponseGeneric<CompanyResponse>> GetCompanyAsync(string cnpj, string referenceDate, int interval);
    
    Task<ResponseGeneric<CompanyResponse>> GetCompanyByConsultationtIdAsync(int consultationId);

}