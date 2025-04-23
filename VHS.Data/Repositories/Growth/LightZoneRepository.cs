using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Infrastructure;
using VHS.Data.Models.Growth;

namespace VHS.Data.Repositories.Growth
{
    public interface ILightZoneRepository : IRepository<LightZone>
    {
    }
    public class LightZoneRepository : Repository<LightZone>, ILightZoneRepository
    {
        private readonly VHSDBContext _context;

        public LightZoneRepository(VHSDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
