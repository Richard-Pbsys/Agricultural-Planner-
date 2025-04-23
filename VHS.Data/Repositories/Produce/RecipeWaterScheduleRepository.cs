using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Produce;

namespace VHS.Data.Repositories.Produce
{
    public interface IRecipeWaterScheduleRepository : IRepository<RecipeWaterSchedule>
    {
    }
    public class RecipeWaterScheduleRepository : Repository<RecipeWaterSchedule>, IRecipeWaterScheduleRepository
    {
        private readonly VHSDBContext _context;

        public RecipeWaterScheduleRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
