using System.Net;
using AutoMapper;
using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using depsmvp.domain.Entities.Company;

namespace depsmvp.insfrastructure.InternalServices;

public class CompanyServices : ICompanyServices
{
    private readonly IMapper _mapper;
    private readonly IBrasilApi _brasilApi;
    private readonly ICompanyRepository _companyRepository;
    private readonly IConsultRepository _consultRepository;
    private readonly ICompanyConsultRepository _companyConsultRepository;

    public CompanyServices(
        IMapper mapper, 
        IBrasilApi brasilApi, 
        ICompanyRepository companyRepository, 
        IConsultRepository consultRepository,
        ICompanyConsultRepository companyConsultRepository
        )
    {
        _mapper = mapper;
        _brasilApi = brasilApi;
        _companyRepository = companyRepository;
        _consultRepository = consultRepository;
        _companyConsultRepository = companyConsultRepository;
    }
    
    
    public async Task<ResponseGeneric<CompanyResponse>> GetCompany(string cnpj)
    {
        const int userId = 1;

        var consult = new Consult
        {
            Document = cnpj,
            Query = cnpj,
            SearchtDate = DateTime.UtcNow,
            UserId = userId
        };
        
        await _consultRepository.AddConsultAsync(consult);

        CompanyConsult companyConsult = new CompanyConsult();
        
        var company = await _companyRepository.GetCompanyByCnpjAsync(cnpj);

        if (company == null)
        {
            var newCompany = await _brasilApi.GetCompany(cnpj);

            if (newCompany.HttpCode == HttpStatusCode.OK && newCompany.ReturnData != null)
            {
                
                await _companyRepository.AddCompanyAsync(newCompany.ReturnData);
                
                companyConsult.ConsultId = consult.Id;
                companyConsult.CompanyId = newCompany.ReturnData.Id;
                companyConsult.AssociatedDate = DateTime.UtcNow;
                
                await _companyConsultRepository.AddAsync(companyConsult);
            }
            
            return _mapper.Map<ResponseGeneric<CompanyResponse>>(newCompany);
        }
        
        
        companyConsult.ConsultId = consult.Id;
        companyConsult.CompanyId = company.Id;
        companyConsult.AssociatedDate = DateTime.UtcNow;
        
        await _companyConsultRepository.AddAsync(companyConsult);
        
        return _mapper.Map<ResponseGeneric<CompanyResponse>>(
                new ResponseGeneric<Company>()
                {
                    HttpCode = HttpStatusCode.OK,
                    ReturnData = company
                }
            );
    }
}