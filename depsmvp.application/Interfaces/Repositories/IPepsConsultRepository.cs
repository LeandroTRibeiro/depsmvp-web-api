using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IPepsConsultRepository
{
    Task AddRangeAsync(List<PepsConsult> pepConsults);

    Task<List<Pep>> GetPepsByConsultationtIdAsync(int consultationId);
}