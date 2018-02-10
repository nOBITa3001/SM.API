using System.Collections.Generic;
using System.Threading.Tasks;
using SM.API.Models;
using Microsoft.EntityFrameworkCore;

namespace SM.API.Data
{
    public class SMRepository : ISMRepository
    {
        private readonly DataContext _context;
        public SMRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}