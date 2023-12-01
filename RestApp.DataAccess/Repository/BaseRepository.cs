namespace RestApp.DataAccess.Repository
{
    public class BaseRepository
    {
        public readonly RestDbContext _context;

        public BaseRepository(RestDbContext context)
        {
            _context = context;
        }
    }
}
