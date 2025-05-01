using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Interfaces;
using RestfulApi.Domain.Models;
using RestfulApi.Infrastructure.Data;

namespace RestfulApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context  )
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();
        public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);
        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);
        public async Task UpdateAsync(User user) => _context.Users.Update(user);
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null) _context.Users.Remove(user);  
        }
    }
}
