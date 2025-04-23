using VHS.Data.Models.Farming;
using VHS.Data.Infrastructure;

namespace VHS.Data.Repositories.Farming
{
    public interface ITrayCurrentStateRepository : IRepository<TrayCurrentState> {}

    public class TrayCurrentStateRepository : Repository<TrayCurrentState>, ITrayCurrentStateRepository
    {
        private readonly VHSDBContext _context;

        public TrayCurrentStateRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
