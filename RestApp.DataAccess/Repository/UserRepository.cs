using Microsoft.EntityFrameworkCore;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.DataAccess.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(RestDbContext context) : base(context)
        {
        }

        public async Task<int> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
