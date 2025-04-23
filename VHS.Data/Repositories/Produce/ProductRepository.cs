using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Produce;


namespace VHS.Data.Repositories.Produce
{
    public interface IProductRepository : IRepository<Product>
    {
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly VHSDBContext _context;

        public ProductRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>>? filter = null, params string[] includeProperties)
        {
            IQueryable<Product> query = _context.Products;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public override async Task<Product?> GetByIdAsync(object id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == (Guid)id);
        }
    }
}
