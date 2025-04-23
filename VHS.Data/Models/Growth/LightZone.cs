﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VHS.Data.Models.Farming;
using VHS.Data.Models.Produce;

namespace VHS.Data.Models.Growth
{
    public class LightZone
    {
        public Guid Id { get; set; }

        [Required]
        public Guid FarmId { get; set; }
        public virtual Farm Farm { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Target Daily Light Integral (DLI) in mol/m²/d
        /// </summary>
        public double? TargetDLI { get; set; }
        public virtual ICollection<LightZoneSchedule> LightZoneSchedules { get; set; } = new List<LightZoneSchedule>();

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        public LightZone()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
