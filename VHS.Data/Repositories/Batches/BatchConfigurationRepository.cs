using VHS.Data.Models.Batches;
using VHS.Data.Infrastructure;

namespace VHS.Data.Repositories.Batches
{

    public interface IBatchConfigurationRepository : IRepository<BatchConfiguration>
    {
    }
    public class BatchConfigurationRepository : Repository<BatchConfiguration>, IBatchConfigurationRepository
    {
        private readonly VHSDBContext _context;

        public BatchConfigurationRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
