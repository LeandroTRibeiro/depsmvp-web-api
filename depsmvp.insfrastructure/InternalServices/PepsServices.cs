using System.Net;
using AutoMapper;
using DepsMvp.Application.DTOs;
using depsmvp.application.Interfaces.Services;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using depsmvp.insfrastructure.DB;

namespace depsmvp.insfrastructure.InternalServices;

public class PepsServices : IPepsServices
{
    private readonly IMapper _mapper;
    private readonly IPortalDaTrasparenciaApi _portalDaTrasparenciaApi;
    private readonly IPepsRepository _pepsRepository;
    private readonly IConsultRepository _consultationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPepsConsultRepository _pepsConsultRepository;
    private readonly ApplicationDbContext _dbContext;

    public PepsServices(
        IMapper mapper, 
        IPortalDaTrasparenciaApi portalDaTrasparenciaApi,
        IConsultRepository consultationRepository,
        IPepsRepository pepsRepository,
        IPepsConsultRepository pepsConsultRepository,
        IUserRepository userRepository,
        ApplicationDbContext dbContext
        )
    {
        _mapper = mapper;
        _portalDaTrasparenciaApi = portalDaTrasparenciaApi;
        _pepsRepository = pepsRepository;
        _consultationRepository = consultationRepository;
        _pepsConsultRepository = pepsConsultRepository;
        _userRepository = userRepository;
        _dbContext = dbContext;
    }
    
    public async Task<ResponseGeneric<List<PepsResponse>>> GetPepsByCpfAsync(
            string cpf, 
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
            ConsultationType = "CPF",
            ConsultationCode = cpf,
            ConsultationDateReference = parsedDate.ToUniversalTime(),
            ConsultationInterval = interval,
        };
        
        await _consultationRepository.AddConsultAsync(consultation);
        
        var peps = await _pepsRepository.GetAllPepsByCpfAsync(cpf);
        
        List<PepsConsult> pepConsults = new();
        
        if (!peps.Any())
        {
            var newPeps = await _portalDaTrasparenciaApi.GetPepAsync(cpf, parsedDate, interval);
            
            if (newPeps.HttpCode == HttpStatusCode.OK && newPeps.ReturnData != null)
            {
                await _pepsRepository.AddRangePepsAsync(newPeps.ReturnData, cpf);
                await _dbContext.SaveChangesAsync();
                
                
                foreach (var newPep in newPeps.ReturnData)
                {
                    var pepConsult = new PepsConsult()
                    {
                        ConsultationId = consultation.Id,
                        PepId = newPep.Id,
                        AssociatedDate = DateTime.UtcNow
                    };
                    pepConsults.Add(pepConsult);
                }
                
                await _pepsConsultRepository.AddRangeAsync(pepConsults);
                await _dbContext.SaveChangesAsync();
            }
    
            return _mapper.Map<ResponseGeneric<List<PepsResponse>>>(newPeps);
        }
        

        foreach (var pep in peps)
        {
            var pepConsult = new PepsConsult()
            {
                ConsultationId = consultation.Id,
                PepId = pep.Id,
                AssociatedDate = DateTime.UtcNow
            };
            pepConsults.Add(pepConsult);
        }
        
        await _pepsConsultRepository.AddRangeAsync(pepConsults);
        await _dbContext.SaveChangesAsync();
        
        return _mapper.Map<ResponseGeneric<List<PepsResponse>>>(
                new ResponseGeneric<List<Pep>>()
                {
                    HttpCode = HttpStatusCode.OK,
                    ReturnData = peps
                }
            );
    }

    public async Task<ResponseGeneric<List<PepsResponse>>> GetPepsByConsultationtIdAsync(int consultationId)
    {
        var peps =
            await _pepsConsultRepository.GetPepsByConsultationtIdAsync(consultationId);
        
        return _mapper.Map<ResponseGeneric<List<PepsResponse>>>(
            new ResponseGeneric<List<Pep>>()
            {
                HttpCode = HttpStatusCode.OK,
                ReturnData = peps
            }
        );
    }
}