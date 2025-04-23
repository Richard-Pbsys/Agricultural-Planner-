using VHS.Data.Infrastructure;
using VHS.Data.Models;
using VHS.Data.Models.Auth;

namespace VHS.Data.Repositories.Auth
{
    public interface IUserRepository : IRepository<User>
    {
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly VHSDBContext _context;

        public UserRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
