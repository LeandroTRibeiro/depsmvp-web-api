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
    private readonly IConsultRepository _consultationRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICompanyConsultRepository _companyConsultRepository;

    public CompanyServices(
        IMapper mapper, 
        IBrasilApi brasilApi, 
        ICompanyRepository companyRepository, 
        IConsultRepository consultationRepository,
        IUserRepository userRepository,
        ICompanyConsultRepository companyConsultRepository
        )
    {
        _mapper = mapper;
        _brasilApi = brasilApi;
        _companyRepository = companyRepository;
        _consultationRepository = consultationRepository;
        _userRepository = userRepository;
        _companyConsultRepository = companyConsultRepository;
    }
    
    
    public async Task<ResponseGeneric<CompanyResponse>> GetCompanyAsync(
            string cnpj,
            string referenceDate,
            int interval
        )
    {
        const int userId = 1;
        var user = await _userRepository.GetUserByIdAsync(1);
        DateTime parsedDate = DateTime.ParseExact(referenceDate, "dd/MM/yyyy", null);

    
        var consultation = new Consultation
        {
            User = user,
            ConsultationDate = DateTime.UtcNow,
            ConsultationType = "CNPJ",
            ConsultationCode = cnpj,
            ConsultationDateReference = parsedDate.ToUniversalTime(),
            ConsultationInterval = interval,
        };
        
        await _consultationRepository.AddConsultAsync(consultation);

        CompanyConsult companyConsult = new CompanyConsult();
        
        var company = await _companyRepository.GetCompanyByCnpjAsync(cnpj);

        if (company == null)
        {
            var newCompany = await _brasilApi.GetCompanyAsync(cnpj);

            if (newCompany.HttpCode == HttpStatusCode.OK && newCompany.ReturnData != null)
            {
                
                await _companyRepository.AddCompanyAsync(newCompany.ReturnData);
                
                companyConsult.ConsultationId = consultation.Id;
                companyConsult.CompanyId = newCompany.ReturnData.Id;
                companyConsult.AssociatedDate = DateTime.UtcNow;
                
                await _companyConsultRepository.AddAsync(companyConsult);

            }
            
            return _mapper.Map<ResponseGeneric<CompanyResponse>>(newCompany);
        }
        
        companyConsult.ConsultationId = consultation.Id;
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

    public async Task<ResponseGeneric<CompanyResponse>> GetCompanyByConsultationtIdAsync(int consultationId)
    {
        var company = await _companyConsultRepository.GetCompanyByConsultationtIdAsync(consultationId);
        
        return _mapper.Map<ResponseGeneric<CompanyResponse>>(
            new ResponseGeneric<Company>()
            {
                HttpCode = HttpStatusCode.OK,
                ReturnData = company
            }
        );
    }
}