using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Growth;

namespace VHS.Data.Repositories.Growth
{
    public interface IWaterZoneScheduleRepository : IRepository<WaterZoneSchedule>
    {
    }

    public class WaterZoneScheduleRepository : Repository<WaterZoneSchedule>, IWaterZoneScheduleRepository
    {
        private readonly VHSDBContext _context;

        public WaterZoneScheduleRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
