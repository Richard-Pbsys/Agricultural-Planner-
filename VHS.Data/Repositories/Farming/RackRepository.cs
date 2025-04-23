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
    public interface IRackRepository : IRepository<Rack> {}

    public class RackRepository : Repository<Rack>, IRackRepository
    {
        private readonly VHSDBContext _context;

        public RackRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Rack>> GetAllAsync(Expression<Func<Rack, bool>>? filter = null, params string[] includeProperties)
        {
            IQueryable<Rack> query = _context.Racks
                                             .Include(r => r.Floor.Farm);
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public override async Task<Rack?> GetByIdAsync(object id)
        {
            return await _context.Racks
                                .Include(r => r.Floor.Farm)
                                 .FirstOrDefaultAsync(r => r.Id == (Guid)id);
        }
    }
}
