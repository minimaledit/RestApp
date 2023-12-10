using RestApp.Entities;

namespace RestApp.DataAccess.Repository.Contacts
{
    public interface ITableRepository
    {
        Task<Table> GetById(int id);
        Task<List<Table>> GetAll();
        Task<int> Create(Table table);
        Task Update(Table table);
        Task Delete(Table table);
    }
}
