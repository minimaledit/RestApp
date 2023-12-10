using Microsoft.EntityFrameworkCore;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Entities;

namespace RestApp.DataAccess.Repository
{
    internal class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(RestDbContext context) : base(context)
        {
        }
        public async Task<int> Create(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
            return reservation.Id;
        }
        public async Task Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Reservation>> GetAll()
        {
            return await _context.Reservations.ToListAsync();
        }
        public async Task<Reservation> GetById(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Update(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
    }
}
