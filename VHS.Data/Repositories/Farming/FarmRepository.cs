using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Farming;

namespace VHS.Data.Repositories.Farming
{
    public interface IFarmRepository : IRepository<Farm> {}

    public class FarmRepository : Repository<Farm>, IFarmRepository
    {
        private readonly VHSDBContext _context;

        public FarmRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Farm>> GetAllAsync(Expression<Func<Farm, bool>>? filter = null, params string[] includeProperties)
        {
            IQueryable<Farm> query = _context.Farms
                                             .Include(f => f.FarmType)
                                             .Include(f => f.Floors)
                                                 .ThenInclude(fl => fl.Racks).ThenInclude(r => r.Layers);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public override async Task<Farm?> GetByIdAsync(object id)
        {
            return await _context.Farms
                                 .Include(f => f.FarmType)
                                 .Include(f => f.Floors)
                                     .ThenInclude(fl => fl.Racks)
                                        .ThenInclude(r => r.Layers)
                                 .FirstOrDefaultAsync(f => f.Id == (Guid)id);
        }
    }
}
