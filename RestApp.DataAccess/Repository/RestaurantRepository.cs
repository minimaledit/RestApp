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
    public class RestaurantRepository : BaseRepository, IRestaurantRepository
    {
        public RestaurantRepository(RestDbContext context) : base(context)
        {
        }
        public async Task<int> Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant.Id;
        }

        public async Task Delete(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Restaurant>> GetAll()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Restaurant> GetByName(string name)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.Name == name);
        }
        public async Task Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            await _context.SaveChangesAsync();
        }
    }
}
