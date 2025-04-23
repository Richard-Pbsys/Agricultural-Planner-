using VHS.Data.Models.Farming;
using VHS.Data.Infrastructure;

namespace VHS.Data.Repositories.Farming
{
    public interface ILayerRepository : IRepository<Layer> {}

    public class LayerRepository : Repository<Layer>, ILayerRepository
    {
        private readonly VHSDBContext _context;

        public LayerRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
