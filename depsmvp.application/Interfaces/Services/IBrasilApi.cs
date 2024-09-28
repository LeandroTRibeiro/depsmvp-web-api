using DepsMvp.Application.DTOs;
using depsmvp.domain.Entities.Company;

namespace DepsMvp.Application.Services;

public interface IBrasilApi
{
    Task<ResponseGeneric<Company>> GetCompany(string cnpj);
}