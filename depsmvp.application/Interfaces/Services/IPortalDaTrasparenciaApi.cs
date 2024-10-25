using DepsMvp.Application.DTOs;
using depsmvp.domain.Entities;

namespace depsmvp.application.Interfaces.Services;

public interface IPortalDaTrasparenciaApi
{
    Task<ResponseGeneric<List<Pep>>> GetPep(string cpf, DateTime referenceDate, int interval);
}