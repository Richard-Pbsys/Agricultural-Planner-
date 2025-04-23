using VHS.Data.Models.Farming;
using VHS.Data.Infrastructure;

namespace VHS.Data.Repositories.Farming
{
    public interface ITrayRepository : IRepository<Tray> {}

    public class TrayRepository : Repository<Tray>, ITrayRepository
    {
        private readonly VHSDBContext _context;

        public TrayRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
