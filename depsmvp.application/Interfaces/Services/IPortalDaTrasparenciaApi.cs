using DepsMvp.Application.DTOs;
using depsmvp.domain.Entities;

namespace depsmvp.application.Interfaces.Services;

public interface IPortalDaTrasparenciaApi
{
    Task<ResponseGeneric<List<Pep>>> GetPepAsync(string cpf, DateTime referenceDate, int interval);
}