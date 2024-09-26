using AutoMapper;
using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;

namespace depsmvp.insfrastructure.InternalServices;

public class CompanyServices : ICompanyService
{
    private readonly IMapper _mapper;
    private readonly IBrasilApi _brasilApi;

    public CompanyServices(IMapper mapper, IBrasilApi brasilApi)
    {
        _mapper = mapper;
        _brasilApi = brasilApi;
    }
    
    
    public async Task<ResponseGeneric<CompanyResponse>> GetCompany(string cnpj)
    {
        var company = await _brasilApi.GetCompany(cnpj);
        
        return _mapper.Map<ResponseGeneric<CompanyResponse>>(company);
    }
}