using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IConsultRepository
{
    Task AddConsultAsync(Consultation consultation);

    Task<List<Consultation>> GetAllConsultsAsync(int? limit = null, int pageNumber = 1, int pageSize = 10);

    Task<int> GetTotalConsultsCountAsync();
}