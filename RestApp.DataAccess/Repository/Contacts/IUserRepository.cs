using RestApp.Entities;

namespace RestApp.DataAccess.Repository.Contacts
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task<int> Create(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<User> GetByEmail(string email);
    }
}
