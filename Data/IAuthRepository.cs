using System.Threading.Tasks;
using SM.API.Models;

namespace SM.API.Data
{
    public interface IAuthRepository
    {
         Task<User> RegisterAsync(User user, string password);
         Task<User> LoginAsync(string username, string password);
         Task<bool> UserExistsAsync(string username);
    }
}