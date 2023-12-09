using RestApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.DataAccess.Repository.Contacts
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetById(int id);
        Task<List<Restaurant>> GetAll();
        Task<int> Create(Restaurant restaurant);
        Task Update(Restaurant restaurant);
        Task Delete(Restaurant restaurant);
        Task<Restaurant> GetByName(string name);
    }
}
