using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Growth;

namespace VHS.Data.Repositories.Growth
{

    public interface IWaterZoneRepository : IRepository<WaterZone>
    {
    }
    public class WaterZoneRepository : Repository<WaterZone>, IWaterZoneRepository
    {
        private readonly VHSDBContext _context;

        public WaterZoneRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
