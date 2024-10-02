using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities;

namespace depsmvp.insfrastructure.InternalServices;

public class ConsultServiceses : IConsultServices
{
    private readonly IConsultRepository _consultRepository;

    public ConsultServiceses(IConsultRepository consultRepository)
    {
        _consultRepository = consultRepository;
    }
    
    public async Task<PagedResponse<List<Consult>>> GetAllConsultsAsync(int? limit, int pageNumber, int pageSize)
    {
        var totalItems = await _consultRepository.GetTotalConsultsCountAsync();
        var consults = await _consultRepository.GetAllConsultsAsync(limit, pageNumber, pageSize);

        return new PagedResponse<List<Consult>>()
        {
            Data = consults,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalItems / (double)pageSize))
        };
    }
}