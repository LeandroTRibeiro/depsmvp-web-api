using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IConsultRepository
{
    Task AddConsultAsync(Consult consult);
}