using DepsMvp.Application.Services;
using depsmvp.domain.Entities;

namespace depsmvp.insfrastructure.DB.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user == null)
        {
            throw new Exception("User not found");
        }
        
        return user;
    }
}