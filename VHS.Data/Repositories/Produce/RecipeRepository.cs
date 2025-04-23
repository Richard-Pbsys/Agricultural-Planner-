using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Produce;

namespace VHS.Data.Repositories.Produce
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
    }
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly VHSDBContext _context;

        public RecipeRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
