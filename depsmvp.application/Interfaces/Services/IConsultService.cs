using DepsMvp.Application.DTOs;
using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IConsultService
{
    Task<PagedResponse<List<Consult>>> GetAllConsultsAsync(int? limit = null, int pageNumber = 1, int pageSize = 10);

}