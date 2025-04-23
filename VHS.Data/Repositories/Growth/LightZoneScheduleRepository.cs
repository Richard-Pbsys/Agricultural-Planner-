using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Growth;

namespace VHS.Data.Repositories.Growth
{
    public interface ILightZoneScheduleRepository : IRepository<LightZoneSchedule>
    {
    }
    public class LightZoneScheduleRepository : Repository<LightZoneSchedule>, ILightZoneScheduleRepository
    {
        private readonly VHSDBContext _context;

        public LightZoneScheduleRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
