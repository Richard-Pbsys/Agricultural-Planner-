using VHS.Data.Infrastructure;
using VHS.Data.Models;
using VHS.Data.Models.Farming;

namespace VHS.Data.Repositories.Farming
{
    public interface IFarmTypeRepository : IRepository<FarmType> {}

    public class FarmTypeRepository : Repository<FarmType>, IFarmTypeRepository
    {
        private readonly VHSDBContext _context;

        public FarmTypeRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
