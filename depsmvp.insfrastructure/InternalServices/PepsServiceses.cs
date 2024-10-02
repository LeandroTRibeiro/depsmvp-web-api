using System.Net;
using AutoMapper;
using DepsMvp.Application.DTOs;
using depsmvp.application.Interfaces.Services;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using depsmvp.insfrastructure.DB;

namespace depsmvp.insfrastructure.InternalServices;

public class PepsServiceses : IPepsServices
{
    private readonly IMapper _mapper;
    private readonly IPortalDaTrasparenciaApi _portalDaTrasparenciaApi;
    private readonly IPepsRepository _pepsRepository;
    private readonly IConsultRepository _consultRepository;
    private readonly IPepsConsultRepository _pepsConsultRepository;
    private readonly ApplicationDbContext _dbContext;

    public PepsServiceses(
        IMapper mapper, 
        IPortalDaTrasparenciaApi portalDaTrasparenciaApi,
        IConsultRepository consultRepository,
        IPepsRepository pepsRepository,
        IPepsConsultRepository pepsConsultRepository,
        ApplicationDbContext dbContext
        )
    {
        _mapper = mapper;
        _portalDaTrasparenciaApi = portalDaTrasparenciaApi;
        _pepsRepository = pepsRepository;
        _consultRepository = consultRepository;
        _pepsConsultRepository = pepsConsultRepository;
        _dbContext = dbContext;
    }
    
    public async Task<ResponseGeneric<List<PepsResponse>>> GetPeps(string cpf)
    {
        const int userId = 1;
    
        var consult = new Consult
        {
            Document = cpf,
            Query = cpf,
            SearchtDate = DateTime.UtcNow,
            UserId = userId,
        };
        
        await _consultRepository.AddConsultAsync(consult);
        
        var peps = await _pepsRepository.GetAllPepsByCpfAsync(cpf);
        
        List<PepsConsult> pepConsults = new();
        
        if (!peps.Any())
        {
            var newPeps = await _portalDaTrasparenciaApi.GetPep(cpf);
            
            if (newPeps.HttpCode == HttpStatusCode.OK && newPeps.ReturnData != null)
            {
                await _pepsRepository.AddRangePepsAsync(newPeps.ReturnData, cpf);
                await _dbContext.SaveChangesAsync();
                
                
                foreach (var newPep in newPeps.ReturnData)
                {
                    var pepConsult = new PepsConsult()
                    {
                        ConsultId = consult.Id,
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
                ConsultId = consult.Id,
                PepId = pep.Id,
                AssociatedDate = DateTime.UtcNow
            };
            pepConsults.Add(pepConsult);
        }
        await _pepsConsultRepository.AddRangeAsync(pepConsults);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<ResponseGeneric<List<PepsResponse>>>(peps);
    }
}