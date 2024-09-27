using System.Net;
using AutoMapper;
using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;

namespace depsmvp.insfrastructure.InternalServices;

public class CompanyServices : ICompanyService
{
    private readonly IMapper _mapper;
    private readonly IBrasilApi _brasilApi;
    private readonly ICompanyRepository _companyRepository;

    public CompanyServices(IMapper mapper, IBrasilApi brasilApi, ICompanyRepository companyRepository)
    {
        _mapper = mapper;
        _brasilApi = brasilApi;
        _companyRepository = companyRepository;
    }
    
    
    public async Task<ResponseGeneric<CompanyResponse>> GetCompany(string cnpj)
    {
        var company = await _brasilApi.GetCompany(cnpj);

        if (company.HttpCode == HttpStatusCode.OK && company.ReturnData != null)
        {
            await _companyRepository.AddCompanyAsync(company.ReturnData);
        }
        
        return _mapper.Map<ResponseGeneric<CompanyResponse>>(company);
    }
}