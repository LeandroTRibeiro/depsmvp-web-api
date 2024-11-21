using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IPepsRepository
{
    Task AddRangePepsAsync(List<Pep> peps, string cpf);

    Task<List<Pep>> GetAllPepsByCpfAsync(string cpf);
}