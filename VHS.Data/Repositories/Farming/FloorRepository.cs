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
    public interface IFloorRepository : IRepository<Floor> {}

    public class FloorRepository : Repository<Floor>, IFloorRepository
    {
        private readonly VHSDBContext _context;

        public FloorRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Floor>> GetAllAsync(Expression<Func<Floor, bool>>? filter = null, params string[] includeProperties)
        {
            IQueryable<Floor> query = _context.Floors
                                              .Include(f => f.Farm)
                                              .Include(f => f.Racks);
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public override async Task<Floor?> GetByIdAsync(object id)
        {
            return await _context.Floors
                                 .Include(f => f.Farm)
                                 .Include(f => f.Racks)
                                 .FirstOrDefaultAsync(f => f.Id == (Guid)id);
        }
    }
}
