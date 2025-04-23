using VHS.Data.Infrastructure;
using VHS.Data.Models;
using VHS.Data.Models.Auth;

namespace VHS.Data.Repositories.Auth
{
    public interface IUserSettingRepository : IRepository<UserSetting>
    {
    }
    public class UserSettingRepository : Repository<UserSetting>, IUserSettingRepository
    {
        private readonly VHSDBContext _context;

        public UserSettingRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
