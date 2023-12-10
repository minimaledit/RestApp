using Microsoft.EntityFrameworkCore;
using RestApp.DataAccess.Repository.Contacts;
using RestApp.Entities;

namespace RestApp.DataAccess.Repository
{
    public class TableRepository : BaseRepository, ITableRepository
    {
        public TableRepository(RestDbContext context) : base(context)
        {
        }
        public async Task<int> Create(Table table)
        {
            _context.Tables.Add(table);
            await _context.SaveChangesAsync();
            return table.Id;
        }
        public async Task Delete(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Table>> GetAll()
        {
            return await _context.Tables.ToListAsync();
        }
        public async Task<Table> GetById(int id)
        {
            return await _context.Tables.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Update(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
