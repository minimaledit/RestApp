using RestApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApp.DataAccess.Repository.Contacts
{
    public interface IReservationRepository
    {
        Task<Reservation> GetById(int id);
        Task<List<Reservation>> GetAll();
        Task<int> Create (Reservation reservation);
        Task Update(Reservation reservation);
        Task Delete(Reservation reservation);
    }
}
