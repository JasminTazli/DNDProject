using Domain.Models;

namespace Application.Interfaces;

public interface IUserService
{
    public List<User> GetUsers();
    public Task<User> SaveUserAsync(User user);
}
