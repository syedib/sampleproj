using Microsoft.AspNetCore.Identity;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories;

public class UserRepository
{
    private readonly AppDBContext _dbContext;
    private readonly UserManager<User> _userManager;
    public UserRepository(AppDBContext dBContext, UserManager<User> userManager)
    {
        _dbContext = dBContext;
        _userManager = userManager;
    }

    public async Task<bool> CreateUser(User user) 
    {
       await _dbContext.Users.AddAsync(user);
       
       return await SaveAsync() > 0;
    }

    public async Task<User?> FindUserByEmail(string Email) 
        => await _userManager.FindByEmailAsync(Email);

    private async Task<int> SaveAsync() 
        => await _dbContext.SaveChangesAsync();
}
