using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VHS.Data.Models.Growth;

namespace VHS.Data.Models.Produce
{
    public class RecipeWaterSchedule
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public Guid WaterZoneScheduleId { get; set; }
        public virtual WaterZoneSchedule WaterZoneSchedule { get; set; }

        /// <summary>
        /// Target Daily Water Requirement (DWR) for this recipe schedule
        /// </summary>
        public double? TargetDWR { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public RecipeWaterSchedule()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
