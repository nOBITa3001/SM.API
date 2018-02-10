using System.Collections.Generic;
using System.Threading.Tasks;
using SM.API.Models;

namespace SM.API.Data
{
    public interface ISMRepository
    {
        Task AddAsync<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAllAsync();
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
    }
}