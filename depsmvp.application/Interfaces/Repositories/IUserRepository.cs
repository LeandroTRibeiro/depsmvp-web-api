using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IUserRepository
{
    Task<User> GetUserByIdAsync(int id);
}