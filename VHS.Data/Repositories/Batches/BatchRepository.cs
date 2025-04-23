using VHS.Data.Models.Batches;
using VHS.Data.Infrastructure;

namespace VHS.Data.Repositories.Batches
{
    public interface IBatchRepository : IRepository<Batch>
    {
    }
    public class BatchRepository : Repository<Batch>, IBatchRepository
    {
        private readonly VHSDBContext _context;

        public BatchRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
