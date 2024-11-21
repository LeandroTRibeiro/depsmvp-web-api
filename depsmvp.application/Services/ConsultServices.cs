using DepsMvp.Application.DTOs;
using DepsMvp.Application.Services;
using depsmvp.domain.Entities;

namespace depsmvp.insfrastructure.InternalServices;

public class ConsultationServices : IConsultServices
{
    private readonly IConsultRepository _consultationRepository;

    public ConsultationServices(IConsultRepository consultationRepository)
    {
        _consultationRepository = consultationRepository;
    }

    public async Task<PagedResponse<List<Consultation>>> GetAllConsultsAsync(int? limit, int pageNumber, int pageSize)
    {
        var totalItems = await _consultationRepository.GetTotalConsultsCountAsync();
        var consultations = await _consultationRepository.GetAllConsultsAsync(limit, pageNumber, pageSize);

        return new PagedResponse<List<Consultation>>()
        {
            Data = consultations,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = Convert.ToInt32(Math.Ceiling((double)totalItems / (double)pageSize))
        };
    }
}