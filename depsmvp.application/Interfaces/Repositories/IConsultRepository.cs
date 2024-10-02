using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IConsultRepository
{
    Task AddConsultAsync(Consult consult);

    Task<List<Consult>> GetAllConsultsAsync(int? limit = null, int pageNumber = 1, int pageSize = 10);

    Task<int> GetTotalConsultsCountAsync();
}