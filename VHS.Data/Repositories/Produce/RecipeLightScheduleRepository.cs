using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Produce;

namespace VHS.Data.Repositories.Produce
{
    public interface IRecipeLightScheduleRepository : IRepository<RecipeLightSchedule>
    {
    }
    public class RecipeLightScheduleRepository : Repository<RecipeLightSchedule>, IRecipeLightScheduleRepository
    {
        private readonly VHSDBContext _context;

        public RecipeLightScheduleRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
