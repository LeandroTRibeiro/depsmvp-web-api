using depsmvp.domain.Entities;

namespace DepsMvp.Application.Services;

public interface IUserRepository
{
    Task<User> GetUserById(int id);
}